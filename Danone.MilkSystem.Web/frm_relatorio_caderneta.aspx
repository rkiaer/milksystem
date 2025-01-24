<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_caderneta.aspx.vb" Inherits="frm_relatorio_caderneta" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Motoristas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel" style="text-align:center; ">
            <table class="texto" width="100%" style="text-align:center; ">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="4" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        caderneta</td>
                </tr>
                <tr>
                    <td align="right" class="texto" style=" width: 30%">Data Coleta:</td>
                    <td align="left" class="texto" ><asp:Label ID="lbl_data_coleta" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label></td>
                    <td align="right" class="texto" >Placa:</td>
                    <td align="left" class="texto" ><asp:Label ID="lbl_placa" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="texto" >CNH:</td>
                    <td align="left" class="texto"  ><asp:Label ID="lbl_cnh" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label></td>
                    <td align="right" class="texto" >Tipo Rota:</td>
                    <td align="left" class="texto" ><asp:Label ID="lbl_tipo_rota" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="5">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px">
                                                    <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="nr_ordem" HeaderText="Seq" />
                                                        <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                                        <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" />
                                                        <asp:BoundField DataField="nr_unid_producao" HeaderText="U.Prod." />
                                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                        <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." />
                                                        <asp:BoundField DataField="nr_volume" HeaderText="Litros" />
                                                        <asp:BoundField DataField="nr_temperatura" HeaderText="Temp." />
                                                        <asp:BoundField DataField="nm_alizarol" HeaderText="Alizarol" />
                                                        <asp:BoundField DataField="nm_motivo_nao_coleta" HeaderText="Motivo N&#227;o Coleta" />
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