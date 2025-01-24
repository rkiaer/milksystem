<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_CIQ_CIQPEmitidos.aspx.vb" Inherits="frm_relatorio_CIQ_CIQPEmitidos" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
   <title>Relatório CIQ/CIQP Emitidos</title>
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
                        Relatório CIQ/CIQP Emitidos</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small"
                            ForeColor="#333333" GridLines="None" PageSize="14" UpdateAfterCallBack="True"
                            Width="100%">
                            <FooterStyle BackColor="Silver" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Data de Entrada" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="N&#186; Romaneio" />
                                <asp:BoundField DataField="nm_rota" HeaderText="Nome Rota" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                <asp:BoundField DataField="nm_compartimento" HeaderText="Compartimento" />
                                <asp:BoundField DataField="id_romaneio_compartimento" HeaderText="N&#186; CIQ" />
                                <asp:BoundField DataField="id_romaneio_uproducao" HeaderText="N&#186; CIQP" />
                                                <asp:TemplateField HeaderText="Qtd. N&#227;o Conf.">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_total_litros" runat="server" Text='<%# Bind("nr_total_litros") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qtd. Rej.">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_litros" runat="server" Text='<%# Bind("nr_litros") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                               <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d. Produtor" />
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome Produtor" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="Unidade Produ&#231;&#227;o" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="C&#243;d. Propriedade" />
                                <asp:BoundField DataField="ds_motivo_rejeicao" HeaderText="Motivo Rejei&#231;&#227;o" />
                                <asp:BoundField DataField="ds_destino_leite" HeaderText="Destino Leite" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                        </anthem:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     <!--</div>-->
     </form>
	</body>
</HTML>