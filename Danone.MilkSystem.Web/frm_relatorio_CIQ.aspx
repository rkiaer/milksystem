<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_CIQ.aspx.vb" Inherits="frm_relatorio_CIQ" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório CIQ</title>
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
                    <td width="10%" rowspan="4" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid" align="center" valign="middle"><img  src="img/logo.gif"/></td>
                    <td align="center" class="textosmallbold" colspan="2" style="border-right: gray 1px solid; border-top: gray 1px solid;">
                        COMUNICACÃO DE INCIDENTE DE QUALIDADE</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="textosmallbold" style="border-right: gray 1px solid; height: 5px;">&nbsp;&nbsp;
                       CIQ Nr:
                       <asp:Label ID="lbl_nr_ciq" runat="server" CssClass="textosmallbold" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td align="center" colspan="2" style="border-right: gray 1px solid; height: 5px;" class="textosmallbold">
                       Romaneio:
                       <asp:Label ID="lbl_romaneio" runat="server" CssClass="textosmallbold" Font-Italic="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-right: gray 1px solid; border-bottom: gray 1px solid;" class="textosmallbold">
                        &nbsp;&nbsp;
                        </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 14px" class="texto12pt">
                        <span class="obrigatorio"></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="font-size: 11px; height: 14px" class="textosmall">Não conformidade com: <span class="obrigatorio"> Leite</span></td>
                </tr>
                 <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
            <table width="100%" cellspacing="0" >
                <tr>
                    <td align="left" style="width: 30%; height: 20px; border-right: gray 1px solid; border-left: gray 1px solid;" class="textosmall" ><strong> &nbsp; Emitente: </strong></td>
                    <td align="left" style="width: 25%; height: 20px; border-right: gray 1px solid;" class="textosmall" ><strong>&nbsp; Data: </strong></td>
                    <td width="40%" align=left style="border-right: gray 1px solid;" class="textosmall">
                        <strong>&nbsp; Cópias para:</strong></td>
                </tr>
                 <tr>
                    <td align="center" style="height: 20px; border-right: gray 1px solid; border-left: gray 1px solid; width: 30%; border-bottom: gray 1px solid;" class="textosmall" ><asp:Label ID="lbl_emitente" runat="server" Font-Italic="True" CssClass="textosmall"  ></asp:Label></td>
                    <td align="center" class="textosmall" style="height: 20px; border-right: gray 1px solid; border-bottom: gray 1px solid;" ><asp:Label ID="lbl_data" runat="server" Font-Italic="True" CssClass="textosmall"  ></asp:Label></td>
                    <td align="center" class="textosmall" width="40%" style="border-right: gray 1px solid; border-bottom: gray 1px solid;" rowspan="">
                         <asp:Label ID="lbl_copias" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="3" class="textosmall" style="height: 25px"></td>
                </tr>
                 <tr>
                    <td align="center" colspan="3"><img  src="img/back_fx_ciq_title.gif"/></td>
                </tr>
            </table>
            <table width="100%" class="textosmall" >
                <tr>
                    <td align="center" class="textosmall" style="height: 25px" >
                    </td>
                    <td align="center" class="textosmall" style="height: 25px" >
                    </td>
                    <td align="center" class="textosmall" style="height: 25px">
                    </td>
                    <td align="center" class="textosmall" style="height: 25px">
                    </td>
                    <td align="center" class="textosmall" style="height: 25px">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" ><strong>Material </strong></td>
                    <td align="center" class="textosmall" ><strong>&nbsp;<asp:Label ID="lbl_label_rota_nota" runat="server" CssClass="textosmall" Font-Italic="False">Rota</asp:Label></strong></td>
                    <td align="center" class="textosmall">
                        <strong>Nr Compartimento</strong></td>
                    <td align="center" class="textosmall"><strong>Qtd Não Conforme</strong></td>
                    <td align="center" class="textosmall"><strong>Qtd Rejeitada</strong></td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall" ><asp:Label ID="lbl_nm_item" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall" ><asp:Label ID="lbl_rota_nota" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_nr_compartimento" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_qtd_nao_conforme" runat="server" CssClass="textosmall" Font-Italic="True" ForeColor="Red"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_qtd_rejeitada" runat="server" CssClass="textosmall" Font-Italic="True" ForeColor="Red"  ></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" >
                    </td>
                    <td align="center" class="textosmall" >
                    </td>
                    <td align="center" class="textosmall">
                    </td>
                    <td align="center" class="textosmall">
                    </td>
                    <td align="center" class="textosmall">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" >
                        <strong>Data de Recebimento&nbsp;</strong></td>
                    <td align="center" class="textosmall" >
                        <strong>Placa</strong></td>
                    <td align="center" class="textosmall">
                        <strong>Documento de Referência</strong></td>
                    <td align="center" class="textosmall">
                        <strong>Data da Detecção</strong></td>
                    <td align="center" class="textosmall">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" ><asp:Label ID="lbl_dt_recebimento" runat="server" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall" >
                        <asp:Label ID="lbl_placa" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                    <td align="center" class="textosmall">
                        <asp:Label ID="lbl_dcto_referencia" runat="server" CssClass="textosmall" Font-Italic="True">QASA99 LEI 001</asp:Label></td>
                    <td align="center" class="textosmall">
                        <asp:Label ID="lbl_dt_inicio_analise" runat="server" Font-Italic="True"></asp:Label></td>
                    <td align="center" class="textosmall">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5" class="textosmall" style="border-bottom: gray 1px solid">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
            </table>
            <table width="100%" >
                <tr>
                
                    <td align="center" valign="top" style="height: 267px" >
                        <anthem:GridView ID="grdresults" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <itemtemplate>
<TABLE style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid" class="textosmall" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 20%; BORDER-BOTTOM: silver 1px solid; BORDER-COLLAPSE: collapse; HEIGHT: 20px" align=left><STRONG>Tipo de Defeito:</STRONG> </TD><TD style="WIDTH: 80%; BORDER-BOTTOM: silver 1px solid; BORDER-COLLAPSE: collapse; HEIGHT: 20px" align=left>&nbsp;<asp:Label id="lbl_nm_analise" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w1" Text='<%# Bind("nm_analise") %>'></asp:Label>&nbsp;<asp:Label id="lbl_nr_valor_dec" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w2" Text='<%# Bind("nr_valor") %>'></asp:Label> <asp:Label id="lbl_nr_valor_logico" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w3" Text='<%# Bind("nm_analise_logica") %>'></asp:Label> <asp:Label id="lbl_nr_valor_int" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w4" Text='<%# Bind("nr_valor") %>'></asp:Label></TD></TR><TR><TD style="WIDTH: 20%; BORDER-COLLAPSE: collapse; HEIGHT: 20px" align=left><STRONG>Comentários:</STRONG></TD><TD style="WIDTH: 80%; BORDER-COLLAPSE: collapse; HEIGHT: 20px" class="textosmall" align=left>&nbsp;<asp:Label id="lbl_comentario" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w5" Text='<%# Bind("ds_comentario") %>'></asp:Label></TD></TR></TBODY></TABLE>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<asp:Label id="id_formato_analise" __designer:dtid="1407417833226322" runat="server" Font-Italic="True" CssClass="textosmall" __designer:wfdid="w8" Text='<%# bind("id_formato_analise") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cd_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_cd_analise" runat="server" __designer:wfdid="w6" Text='<%# Bind("cd_analise") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                        </anthem:GridView>
                    </td>
                
                </tr>
            </table>            
            <table width="99%" cellspacing="0" border="1" >
                <tr>
                    <td align="left" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 20%; border-bottom: silver 1px solid;" class="textosmall" >
                        <strong>Disposição:&nbsp;</strong></td>
                    <td align="left" class="textosmall" style="height: 20px; border-right: silver 1px solid; border-top: silver 1px solid; border-bottom: silver 1px solid; width: 80%;" >
                        <asp:Label ID="lbl_disposicao" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" style="height: 16px" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" style="height: 21px; border-bottom: gray 1px solid;" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall" colspan="2" style="border-top: gray 1px solid; height: 161px;"><b>
                        <br />
                        <span style="font-style: italic; text-align: justify; font-size: 12px; line-height: 18px;">Agradecemos a atenção e nos colocamos a disposição para esclarecimentos de dúvidas. Favor enviar-nos a resposta acompanhada de ação corretiva, no prazo máximo de 10
                        dias úteis, após o recebimento deste documento.</span>&nbsp;<br />
                        <br />
                        <img  src="img/assinatura_gerente_ciq.gif" style="font-weight: bold"/>&nbsp;<br />
                        
                        </b><strong>Adriano Bottura</strong><br />
                        Gerente de Controle de Qualidade &amp; Segurança Alimentar<br />
                        <br />
                    </td>
                </tr>
                </table>
                        <table width="100%">
                 <tr>
                    <td align="center"  style="height: 28px; border-bottom: gray 5px solid;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center" style="height: 14px">
                    </td>
                    <td align="center" style="height: 14px">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 14px">
                    </td>
                    <td align="center" style="height: 14px">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                 <tr>
                    <td align="center" style="height: 14px" class="textosmall"  >________________________________________________</td>
                    <td align="center" style="height: 14px" class="textosmall"  >Data: ___/___/______</td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall"  >Técnico Responsável</td>
                    <td align="center"  ></td>
                </tr>
            </table>
            <br />
            </td></tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     </form>
	</body>
</HTML>