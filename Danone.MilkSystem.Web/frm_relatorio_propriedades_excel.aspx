<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_propriedades_excel.aspx.vb" Inherits="frm_relatorio_propriedades_excel" %>

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
            ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" />
                <asp:BoundField DataField="cd_contrato" HeaderText="Cod_Contrato"  />
                <asp:BoundField DataField="ds_adicional_volume" HeaderText="Adic_Volume_Calculo"  />
                <asp:BoundField DataField="dt_inicio_contrato" HeaderText="In&#237;cio Contrato" DataFormatString="{0:d}" />
                <asp:BoundField DataField="dt_fim_contrato" HeaderText="Fim Contrato" DataFormatString="{0:d}" />
                <asp:BoundField DataField="dt_rescisao" HeaderText="Rescis&#227;o Contrato" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Cod_Produtor" HeaderText="Cod_Produtor" SortExpression="Cod_Produtor" />
                <asp:BoundField DataField="Produtor" HeaderText="Produtor" SortExpression="Produtor" />
                <asp:BoundField DataField="Nome_Abrev" HeaderText="Nome_Abrev" />
                <asp:BoundField DataField="dt_nascimento" HeaderText="Nascimento" />
                <asp:BoundField DataField="CPF_Produtor" HeaderText="CPF_Produtor" />
                <asp:BoundField DataField="CNPJ_Produtor" HeaderText="CNPJ_Produtor" />
                <asp:BoundField DataField="RG_Produtor" HeaderText="RG_Produtor" />
                <asp:BoundField DataField="Estabelecimento" HeaderText="Estabelecimento" />
                <asp:BoundField DataField="CNPJ_Estab" HeaderText="CNPJ_Estab" />
                <asp:BoundField DataField="Tecnico_Danone" HeaderText="Tecnico_Danone" />
                <asp:BoundField DataField="Tecnico_Educampo" HeaderText="Tecnico_Educampo" />
                <asp:BoundField DataField="Cod_Propriedade" HeaderText="Cod_Propriedade" />
                <asp:BoundField DataField="Propriedade" HeaderText="Propriedade" />
                <asp:BoundField DataField="UP" HeaderText="UP" />
                <asp:BoundField DataField="IE_Propriedade" HeaderText="IE_Propriedade" />
                <asp:BoundField DataField="Endere&#231;o" HeaderText="Endere&#231;o" />
                <asp:BoundField DataField="Numero" HeaderText="Numero" />
                <asp:BoundField DataField="Complemento" HeaderText="Complemento" />
                <asp:BoundField DataField="Bairro" HeaderText="Bairro" />
                <asp:BoundField DataField="CEP" HeaderText="CEP" />
                <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Fone_1" HeaderText="Fone_1" />
                <asp:BoundField DataField="Fone_2" HeaderText="Fone_2" />
                <asp:BoundField DataField="E_mail" HeaderText="E_mail" />
                <asp:BoundField DataField="dt_inicio" HeaderText="Dt Inicial" />
                <asp:BoundField DataField="st_acordo_aquisicao_insumos" HeaderText="Acordo Inquisi&#231;&#227;o Insumos" />
                <asp:BoundField DataField="Considera_Qualidade" HeaderText="Considera_Qualidade" />
                <asp:BoundField DataField="Incentivo_Fiscal" HeaderText="Incentivo_Fiscal" />
                <asp:BoundField DataField="Transf_Credito" HeaderText="Transf_Credito" />
                <asp:BoundField DataField="Incentivo_21" HeaderText="Incentivo_21" />
                <asp:BoundField DataField="Incentivo_24" HeaderText="Incentivo_24" />
                <asp:BoundField DataField="Capacidade_Granel" HeaderText="Capacidade_Granel" />
                <asp:BoundField DataField="Capacidade_Ensacada" HeaderText="Capacidade_Ensacada" />
                <asp:BoundField DataField="Volume_Dia" HeaderText="Volume_Dia" />
                <asp:BoundField DataField="Qtd_Animais" HeaderText="Qtd_Animais" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
                <asp:BoundField DataField="Periodicidade_Coleta" HeaderText="Periodicidade_Coleta" />
                <asp:BoundField DataField="Tipo_Coleta" HeaderText="Tipo_Coleta" />
                <asp:BoundField DataField="Situacao" HeaderText="Situa&#231;&#227;o" />
                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" />
                <asp:BoundField DataField="ds_contato_propriedade" HeaderText="Contato Prop." />
                <asp:BoundField DataField="ds_telefone_propriedade" HeaderText="Fone Prop." />
                <asp:BoundField DataField="ds_celular_propriedade" HeaderText="Celular Prop." />
                <asp:BoundField DataField="ds_email_propriedade" HeaderText="E_mail 1 Prop." />
                <asp:BoundField DataField="ds_car" HeaderText="CAR" />
                <asp:BoundField DataField="cd_nirf" HeaderText="NIRF" />
                <asp:BoundField DataField="cd_nrp" HeaderText="NRP" />
                <asp:BoundField DataField="cd_farms" HeaderText="FARMS" />
                <asp:BoundField DataField="dt_expiracao_dqse" HeaderText="Expira&#231;&#227;o DQSE" />
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
