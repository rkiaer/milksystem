<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transvase_impressao.aspx.vb" Inherits="frm_transvase_impressao" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Impressão Transvase</title>
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
                        INFORMAÇÃO TRANSVASE</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="textosmallbold" style="border-right: gray 1px solid; height: 5px;">&nbsp;&nbsp;&nbsp;Transvase Nr:
                       <asp:Label ID="lbl_nr_transit_point" runat="server" CssClass="textosmallbold" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td align="center" colspan="2" style="border-right: gray 1px solid; height: 5px;" class="textosmallbold">
                       Estabelecimento:
                       <asp:Label ID="lbl_transit_point_unidade" runat="server" CssClass="textosmallbold" Font-Italic="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="border-right: gray 1px solid; border-bottom: gray 1px solid;" class="textosmallbold">
                        &nbsp;&nbsp;
                        </td>
                </tr>
                 <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
            <table width="100%" cellspacing="0" >
                <tr>
                    <td align="left" style="width: 50%; height: 20px; border-right: gray 1px solid; border-left: gray 1px solid;" class="textosmall" ><strong> &nbsp; Emitente: </strong></td>
                    <td align="left" style="width: 50%; height: 20px;" class="textosmall" ><strong>&nbsp; Data Emissão: </strong></td>
                </tr>
                 <tr>
                    <td align="center" style="height: 20px; border-right: gray 1px solid; border-left: gray 1px solid; width: 30%; border-bottom: gray 1px solid;" class="textosmall" ><asp:Label ID="lbl_emitente" runat="server" Font-Italic="True" CssClass="textosmall"  ></asp:Label></td>
                    <td align="center" class="textosmall" style="height: 20px; border-bottom: gray 1px solid;" ><asp:Label ID="lbl_data" runat="server" Font-Italic="True" CssClass="textosmall"  ></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" class="textosmall" style="height: 25px"></td>
                </tr>
                 <tr>
                    <td align="center" colspan="2"><img  src="img/back_fx_transvase_title.gif" id="IMG1"/></td>
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
                    <td align="center" class="textosmall" ><strong>Placa Principal</strong></td>
                    <td align="center" class="textosmall" ><strong>&nbsp;<asp:Label ID="lbl_label_rota_nota" runat="server" CssClass="textosmall" Font-Italic="False">Rota</asp:Label></strong></td>
                    <td align="center" class="textosmall" style="font-weight: bold">
                        Item</td>
                    <td align="center" class="textosmall"><strong>Volume Total</strong></td>
                    <td align="center" class="textosmall">
                        <strong>Fechamento</strong></td>
                </tr>
                 <tr>
                    <td align="center" class="textosmall" >
                        <asp:Label ID="lbl_placa" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                    <td align="center" class="textosmall" ><asp:Label ID="lbl_rota_nota" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_nm_item" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_nr_volume_total" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label></td>
                    <td align="center" class="textosmall"><asp:Label ID="lbl_dt_fechamento" runat="server" Font-Italic="True"  ></asp:Label></td>
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
                    <td align="center" class="textosmall" style="width: 55%" colspan="3" >
                        <strong>Transportador</strong></td>
                    <td align="center" class="textosmall" colspan="2">
                        <strong>Motorista</strong></td>
                </tr>
                <tr>
                    <td align="center" class="textosmall" colspan="3" >
                        <asp:Label ID="lbl_transportador" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                    <td align="center" class="textosmall" colspan="2">
                        <asp:Label ID="lbl_motorista" runat="server" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="5" class="textosmall" style="border-bottom: gray 1px solid">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
            </table>
            <table width="100%" >
                <tr>
                
                    <td align="center" valign="top" style="height: 500px" >
                        &nbsp;<anthem:GridView ID="gridTransitPoint" runat="server" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_transvase_up"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="100"
                            UpdateAfterCallBack="True" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp." ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_maximo_comp" HeaderText="Capacidade Comp.">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_litros" HeaderText="Volume Total Comp" ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_produtor_abreviado" HeaderText="Produtor" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_litros" HeaderText="Volume" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_transvase" HeaderText="Situa&#231;&#227;o TP"
                                    Visible="False">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>
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
                    <td align="center" class="textosmall"  > Responsável</td>
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