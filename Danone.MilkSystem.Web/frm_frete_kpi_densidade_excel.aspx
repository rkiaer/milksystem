<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_kpi_densidade_excel.aspx.vb" Inherits="frm_frete_kpi_densidade_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Frete KPI - Densidade</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView id="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" HorizontalAlign="Center" ShowFooter="True">
            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro" ForeColor="Red" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
            <Columns>
                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="dt_referencia" DataFormatString="{0:MM/yyyy}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transportador" >
                    <headerstyle wrap="False" horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_frete" HeaderText="Tipo Frete" >
                    <headerstyle horizontalalign="Center" wrap="False" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                <asp:BoundField DataField="dt_hora_entrada" DataFormatString="{0:dd/MM/yyyy hh:mm}" HeaderText="Dt_Entrada" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_linha" HeaderText="Rota" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_eixo" HeaderText="Nr.Eixo" >
                    <headerstyle wrap="True" horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="volumeplaca1" DataFormatString="{0:N0}" HeaderText="Capacidade Placa">
                    <footerstyle horizontalalign="Center" />
                    <headerstyle horizontalalign="Center" wrap="False" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_placa2" HeaderText="2a Placa">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="volumeplaca2" DataFormatString="{0:N0}" HeaderText="Capacidade 2a Placa">
                    <footerstyle horizontalalign="Center" />
                    <headerstyle horizontalalign="Center" wrap="False" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume" HeaderText="Volume Rota" DataFormatString="{0:N0}" >
                    <footerstyle horizontalalign="Right" />
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" DataFormatString="{0:N0}" >
                    <footerstyle horizontalalign="Right" />
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="capacidadetotal" HeaderText="Capacidade Total" DataFormatString="{0:N0}" >
                    <footerstyle horizontalalign="Center" />
                    <headerstyle horizontalalign="Center" wrap="False" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_densidade" HeaderText="Densidade" DataFormatString="{0:N0}" >
                    <footerstyle horizontalalign="Center" />
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_taxa_ocupacao" HeaderText="Tx Ocupa&#231;&#227;o %" DataFormatString="{0:N2}" >
                    <footerstyle horizontalalign="Center" />
                    <headerstyle horizontalalign="Center" wrap="False" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        &nbsp;
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
