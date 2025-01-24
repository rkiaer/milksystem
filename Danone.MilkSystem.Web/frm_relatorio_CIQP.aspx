<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_CIQP.aspx.vb" Inherits="frm_relatorio_CIQP" %>

   
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório CIQP</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; vertical-align: middle; text-align: center;">
        
            <table style="text-align: center" cellpadding="1" cellspacing="1" width="97%">
            <tr>
            <td style="height: 13px">
            </td></tr>
            <tr><td>
            <table width="100%" cellpadding="1" cellspacing="0" >
                <tr>
                    <td width="10%" rowspan="4" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid" align="center" valign="middle"><img  src="img/logo.gif"/></td>
                    <td align="center" class="textosmallbold" colspan="2" style="border-right: gray 1px solid; border-top: gray 1px solid; font-size: 14px; height: 23px">
                        COMUNICACÃO DE INCIDENTE DE QUALIDADE AO PRODUTOR</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="textosmallbold" style="border-top-width: 1px; border-right: gray 1px solid; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray; height: 9px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                   <td align="center" colspan="2" style="border-top-width: 1px; border-right: gray 1px solid; border-left-width: 1px; border-left-color: gray; border-bottom-width: 1px; border-bottom-color: gray; border-top-color: gray; height: 23px" class="textosmallbold">CIQP Nr:
                       <asp:Label ID="lbl_nr_ciqp" runat="server" CssClass="textosmallbold" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-right: gray 1px solid; border-bottom: gray 1px solid; height: 23px" class="textosmallbold">
                        Referente a CIQ:
                        <asp:Label ID="lbl_nr_ciq" runat="server" CssClass="textosmallbold" Font-Italic="True"  ></asp:Label>
                        &nbsp;e Romaneio:
                        <asp:Label ID="lbl_id_romaneio" runat="server" CssClass="textosmallbold" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 14px" class="texto12pt">
                        <span class="obrigatorio"></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="font-size: 11px; height: 14px" class="textosmall">Não conformidade com: <span class="obrigatorio">Produtor de Leite</span></td>
                </tr>
                 <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
                <table border="0" width="100%" cellspacing="0">
                    <tr>
                        <td align="left" class="textosmall" style="width: 20%; height: 20px; border-left: gray 1px solid;">
                            <strong>Emitente: </strong>
                        </td>
                        <td align="left" class="textosmall" style="width: 20%; height: 20px; border-right: gray 1px solid; border-left: gray 1px solid;">
                            <strong>Data:</strong>
                        </td>
                        <td align="center" class="textosmall" style="width: 1%; height: 20px">
                        </td>
                        <td align="center" class="textosmall" style="width: 60%; height: 20px; border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid;"
                            width="40%">
                            <strong>Nome do Produtor</strong></td>
                    </tr>
                    <tr>
                        <td align="left" class="textosmall" style="height: 25px; border-left: gray 1px solid; width: 20%; border-bottom: gray 1px solid;">
                            &nbsp;<asp:Label ID="lbl_emitente" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                        <td align="left" class="textosmall" style="height: 25px; border-right: gray 1px solid; border-left: gray 1px solid; width: 20%; border-bottom: gray 1px solid;">
                            &nbsp;<asp:Label ID="lbl_data" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                        <td align="center" class="textosmall" rowspan="1" style="height: 25px; width: 1%;">
                        </td>
                        <td align="center" class="textosmall" rowspan="1" style="height: 25px; border-right: gray 1px solid; border-left: gray 1px solid; width: 60%;" width="40%">
                            <asp:Label ID="lbl_produtor" runat="server" CssClass="textosmallbold" Font-Italic="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="textosmall" colspan="2" style="height: 20px">
                         <strong>Cópias para:</strong>&nbsp;
                            <asp:Label ID="lbl_copias" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                        <td class="textosmall" style="height: 20px; width: 1%;">
                        </td>
                        <td class="textosmall" style="height: 20px; border-right: gray 1px solid; border-left: gray 1px solid; width: 60%;" width="40%">
                            &nbsp; &nbsp;
                         </td>
                    </tr>
                    <tr>
                        <td align="left" class="textosmall" colspan="2" style="border-bottom: silver 1px solid;
                            height: 20px">
                            &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                        <td class="textosmall" style="height: 20px; width: 1%;">
                        </td>
                        <td class="textosmall" style="height: 20px; border-right: gray 1px solid; border-left: gray 1px solid; width: 60%; border-bottom: gray 1px solid;" width="40%">
                         Propriedade:
                            <asp:Label ID="lbl_propriedade" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="textosmall" colspan="4" style="height: 25px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <img src="img/back_fx_ciq_title.gif" /></td>
                    </tr>
                </table>
            <table width="100%" class="textosmall" >
                <tr>
                    <td align="center" class="textosmall" style="height: 25px" >
                    </td>
                    <td align="center" class="textosmall" style="height: 25px; width: 138px;" >
                    </td>
                    <td align="center" class="textosmall" style="height: 25px" colspan="2">
                    </td>
                    <td align="center" class="textosmall" style="height: 25px">
                    </td>
                    <td align="center" class="textosmall" style="height: 25px">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" ><strong>Transportador </strong> </td>
                    <td align="center" class="textosmall" style="width: 138px" ><strong>Técnico Responsável </strong></td>
                    <td align="center" class="textosmall" colspan="2"><strong>Qtd Recebida</strong></td>
                    <td align="center" class="textosmall"><strong>Qtd Não Conforme</strong></td>
                    <td align="center" class="textosmall"><strong>Qtd Rejeitada</strong></td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall" ><asp:Label ID="lbl_placa" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall" style="width: 138px" ><asp:Label ID="lbl_tecnico" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall" colspan="2"><asp:Label ID="lbl_qtd_recebida" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_qtd_nao_conforme" runat="server" CssClass="textosmall" Font-Italic="True" ForeColor="Red"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_qtd_rejeitada" runat="server" CssClass="textosmall" Font-Italic="True" ForeColor="Red"  ></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="6" class="textosmall"></td>
                </tr>
                 <tr>
                    <td align="center" style="height: 22px" class="textosmall" ><strong>Data do Recebimento </strong></td>
                    <td align="center" style="height: 22px; width: 138px;" class="textosmall" ><strong>Rota </strong></td>
                     <td align="left" class="textosmall" style="height: 22px">
                     </td>
                    <td align="left" colspan=3 style="height: 22px" class="textosmall">
                        <anthem:CheckBox ID="ck_defeito_recebimento" runat="server" Text="Defeito constatado no recebimento" Checked="True" /></td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall" style="height: 22px" ><asp:Label ID="lbl_dt_recebimento" runat="server" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall" style="height: 22px; width: 138px;" ><asp:Label ID="lbl_rota" runat="server" Font-Italic="True"  ></asp:Label></td>
                     <td align="left" class="textosmall" colspan="1" style="height: 22px">
                     </td>
                    <td align="left" colspan=3 class="textosmall" style="height: 22px">
                        <anthem:CheckBox ID="ck_defeito_monitoramento" runat="server" Text="Defeito constatado no monitoramento" /></td>
                </tr>
            </table>
            <table width="100%" >
            <tr><td style="height: 21px; border-bottom: gray 1px solid;">
                &nbsp;
            </td></tr>
                <tr>
                
                    <td align="center" >
                        <anthem:GridView ID="grdresults" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <itemtemplate>
<TABLE style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid" class="textosmall" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 20%; BORDER-BOTTOM: silver 1px solid; BORDER-COLLAPSE: collapse; HEIGHT: 20px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: silver" align=left><STRONG>Tipo de Defeito:</STRONG> </TD><TD style="WIDTH: 20%; BORDER-BOTTOM: silver 1px solid; BORDER-COLLAPSE: collapse; HEIGHT: 20px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: silver" align=left>&nbsp;<asp:Label id="lbl_nm_analise" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# Bind("nm_analise") %>' __designer:wfdid="w9"></asp:Label>&nbsp;<asp:Label id="lbl_nr_valor_dec" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w10"></asp:Label> <asp:Label id="lbl_nr_valor_logico" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# Bind("nm_analise_logica") %>' __designer:wfdid="w11"></asp:Label> <asp:Label id="lbl_nr_valor_int" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w12"></asp:Label></TD></TR><TR><TD style="BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: silver; WIDTH: 20%; BORDER-COLLAPSE: collapse; HEIGHT: 20px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: silver" align=left><STRONG>Comentários:</STRONG></TD><TD style="WIDTH: 80%; BORDER-COLLAPSE: collapse; HEIGHT: 20px" class="textosmall" align=left>&nbsp;<asp:Label id="lbl_comentario" __designer:dtid="1407417833226314" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# Bind("ds_comentario") %>' __designer:wfdid="w13"></asp:Label></TD></TR></TBODY></TABLE>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<asp:Label id="id_formato_analise" __designer:dtid="1407417833226322" runat="server" Font-Italic="True" CssClass="textosmall" Text='<%# bind("id_formato_analise") %>' __designer:wfdid="w58"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cd_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_cd_analise" runat="server" Text='<%# Bind("cd_analise") %>' __designer:wfdid="w6"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                        </anthem:GridView>
                    </td>
                
                </tr>
                <tr>
                    <td class="textosmall">
                        <table cellspacing="0" width="99%">
                            <tr>
                                <td align="left" class="textosmall" style="border-top: silver 1px solid; border-left: silver 1px solid;
                                    width: 20%; border-bottom: silver 1px solid; height: 20px">
                                    <strong>Disposição:&nbsp;</strong></td>
                                <td align="left" class="textosmall" style="border-right: silver 1px solid; border-top: silver 1px solid;
                                    width: 80%; border-bottom: silver 1px solid; height: 20px">
                                    <asp:Label ID="lbl_disposicao" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                </tr>
                <tr><td style="border-bottom: gray 2px solid; height: 22px;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td></tr>
            </table>            
            <table width="98%" >
                <tr>
                    <td align="left" Font-Italic="True" class="textosmall"><b>
                        <br />
                        <span style="font-style: italic; text-align: justify; font-size: 12px; line-height: 18px;">Agradecemos a atenção e nos colocamos a disposição para esclarecimentos de dúvidas. Favor enviar-nos a resposta acompanhada de ação corretiva, no prazo máximo de 15
                        dias úteis, após o recebimento deste documento.</span>&nbsp;<br />
                        <br />
                        <br />
                        Leonardo Siman</b><br />
                        Gerente do DAL - Departamento de Aprovisionamento de Leite<br />
                        <br />
                    </td>
                </tr>
                </table>
                        <table width="100%">
                 <tr>
                    <td align="center"  style="height: 4px; border-bottom: gray 5px solid;" >
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
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
                    <td align="center" style="height: 21px">
                    </td>
                    <td align="center" style="height: 21px">
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
                    <td align="center" class="textosmall"  ></td>
                </tr>
            </table>
            <br />
            </td></tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     </form>
	</body>
</HTML>