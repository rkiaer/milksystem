<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_contrato_excel.aspx.vb" Inherits="frm_central_pedido_contrato_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Central de Compras - Pedidos de Contrato</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridpedidos" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" CellPadding="3" CssClass="texto" Font-Names="Verdana"
            Font-Size="X-Small" ForeColor="#333333" PageSize="100" UpdateAfterCallBack="True"
            Visible="False" Width="98%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" />
            <HeaderStyle BackColor="SteelBlue" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                ForeColor="White" Height="24px" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_central_contrato" HeaderText="Contrato" />
                <asp:BoundField DataField="ds_descricao_contrato" HeaderText="Descri&#231;&#227;o">
                    <headerstyle wrap="False" />
                    <itemstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_periodo_contrato" HeaderText="Per&#237;odo" />
                <asp:BoundField DataField="nm_situacao_central_contrato" HeaderText="Sit.Contrato" />
                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Parceiro Insumos">
                    <headerstyle wrap="False" />
                    <itemstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpj_cpf_fornecedor" HeaderText="CNPJ/CPF">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_fornecedor" HeaderText="Cd.Milk" />
                <asp:BoundField DataField="cd_sap_fornecedor" HeaderText="Cd.SAP" />
                <asp:BoundField DataField="cd_item" HeaderText="Cd.Item">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_item" HeaderText="Nome Item">
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_quantidade_total" DataFormatString="{0:n}" HeaderText="Qtde Total">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_unitario" DataFormatString="{0:n2}" HeaderText="Vl Unit.">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_sacaria" DataFormatString="{0:n2}" HeaderText="Vl Sacaria">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_pessoa" HeaderText="Cd.Produtor" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" >
                    <itemstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Nome Abreviado">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_pedido" DataFormatString="{0:d}" HeaderText="Data"
                    ReadOnly="True">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="st_pedido_indireto" HeaderText="Ped.Indireto">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_nm_tipo_medida" HeaderText="Tipo">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_quantidade" DataFormatString="{0:n}" HeaderText="Qtde">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_parcelas" HeaderText="Parcelado?">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:n2}" HeaderText="Total Pedido">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Sit.Pedido">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_nmtipofrete" HeaderText="Tipo Frete">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador">
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp." />
                <asp:BoundField DataField="id_central_pedido_frete" HeaderText="Ped.Frete">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_pedido_frete" DataFormatString="{0:n2}" HeaderText="Total Ped.Frete">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_situacao_pedido_frete" HeaderText="Sit.Frete">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
