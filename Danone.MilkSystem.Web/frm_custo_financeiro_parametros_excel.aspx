<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_custo_financeiro_parametros_excel.aspx.vb" Inherits="frm_custo_financeiro_parametros_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo Financeiro Parametros</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"  GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"
                             UpdateAfterCallBack="True" PageSize="100" DataKeyNames="id_custo_financeiro">
                            <Columns>
                                 <asp:BoundField DataField="nr_ano" HeaderText="Ano Referência" ReadOnly="True"  >
                                     <itemstyle horizontalalign="Center" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="st_sistema" HeaderText="Obrig." ReadOnly="True"  >
                                     <itemstyle horizontalalign="Center" />
                                 </asp:BoundField>
                               <asp:BoundField DataField="nm_tipo_custo_financeiro" HeaderText="Tipo Custo" />
                                <asp:BoundField DataField="nr_valor_01" HeaderText="Janeiro" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_02" HeaderText="Fevereiro" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_03" HeaderText="Mar&#231;o" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_04" HeaderText="Abril" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Maio" ReadOnly="True" DataField="nr_valor_05" DataFormatString="{0:N4}" >
                                    <itemstyle wrap="False" horizontalalign="Right"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_06" HeaderText="Junho" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_07" HeaderText="Julho" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_08" HeaderText="Agosto" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_09" HeaderText="Setembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_10" HeaderText="Outubro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_11" HeaderText="Novembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_12" HeaderText="Dezembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="id_tipo_custo_financeiro" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_custo_financeiro" runat="server" Text='<%# Bind("id_tipo_custo_financeiro") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
        </anthem:GridView>
        &nbsp;<br />
        &nbsp; &nbsp;

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
