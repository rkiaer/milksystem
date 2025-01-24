<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pagto_conciliacao_excel.aspx.vb" Inherits="frm_central_pagto_conciliacao_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatorio de Apoio - Conciliação Pagamento Central de Compras</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridAbertos" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="20" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" ReadOnly="True">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_pessoa" HeaderText="Cd Produtor">
                    <itemstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Produtor">
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_tecnico" HeaderText="Tec.Danone">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_educampo" HeaderText="Tec.Educampo">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_conquali" HeaderText="Tec.ConQuali">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="Cod.SAP Parceiro">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Fornecedor" SortExpression="nm_abreviado_fornecedor">
                    <headerstyle wrap="True" />
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_item" HeaderText="Cod.Item" />
                <asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o" />
                <asp:BoundField DataField="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Pedido"
                    SortExpression="dt_pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:N2}" HeaderText="Total Pedido">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_emissao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emiss&#227;o">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nota Fiscal"
                    ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" HeaderText="Valor Nota Fiscal">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="id_central_pedido" DataFormatString="{0:n0}" HeaderText="N.o Pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="st_tipo_parcelamento" HeaderText="Tipo Parc.">
                    <itemstyle font-bold="False" horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_qtde_parcelas" HeaderText="Parcelas">
                    <itemstyle font-bold="False" horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="f1" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f1">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f2" DataFormatString="{0:N2}" HeaderText="f2">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f3" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f3">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f4" DataFormatString="{0:N2}" HeaderText="f4">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f5" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f5">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f6" DataFormatString="{0:N2}" HeaderText="f6">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f7" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f7">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f8" DataFormatString="{0:N2}" HeaderText="f8">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f9" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f9">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f10" DataFormatString="{0:N2}" HeaderText="f10">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f11" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f11">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f12" DataFormatString="{0:N2}" HeaderText="f12">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f13" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f13">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f14" DataFormatString="{0:N2}" HeaderText="f14">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f15" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f15">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f16" DataFormatString="{0:N2}" HeaderText="f16">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f17" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f17">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f18" DataFormatString="{0:N2}" HeaderText="f18">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f19" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f19">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f20" DataFormatString="{0:N2}" HeaderText="f20">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f21" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f21">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f22" DataFormatString="{0:N2}" HeaderText="f22">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f23" DataFormatString="{0:dd/MM/yyyy}" HeaderText="f23">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="f24" DataFormatString="{0:N2}" HeaderText="f24">
                    <itemstyle backcolor="LightSkyBlue" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="totalpagofornec" DataFormatString="{0:N2}" HeaderText="Total Pago Parceiro">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_fornec_nota" DataFormatString="{0:N2}" HeaderText="Pagto X Nota">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="p1" DataFormatString="{0:N2}" HeaderText="p1">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p2" DataFormatString="{0:N2}" HeaderText="p2">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p3" DataFormatString="{0:N2}" HeaderText="p3">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p4" DataFormatString="{0:N2}" HeaderText="p4">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p5" DataFormatString="{0:N2}" HeaderText="p5">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p6" DataFormatString="{0:N2}" HeaderText="p6">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p7" DataFormatString="{0:N2}" HeaderText="p7">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p8" DataFormatString="{0:N2}" HeaderText="p8">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p9" DataFormatString="{0:N2}" HeaderText="p9">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p10" DataFormatString="{0:N2}" HeaderText="p10">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p11" DataFormatString="{0:N2}" HeaderText="p11">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="p12" DataFormatString="{0:N2}" HeaderText="p12">
                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="totalpagoprod" DataFormatString="{0:N2}" HeaderText="Total Desc. Produtor"
                    ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_saldo" DataFormatString="{0:N2}" HeaderText="Saldo">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_unitario" DataFormatString="{0:n2}" HeaderText="Valor Unitário">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                 <asp:BoundField DataField="nr_quantidade_pedido" DataFormatString="{0:n0}" HeaderText="Qtde Pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_notas" DataFormatString="{0:n2}" HeaderText="Total NF Pedido">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                 <asp:BoundField DataField="nr_quantidade_real_pedido" DataFormatString="{0:n0}" HeaderText="Qtde Real Pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>                
                
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
