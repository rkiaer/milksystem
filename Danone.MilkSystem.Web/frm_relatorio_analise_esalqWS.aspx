<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_analise_esalqWS.aspx.vb" Inherits="frm_relatorio_analise_esalqWS" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Análises Esalq Propriedade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="rel_fisico_quimico">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="2" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        RELATÓRIO DE DADOS RECEBIDOS DA CLÍNICA DO LEITE
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2"></td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2"></td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px">
                                                    <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="id_importacao" HeaderText="Nr.Exec." />
                                                        <asp:BoundField DataField="accountcode" HeaderText="accountcode" >
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="accountid" HeaderText="accountid" />
                                                        <asp:BoundField DataField="accountname" HeaderText="accountname" >
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="analyse_atb_delvo" HeaderText="analyse_atb_delvo" />
                                                        <asp:BoundField DataField="analyse_cas" HeaderText="analyse_cas" />
                                                        <asp:BoundField DataField="analyse_cbt" HeaderText="analyse_cbt" />
                                                        <asp:BoundField DataField="analyse_ccs" HeaderText="analyse_ccs" />
                                                        <asp:BoundField DataField="analyse_cri" HeaderText="analyse_cri" />
                                                        <asp:BoundField DataField="analyse_ea" HeaderText="analyse_ea" />
                                                        <asp:BoundField DataField="analyse_esd" HeaderText="analyse_esd" />
                                                        <asp:BoundField DataField="analyse_gor" HeaderText="analyse_gor" />
                                                        <asp:BoundField DataField="analyse_id" HeaderText="analyse_id" />
                                                        <asp:BoundField DataField="analyse_lact" HeaderText="analyse_lact" />
                                                        <asp:BoundField DataField="analyse_nu" HeaderText="analyse_nu" />
                                                        <asp:BoundField DataField="analyse_pagl" HeaderText="analyse_pagl" />
                                                        <asp:BoundField DataField="analyse_pcas" HeaderText="analyse_pcas" />
                                                        <asp:BoundField DataField="analyse_prot" HeaderText="analyse_prot" />
                                                        <asp:BoundField DataField="analyse_protocol" HeaderText="analyse_protocol" />
                                                        <asp:BoundField DataField="analyse_st" HeaderText="analyse_st" />
                                                        <asp:BoundField DataField="analyse_ua_code" HeaderText="analyse_ua_code" />
                                                        <asp:BoundField DataField="analyse_ua_line" HeaderText="analyse_ua_line" />
                                                        <asp:BoundField DataField="analyse_ua_name" HeaderText="analyse_ua_name" />
                                                        <asp:BoundField DataField="analyse_ua_nrp" HeaderText="analyse_ua_nrp" />
                                                        <asp:BoundField DataField="analyse_ua_regional" HeaderText="analyse_ua_regional" />
                                                        <asp:BoundField DataField="analyse_ua_type" HeaderText="analyse_ua_type" />
                                                        <asp:BoundField DataField="analyse_ua_ua_id" HeaderText="analyse_ua_ua_id" />
                                                        <asp:BoundField DataField="analysis_date" HeaderText="analysis_date" />
                                                        <asp:BoundField DataField="collection_date" HeaderText="collection_date" />
                                                        <asp:BoundField DataField="id" HeaderText="id" />
                                                        <asp:BoundField DataField="os_code" HeaderText="os_code" />
                                                        <asp:BoundField DataField="processing_date" HeaderText="processing_date" />
                                                        <asp:BoundField DataField="receive_date" HeaderText="receive_date" />
                                                        <asp:BoundField DataField="dt_criacao" HeaderText="dt_criacao" />

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