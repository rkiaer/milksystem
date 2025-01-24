<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_termo_ocorrencia.aspx.vb" Inherits="frm_relatorio_termo_ocorrencia" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Termo de Ocorrência</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; vertical-align: middle; text-align: center;">
        
            <table style="text-align: center" cellpadding="1" cellspacing="1" width="98%">
            <tr>
            <td style="height: 13px">
            </td></tr>
            <tr><td>
            <table width="100%" cellpadding="1" cellspacing="0" >
                <tr>
                    <td width="10%" rowspan="3" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid" align="center" valign="middle"><img  src="img/logo.gif"/></td>
                    <td align="center" class="textosmallbold" colspan="2" style="border-right: gray 1px solid; border-top: gray 1px solid;">
                        TERMO DE OCORRÊNCIA</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="textosmallbold" style="border-right: gray 1px solid; height: 3px;">&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                   <td align="center" colspan="2" style="border-right: gray 1px solid; height: 21px; border-bottom: gray 1px solid;" class="textosmallbold">
                       Romaneio:
                       <asp:Label ID="lbl_romaneio" runat="server" CssClass="textosmallbold" Font-Italic="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 7px" class="texto12pt">
                        <span class="obrigatorio"></span>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%; border-bottom-width: 1px; border-bottom-color: silver;" class="textosmall" >
                        <strong>Estabelecimento:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 20%; border-bottom-width: 1px; border-bottom-color: silver; border-left: silver 1px solid;" >
                        &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%; border-bottom: silver 1px solid;" class="textosmall" >
                        <strong>Nr. Rota / Nota:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; border-bottom: silver 1px solid; width: 80%; border-left: silver 1px solid;" >
                        &nbsp;<asp:Label ID="lbl_rotanota" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
            </table>
            <table width="100%" class="textosmall" >
                <tr>
                    <td align="left" colspan="5" class="textosmall" style="border-bottom: gray 1px solid; height: 7px;">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                                <tr>
                
                    <td align="center" valign="top" style="height: 5px" >
                    </td>
                
                </tr>
 
            </table>
            <table width="99%" cellspacing="0" >
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Transportadora:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_transportador" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>CNPJ/MF:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_cnpj_transportador" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Motorista:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_motorista" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Nr. da Frota:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Nota(s) Fiscal(s):&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Data da Entrega:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_dt_hora_entrada" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%;" class="textosmall" >
                        <strong>Horário:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_hora_entrada" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%; border-bottom: silver 1px solid;" class="textosmall" >
                        <strong>Destino da Carga:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; border-bottom: silver 1px solid; width: 80%;" >
                        &nbsp;</td>
                    
                </tr>
                </table>
            <table width="99%" cellspacing="0" >
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" style="height: 9px" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 26px; border-top: silver 1px solid; border-left: silver 1px solid; border-right: silver 1px solid;" class="textosmall" colspan="2" >
                        <strong>&nbsp;Ocorrências Durante o Transporte:</strong></td>
                </tr>
                <tr>
                    <td align="left" style="height: 10px; border-left: silver 1px solid; width: 25%;" class="textosmall" >
                        &nbsp;</td>
                    <td align="left" class="textosmall" style="height: 10px; border-right: silver 1px solid; width: 80%;" >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="height: 20px; border-left: silver 1px solid; border-right: silver 1px solid;" class="textosmall" colspan="2" >
                        &nbsp;Falta do seguinte produto:</td>
                </tr>
                <tr>
                    <td align="right" style="height: 20px; border-left: silver 1px solid; width: 25%;" class="textosmall" >
                        <strong>
                            <asp:Label ID="lbl_volume_descontado" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; width: 80%;" >
                        lts de leite in natura</td>
                </tr>
                <tr>
                    <td align="right" style="height: 5px; border-left: silver 1px solid; width: 20%; border-bottom: silver 1px solid;" class="textosmall" >
                        <strong>&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 5px; border-right: silver 1px solid; border-bottom: silver 1px solid; width: 80%;" >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" style="height: 11px; border-bottom: gray 1px solid;" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" colspan="2" style="border-top: gray 1px solid; height: 86px; text-align: justify;"><b>
                        <br />
                        <span style="font-style: italic; text-align: justify; font-size: 12px; line-height: 18px;">
                            Reconheço, na qualidade de motorista da Transportadora, que conferi a carga na partida
                            e na chegada, sendo que, considerando as condições da mercadoria na partida e na
                            chegada, constatei que durante o transporte foram perdidas/danificadas mercadorias,
                            conforme acima especificado, no valor de&nbsp;
                            <asp:Label ID="lbl_valor_pagar" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label>.</span>
                        <br />
                        </b>
                    </td>
                </tr>
                </table>
            <table width="100%">
                <tr>
                    <td align="center" style="height: 17px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 17px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 14px" class="textosmall"  >
                        ________________________________________________</td>
                </tr>
                <tr>
                    <td align="center" class="textosmall"  >
                        Local/Data</td>
                </tr>
                <tr>
                    <td align="center" style="height: 17px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 20px">
                    </td>
                </tr>
                 <tr>
                    <td align="center" style="height: 14px" class="textosmall"  >________________________________________________</td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall"  >
                        Assinatura Transportador</td>
                </tr>
            </table>
            <br />
            </td></tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     </form>
	</body>
</HTML>