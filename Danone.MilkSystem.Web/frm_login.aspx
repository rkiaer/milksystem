<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_login.aspx.vb" Inherits="frm_login" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Login Usuário</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</HEAD>
<body onload="document.getElementById('txt_usuario').focus();">
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 80%">
            <tr>
                <td align="center" style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 50%; border-top-style: solid; border-right-style: solid; border-left-style: solid; border-bottom-style: solid;" id="TABLE1" onclick="return TABLE1_onclick()">
                            <tr>
                                <td align="left" colspan="2" style="font-weight: bold; font-size: 10px; font-family: Verdana;
                                    height: 19px; background-color: #99b4e2">
                                    &nbsp;Evolution
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 20%; font-family: Verdana;
                                    height: 19px; background-color: white;">
                                    &nbsp;</td>
                                <td align="left" style="font-weight: bold; font-size: 10px; width: 70%; font-family: Verdana;
                                    height: 19px; background-color: white;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 30%; font-family: Verdana;height: 19px; background-color: white;">
                                    Usuário:</td>
                                <td align="left" style="font-weight: bold; font-size: 10px; width: 70%; font-family: Verdana;height: 19px; background-color: white;">
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txt_usuario" runat="server" CssClass="textBox" Width="180px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 30%; font-family: Verdana;height: 19px; background-color: white;">
                                    Senha:</td>
                                <td align="left" style="width: 70%; font-weight: bold; font-size: 10px; font-family: Verdana; height: 19px; background-color: white;">
                                    &nbsp; &nbsp;<asp:TextBox ID="txt_senha" runat="server" CssClass="textBox" Width="180px" TextMode="Password"></asp:TextBox></td>
                            </tr>
                            <tr  id="trNewPassword" runat="server">
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 30%; font-family: Verdana;height: 19px; background-color: white;">
                                    Nova Senha:</td>
                                <td align="left" style="width: 70%; font-weight: bold; font-size: 10px; font-family: Verdana; height: 19px; background-color: white;">
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txt_newPassword" runat="server" CssClass="textBox" TextMode="Password"
                                    Width="180px"></asp:TextBox></td>
                            </tr>
                            <tr id="trConfirmPassword" runat="server">
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 30%; font-family: Verdana;height: 19px; background-color: white;" >
                                    Confirmação:</td>
                                <td align="left" style="width: 70%; font-weight: bold; font-size: 10px; font-family: Verdana; height: 19px; background-color: white;">
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txt_confirmPassword" runat="server" CssClass="textBox" TextMode="Password"
                                    Width="180px"></asp:TextBox></td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td align="right" style="font-weight: bold; font-size: 10px; width: 30%; font-family: Verdana;
                                    height: 19px; background-color: white;">
                                </td>
                                <td align="left" style="font-weight: bold; font-size: 10px; width: 70%; font-family: Verdana;
                                    height: 19px; background-color: white;">
                                    &nbsp;&nbsp;
                                    <anthem:Label ID="lbl_browser" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp; &nbsp;<anthem:Label
                                            ID="lbl_versao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                            UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
                            <tr id="trCadastro" runat="server">
                                <td align="center" colspan="2" style="height: 19px; font-weight: normal; font-size: 10px; font-family: Verdana; background-color: white;">
                                Clique
                                <asp:LinkButton ID="lk_alterar_senha" runat="server" >aqui</asp:LinkButton>
                                para alterar a sua senha no Banco de Dados.</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 18px; background-color: gainsboro;">
                                <asp:Button ID="btn_entrar" runat="server" CssClass="texto" Text="   Entrar   "  />&nbsp;</td>
                            </tr>
                        </table>
                    &nbsp;<div style="text-align: center">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <cc1:AlertMessages ID="messageControl" runat="server"></cc1:AlertMessages>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</HTML>
