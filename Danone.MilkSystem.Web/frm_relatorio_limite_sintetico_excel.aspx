<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_limite_sintetico_excel.aspx.vb" Inherits="frm_relatorio_limite_sintetico_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                            <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d.Prod." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                               <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" >
                                   <headerstyle horizontalalign="Center" />
                                   <itemstyle horizontalalign="Left" />
                               </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="volume" HeaderText="Volume Mes" DataFormatString="{0:N0}" >
                                     <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Valor Mes Estim." DataField="valorestimado" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valor_rendimento" DataFormatString="{0:N2}"
                                    HeaderText="Rend.M-1">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="limitebruto" DataFormatString="{0:N2}" HeaderText="Total Limite 150%">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Desc. M&#234;s Atual" DataField="desconto_lancamento" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Desc. Adto" DataField="desconto_adiantamento" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_contas_parceladas" DataFormatString="{0:N2}"
                                    HeaderText="Desc Conta Parc." ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_parcelado_danone" HeaderText="Parc.Central" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_aberto" HeaderText="Ped Abertos" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="desconto_fin_parcial" HeaderText="Fin.Parcial" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                               <asp:BoundField HeaderText="Total Desc." DataField="totaldesconto" DataFormatString="{0:N2}" >
                                    <headerstyle wrap="True" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Limite Disp." DataField="nr_limite_mes_liquido" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_tecnico" HeaderText="C&#243;d.EPL" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" SortExpression="nm_tecnico" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>


             </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                                                

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
