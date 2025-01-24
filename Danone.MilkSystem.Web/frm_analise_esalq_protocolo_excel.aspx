<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_analise_esalq_protocolo_excel.aspx.vb" Inherits="frm_analise_esalq_protocolo_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Identificação de Protocolos Danone</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server"
            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" DataKeyNames="id_analise_esalq_protocolo"
            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="15" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True" />
                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" />
                <asp:BoundField DataField="cd_pessoa" HeaderText="Cd Produtor" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor"  />
                <asp:BoundField DataField="id_propriedade" HeaderText="Prop."  />
                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz"  />
                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta"  />
                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"/>
                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta"  />
                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                <asp:BoundField DataField="nm_tipo_frasco" HeaderText="Frasco"  />
                <asp:BoundField DataField="cd_protocolo_esalq" HeaderText="Protocolo"  />
                <asp:BoundField DataField="st_exportacao" HeaderText="Exporta&#231;&#227;o" />
                <asp:BoundField DataField="dt_exportacao" HeaderText="Dt Exporta&#231;&#227;o"  />
                <asp:BoundField DataField="nm_arquivo" HeaderText="Nome Arquivo"  />
                <asp:BoundField DataField="dt_exportacao_1vez" HeaderText="Dt 1a Exporta&#231;&#227;o" />
                <asp:BoundField DataField="st_coleta_amostra_manual" HeaderText="Coleta Manual" />
            </Columns>
            <SelectedRowStyle BackColor="Yellow" Font-Bold="True" ForeColor="#333333" />
            <RowStyle BackColor="#EFF3FB" />
        </anthem:GridView>
        &nbsp;
        &nbsp; &nbsp;<br />
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
