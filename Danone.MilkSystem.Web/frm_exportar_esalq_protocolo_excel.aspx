<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_exportar_esalq_protocolo_excel.aspx.vb" Inherits="frm_exportar_esalq_protocolo_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Exportação de Identificação de Protocolos Danone</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">

        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle Font-Names="Verdana"  />
            <HeaderStyle Font-Names="Verdana"  HorizontalAlign="Left" />
            <PagerStyle Font-Names="Verdana"  />
            <Columns>
                <asp:BoundField DataField="ds_propriedade" HeaderText="Codigo" ReadOnly="True" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" ReadOnly="True" />
                <asp:BoundField DataField="ds_cpf_cnpj" HeaderText="CPF/CNPJ"/>
                <asp:BoundField DataField="cd_nrp" HeaderText="NRP" ReadOnly="True" />
                <asp:BoundField DataField="cd_uf" HeaderText="Estado" />
                <asp:BoundField DataField="cd_protocolo_esalq" HeaderText="Protocolo" ReadOnly="True" />
                <asp:BoundField DataField="ds_tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="nm_linha" HeaderText="Linha" />
                <asp:BoundField DataField="ds_latitude" HeaderText="Latitude" />
                <asp:BoundField DataField="ds_longitude" HeaderText="Longitude" />
                <asp:BoundField DataField="ds_regional" HeaderText="Regional" />
            </Columns>
        </anthem:GridView>
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>
    </form>
</body>
</html>
