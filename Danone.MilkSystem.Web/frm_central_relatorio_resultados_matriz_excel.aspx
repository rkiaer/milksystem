<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_relatorio_resultados_matriz_excel.aspx.vb" Inherits="frm_central_relatorio_resultados_matriz_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatorio Resultados Analitico Matriz Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="3" ShowFooter="True" Width="100%" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <RowStyle HorizontalAlign="Center" ForeColor="#000066" />
                                            <Columns>
                                                <asp:BoundField DataField="nr_ano_referencia" HeaderText="Ano">
                                                    <headerstyle horizontalalign="Center" wrap="True" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_mes_referencia" HeaderText="M&#234;s">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" DataFormatString="{0:MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_produtor" HeaderText="Cod.Produtor">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Propriedade">
                                                    <itemtemplate>
<asp:Label id="lbl_propriedade" runat="server" __designer:wfdid="w6" Text='<%# Bind("propriedade") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="T&#233;cnico">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_tecnico" HeaderText="Tecnico Abreviado">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_cidade" HeaderText="Cidade">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_latitude" HeaderText="Latitude" />
                                                <asp:BoundField DataField="nr_longitude" HeaderText="Longitude" />
                                                <asp:BoundField DataField="nm_tecnico_educampo" HeaderText="Educampo" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_matriz" HeaderText="Volume M&#234;s" DataFormatString="{0:N0}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_dia" DataFormatString="{0:N0}" HeaderText="Volume Dia">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_consumo_central" HeaderText="Consumo Central">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_fichacompedido" HeaderText="Desconto?">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_milho" DataFormatString="{0:N4}" HeaderText="Qtde Milho/Fuba">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_milho" HeaderText="Spend Milho/Fuba" DataFormatString="{0:N2}">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Milho/Fuba">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_milho" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_fornecedor_milho") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_qtde_algodao" DataFormatString="{0:N4}" HeaderText="Qtde Farelo/Caro&#231;o Algod&#227;o">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_algodao" HeaderText="Spend Farelo/Caro&#231;o Algod&#227;o" DataFormatString="{0:N2}">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Farelo/Caro&#231;o Algod&#227;o">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_algodao" runat="server" __designer:wfdid="w13" Text='<%# Bind("nm_fornecedor_algodao") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_qtde_polpacitrica" DataFormatString="{0:N4}" HeaderText="Qtde Polpa C&#237;trica">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_polpacitrica" HeaderText="Spend Polpa C&#237;trica" DataFormatString="{0:N2}">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Polpa C&#237;trica">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_polpa" runat="server" __designer:wfdid="w14" Text='<%# Bind("nm_fornecedor_polpacitrica") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_qtde_soja" DataFormatString="{0:N4}" HeaderText="Qtde Soja">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_soja" HeaderText="Spend Soja" DataFormatString="{0:N2}">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Soja">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_soja" runat="server" __designer:wfdid="w9" Text='<%# Bind("nm_fornecedor_soja") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_qtde_casca" DataFormatString="{0:N4}" HeaderText="Qtde Casca Soja">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_casca" DataFormatString="{0:N2}" HeaderText="Spend Casca Soja">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Casca Soja">
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_casca" runat="server" __designer:wfdid="w9" Text='<%# Bind("nm_fornecedor_casca") %>'></asp:Label>
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_valor_outros" DataFormatString="{0:N2}" HeaderText="Spend Outros">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fornecedor Outros">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_fornecedor_outros" runat="server" __designer:wfdid="w18" Text='<%# Bind("nm_fornecedor_outros") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Left" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_referencia" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" __designer:wfdid="w2" Text='<%# Bind("dt_referencia") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
