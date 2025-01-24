<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_cooperativa_sl0013_excel.aspx.vb" Inherits="frm_cooperativa_sl0013_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Romaneios - Controle de Frete</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None"  Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                <asp:BoundField HeaderText="C&#243;d.SAP" DataField="cd_codigo_sap" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Cooperativa" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Dt.Entrada" DataFormatString="{0:dd/MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso Balan&#231;a" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Dens (g/ml)" DataFormatString="{0:n4}" DataField="nr_valor_dens" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pesoemlitros" DataFormatString="{0:n0}" HeaderText="Volume (lts)" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_saida_nota" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nr.NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume NF" DataField="nr_peso_liquido_nota" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:n2}" HeaderText="Valor NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataFormatString="{0:n2}" HeaderText="R$/L" DataField="nr_valor_por_litro" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-NF (lts)" DataField="nr_variacao_volume" DataFormatString="{0:n0}" >
                                    <headerstyle width="5%" wrap="True" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_exportacao_batch" HeaderText="Export. Batch">
                                    <headerstyle horizontalalign="Center" width="5%" wrap="True" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_po" HeaderText="PO-Batch" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="volumerejeitado" DataFormatString="{0:n0}" HeaderText="Volume Rejeitado" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
             </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                                <asp:GridView ID="gridResultsSint" runat="server" 
                            AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="100%" >
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
             <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField HeaderText="C&#243;d.SAP" DataField="cd_codigo_sap" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Cooperativa" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Resumido">
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="somapesoemlitros" DataFormatString="{0:n0}" HeaderText="Soma Volume (lts)" >
                                    <headerstyle horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Soma Volume NF" DataField="somapesonota" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-NF (lts)" DataField="somavariacao" DataFormatString="{0:n0}" >
                                    <headerstyle wrap="True" horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_po" HeaderText="PO-Batch" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_nf_complemento" HeaderText="NF Compl.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_carta_credito" HeaderText="Carta Cr&#233;dito">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                            </Columns>
                                        </asp:GridView>

                                                

        &nbsp;
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
