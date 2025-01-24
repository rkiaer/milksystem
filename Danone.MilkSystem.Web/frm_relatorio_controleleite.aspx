<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_controleleite.aspx.vb" Inherits="frm_relatorio_controleleite" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Controle Leite</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="2" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        CONTROLE DE RECEPÇÃO DE LEITE</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2"><asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td align="center" class="texto" colspan="2">
                       Data:
                        <asp:Label ID="lbl_data_ini" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>&nbsp; 
                         </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px" DataKeyNames="id_romaneio_compartimento" ShowFooter="True">
                                                    <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="N.o" />
                                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                        <asp:BoundField HeaderText="Rota" DataField="rota" />
                                                        <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" />
                                                        <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." />
                                                        <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Chegada" />
                                                        <asp:BoundField DataField="dt_fim_descarga" HeaderText="Hr Desc" />
                                                        <asp:BoundField DataField="dt_ini_CIP" HeaderText="Hr CIP" />
                                                        <asp:BoundField DataField="nr_ph_solucao" HeaderText="PH Fim" />
                                                        <asp:BoundField DataField="peso_liquido_balanca" HeaderText="Peso Balan&#231;a" />
                                                        <asp:BoundField HeaderText="Dens(g/ml)" />
                                                        <asp:BoundField HeaderText="Volume(lts)" />
                                                        <asp:BoundField HeaderText="MG(%)" />
                                                        <asp:BoundField HeaderText="Volume Caderneta(lts)" DataField="nr_litros_compartimento" />
                                                        <asp:BoundField HeaderText="Variacao Vol Real-Cader(lts)" />
                                                        <asp:BoundField DataField="ds_nr_silo" HeaderText="Destino Leite Cru" />
                                                        <asp:BoundField DataField="dt_entrada" HeaderText="Dt.Entrada" />
                                                        <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" />
                                                        <asp:BoundField DataField="nm_divergencia_km_frete" HeaderText="Diverg&#234;ncias" />
                                                        <asp:BoundField DataField="nm_aprovacao_km_frete" HeaderText="Aprova&#231;&#227;o" />
                                                    </Columns>
                                                    <RowStyle BackColor="White" />
                                                </anthem:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        <br />
            <!--<div id="corpo" style="text-align:center;vertical-align:top;">-->
                &nbsp;
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     <!--</div>-->
     </form>
	</body>
</HTML>