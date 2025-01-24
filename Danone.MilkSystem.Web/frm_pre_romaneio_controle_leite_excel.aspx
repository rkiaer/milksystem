<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pre_romaneio_controle_leite_excel.aspx.vb" Inherits="frm_pre_romaneio_controle_leite_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Controle de Recepção de Leite Pré Romaneios</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transp" >
                                    <itemstyle horizontalalign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" >
                                    <itemstyle horizontalalign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="rota" HeaderText="Rota" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Pr&#233; Romaneio" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada" HeaderText="Entrada" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Entr." >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_saida" HeaderText="Sa&#237;da" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_saida" HeaderText="Hr Sa&#237;da" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="peso_liquido_balanca" HeaderText="Peso Balan&#231;a" >
                                    <itemstyle horizontalalign="Right" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_densidade" HeaderText="Densidade" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume" HeaderText="Volume" DataFormatString="{0:N0}" >
                                    <itemstyle horizontalalign="Right" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_caderneta" HeaderText="Volume Caderneta" DataFormatString="{0:N0}" >
                                    <itemstyle horizontalalign="Right" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_variacao_volume" HeaderText="Varia&#231;&#227;o Volume" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_divergencia" HeaderText="Diverg&#234;ncia" >
                                    <itemstyle horizontalalign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_aprovacao" HeaderText="Aprova&#231;&#227;o" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o Romaneio" >
                                    <itemstyle horizontalalign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada_romaneio" HeaderText="Entrada Romaneio" >
                                    <itemstyle horizontalalign="Center" Wrap="False" />
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
