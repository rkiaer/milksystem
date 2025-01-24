<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_analise_esalq_excel.aspx.vb" Inherits="frm_analise_esalq_excel" %>

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
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" Visible="False">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta"  />
                                <asp:BoundField DataField="dt_processamento" HeaderText="Data Processamento"  />
                                <asp:BoundField DataField="dt_analise" HeaderText="Data An&#225;lise"  >
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado da An&#225;lise"/>
                                <asp:BoundField DataField="nm_st_analise" HeaderText="Status" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
              </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:GridView ID="gridResultsCoop" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" Visible="False">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                                <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Coop" />
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Resumido" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nota Fiscal" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta"  />
                                <asp:BoundField DataField="dt_analise" HeaderText="Data An&#225;lise"  >
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado da An&#225;lise"/>
                                <asp:BoundField DataField="nm_st_analise" HeaderText="Status" />
                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
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
