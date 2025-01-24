<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_mapa_limite_incentivo_excel.aspx.vb" Inherits="frm_mapa_limite_incentivo_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Mapa Limite Incentivo</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    <table runat="server" id="tb_header" width="100%">
    <tr>
        <td style="height: 19px; font-weight: bold; color: white; background-color: #006699;" align="center">
            <anthem:Label ID="lbl_flash" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">MAPA LIMITE INCENTIVO 2021</anthem:Label>
    </td></tr></table>
                        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
<FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"></FooterStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Left" BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"></PagerStyle>
<Columns>
<asp:BoundField DataField="id_propriedade_matriz" HeaderText="Matriz"></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_tit" HeaderText="Prod Matriz"></asp:BoundField>
<asp:BoundField DataField="id_propriedade" HeaderText="Prop."></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_prod" HeaderText="Produtor"></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_tecnico" HeaderText="EPL" ShowHeader="False"></asp:BoundField>
<asp:BoundField DataField="nr_valor_1" HeaderText="Janeiro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_2" HeaderText="Fevereiro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_3" HeaderText="Mar&#231;o">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_4" HeaderText="Abril">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_5" HeaderText="Maio" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False" Font-Italic="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_6" HeaderText="Junho">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_7" HeaderText="Julho">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_8" HeaderText="Agosto">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_9" HeaderText="Setembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_10" HeaderText="Outubro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_11" HeaderText="Novembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_12" HeaderText="Dezembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Volume Total"><ItemTemplate>
<asp:Label id="lbl_volumetotal" runat="server" Text='<%# Bind("nr_volume_ano_por_prop") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Saldo Limite Incentivo"><ItemTemplate>
<asp:Label id="lbl_nr_saldo_limite" runat="server" Text='<%# Bind("nr_saldo_limite_ano_por_prop") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="volumeprojetado" Visible="False"><ItemTemplate>
<asp:Label id="lbl_volumeprojetado" runat="server" Text='<%# Bind("nr_volume_projetado") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="propordenacao" Visible="False"><ItemTemplate>
<asp:Label id="lbl_propordenacao" runat="server" Text='<%# Bind("id_propriedade_ordenacao") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False"><ItemTemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

<RowStyle ForeColor="#000066"></RowStyle>
</anthem:GridView>
           &nbsp;<br />
        <anthem:Label runat="server" ID="lbl_informativo"  AutoUpdateAfterCallBack="True"
            CssClass="Texto" Font-Italic="True" Font-Size="X-Small" ForeColor="Blue" Height="16px"
            UpdateAfterCallBack="True" Visible="False">*Mês em destaque indicando PAGAMENTO PROVISÓRIO. Sujeito à alterações no fechamento de cálculo.</anthem:Label>
        &nbsp;<br />
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
