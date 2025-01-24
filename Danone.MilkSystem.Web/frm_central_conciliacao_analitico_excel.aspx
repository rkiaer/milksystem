<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_conciliacao_analitico_excel.aspx.vb" Inherits="frm_central_conciliacao_analitico_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatorio de Apoio Contabilidade Analitico</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
       <table runat="server" id="tb_header_abertos" width="100%">
    <tr>
        <td style="height: 19px; font-weight: bold; color: white; background-color: #006699;" align="left">
            <anthem:Label ID="lbl_abertos" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Size="Small">PEDIDOS PENDENTES COM SALDO EM ABERTO ANTERIORES AO PERÍODO SELECIONADO:</anthem:Label>
    </td></tr></table>
                        <anthem:GridView ID="gridAbertos" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:BoundField HeaderText="Maior Ref. Parcela" DataField="dt_referencia" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" >
                                    
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_parcelamento" HeaderText="Parcelamento" >
                                    
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="C&#243;d. SAP Parceiro" >
                                    
                                    <itemstyle horizontalalign="Center" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor Parceiro" SortExpression="nm_fornecedor" >
                                    <headerstyle wrap="True" />
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="N.o Pedido" DataFormatString="{0:n0}" >
                                    
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pedido" HeaderText="Data Pedido" SortExpression="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" >
                                    
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nota Fiscal" ReadOnly="True" DataField="nr_nota_fiscal" DataFormatString="{0:n0}" >
                                    
                                    <itemstyle wrap="False" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Valor Nota Fiscal" DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" >
                                    
                                    <itemstyle  horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Parcelas Pagto Fornecedor" DataField="nr_total_parcelas_fornecedor" >
                                    
                                    <itemstyle  font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valortotalcreditoforn" HeaderText="Total D&#233;bito" DataFormatString="{0:N2}">
                                    <headerstyle backcolor="CornflowerBlue" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP Produtor">
                                    
                                    <itemstyle horizontalalign="Center" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Nome do Produtor">
                                    
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valortotalcreditoprod" DataFormatString="{0:N2}" HeaderText="Total Cr&#233;dito"
                                    ReadOnly="True">
                                    <headerstyle backcolor="CornflowerBlue" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldonota" DataFormatString="{0:N2}" HeaderText="Saldo Nota" >
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>

        &nbsp;
           <table runat="server" id="tb_header" width="100%">
    <tr>
        <td style="height: 19px; font-weight: bold; color: white; background-color: #006699;" align="left">
            <anthem:Label ID="lbl_pedidos" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Size="Small">PEDIDOS DO PERÍODO SELECIONADO:</anthem:Label>
    </td></tr></table>
        <anthem:GridView ID="gridResultsAnalitico" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="15"
            UpdateAfterCallBack="True">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MMM/yyyy}" HeaderText="Refer&#234;ncia" />
                <asp:BoundField DataField="st_parcelamento" HeaderText="Parcelamento" >
                    
                    <itemstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="C&#243;d. SAP Fornecedor">
                    <itemstyle horizontalalign="Center" backcolor="Aquamarine" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_fornecedor" HeaderText="C&#243;d. Fornecedor Milk" >
                    
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_fornecedor" HeaderText="Nome Fornecedor Parceiro" SortExpression="nm_fornecedor" >
                    
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="id_central_pedido" HeaderText="N.o Pedido" DataFormatString="{0:n0}" >
                    
                    <itemstyle horizontalalign="Center" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_pedido" HeaderText="Data Pedido" SortExpression="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" >
                    
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Nota Fiscal" ReadOnly="True" DataField="nr_nota_fiscal" DataFormatString="{0:n0}" >
                    
                    <itemstyle wrap="False" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="S&#233;rie" Visible="False" >
                    
                    <itemstyle  horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Valor Nota Fiscal" DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" >
                    
                    <itemstyle  horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Parcelas Pagto Fornecedor" DataField="nr_total_parcelas_fornecedor" >
                    
                    <itemstyle  font-bold="False" horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Parcela Exportada" DataField="nr_parcela_fornecedor" >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Data Exporta&#231;&#227;o Pagto Fornecedor" DataField="dt_exportacao" DataFormatString="{0:dd/MM/yyyy}" >
                    
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_parcela_paga_fornecedor" HeaderText="Valor Parcela Pagamento Fornecedor" DataFormatString="{0:N2}">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP Produtor">
                    
                    <itemstyle horizontalalign="Center" backcolor="Aquamarine" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_produtor" HeaderText="Nome do Produtor">
                    
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="st_calculo_definitivo" HeaderText="C&#225;lculo" >
                    
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_nota_fiscal_ficha" HeaderText="Nota Fiscal do Leite no Milk" DataFormatString="{0:n0}" >
                    
                    <itemstyle horizontalalign="Center" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_desconto_produtor" HeaderText="Data Desconto Produtor" DataFormatString="{0:dd/MM/yyyy}" >
                    
                    <itemstyle horizontalalign="Center" wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_parcela" HeaderText="Parcela do Desconto">
                    
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_parcela_paga_produtor" HeaderText="Valor da Parcela Descontada" DataFormatString="{0:N2}">
                    <headerstyle backcolor="CornflowerBlue" />
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_saldo" HeaderText="Movimento M&#234;s" DataFormatString="{0:N2}">
                    <headerstyle backcolor="CornflowerBlue" />
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                                     <asp:BoundField DataField="saldonota" DataFormatString="{0:N2}" HeaderText="Saldo Nota" />
           
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
