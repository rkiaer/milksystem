<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_produtores_complience_excel.aspx.vb" Inherits="frm_curvaabc_produtores_complience_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Curva ABC Pagamento Produtores</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
           <anthem:GridView id="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" />
                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d. Produtor" >
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop. Matriz" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" />
                                <asp:BoundField DataField="nm_tecnico_epl" HeaderText="EPL" />
                                <asp:BoundField DataField="nm_tecnico_educampo" HeaderText="Educampo" />
                                <asp:BoundField DataField="nm_tecnico_conquali" HeaderText="ConQuali" />
                                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" >
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_transferencia" HeaderText="Transf." />
                                <asp:BoundField HeaderText="Volume" DataField="nr_volume" >
                                     <itemstyle wrap="False" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal2" runat="server" Text='<%# Bind("nr_teor_ctm_mensal2") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal1" runat="server" Text='<%# Bind("nr_teor_ctm_mensal1") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal1" runat="server" Text='<%# Bind("nr_teor_ctm_mensal1") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal" runat="server" Text='<%# Bind("nr_teor_ctm_mensal") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal" runat="server" Text='<%# Bind("nr_teor_ctm_mensal") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_teor_ctm" HeaderText="Teor CBT Trim." >
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_ctm_complience" HeaderText="Compliance CBT" >
                                    <itemstyle backcolor="Tan" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal2") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal2") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal1" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal1" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal" runat="server" Text='<%# Bind("nr_teor_ccs_mensal") %>'></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal" runat="server" Text='<%# Bind("nr_teor_ccs_mensal") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_teor_ccs" HeaderText="Teor CCS Trim." >
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_ccs_complience" HeaderText="Compliance CCS" >
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_proteina" HeaderText="Teor Prot." >
                                    <itemstyle backcolor="#C0C0FF" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_proteina_complience" HeaderText="Compliance Prot " >
                                    <itemstyle backcolor="#C0C0FF" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_gordura" HeaderText="Teor Gordura" >
                                    <itemstyle backcolor="#FFE0C0" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_gordura_complience" HeaderText="Compliance Gord." >
                                    <itemstyle backcolor="#FFE0C0" horizontalalign="Center" />
                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                                        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
