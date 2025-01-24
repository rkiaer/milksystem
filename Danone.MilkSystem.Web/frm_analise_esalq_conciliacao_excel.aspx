<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_analise_esalq_conciliacao_excel.aspx.vb" Inherits="frm_analise_esalq_conciliacao_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

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
           <anthem:GridView id="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_analise_esalq">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data An&#225;lise" DataField="dt_analise" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tipo Coleta" DataField="nm_tipo_coleta_analise_esalq" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" >
                                    <headerstyle width="5%" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_media_mg" HeaderText="M&#233;dia MG" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_variacao_mg" HeaderText="Var MG" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_transferencia" HeaderText="Transf." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Consist&#234;ncias">
                                    <itemtemplate>
<anthem:Label id="lbl_consistencias" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w11" Text='<%# Bind("nm_situacao_analise_esalq") %>' CssClass="texto"></anthem:Label><anthem:Label id="lbl_detalhes" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w12" Text="Erros" CssClass="texto" Visible="False"></anthem:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Aprova&#231;&#227;o" DataField="nm_aprovacao_analise_esalq" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="id_analise_esalq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_analise_esalq" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_analise_esalq") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
