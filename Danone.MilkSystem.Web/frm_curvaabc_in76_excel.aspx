<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_in76_excel.aspx.vb" Inherits="frm_curvaabc_in76_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Curva ABC IN76 Desligamento</title>
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
                                <asp:BoundField HeaderText="Propriedade" DataField="id_propriedade" />
                                 <asp:BoundField DataField="tipopropriedade" HeaderText="Tipo" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                               <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d. Produtor" >
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" />
                                <asp:BoundField DataField="nm_tecnico_epl" HeaderText="EPL" />
                                <asp:BoundField DataField="nm_epl" HeaderText="Nome EPL" />
                                <asp:BoundField DataField="nm_tecnico_educampo" HeaderText="Educampo" />
                                <asp:BoundField DataField="nm_educampo" HeaderText="Nome Educampo" />
                                <asp:BoundField DataField="nm_tecnico_conquali" HeaderText="ComQuali" />
                                <asp:BoundField DataField="nm_conquali" HeaderText="Nome ComQuali" />
                                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" >
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_transferencia" HeaderText="Transf." />
                                <asp:BoundField HeaderText="Volume" DataField="nr_volume" >
                                     <itemstyle wrap="False" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal2" runat="server" __designer:wfdid="w26" text="mes2"></asp:Label> Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm2" runat="server" __designer:wfdid="w25" Text='<%# Bind("nr_teor_cbt2") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="MistyRose" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl2" >
                                    <itemstyle backcolor="MistyRose" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal1" runat="server" __designer:wfdid="w28" Text="mes1"></asp:Label> Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm1" runat="server" __designer:wfdid="w27" Text='<%# Bind("nr_teor_cbt1") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="PaleTurquoise" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl1" >
                                    <itemstyle backcolor="PaleTurquoise" horizontalalign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal" runat="server" __designer:wfdid="w30" Text="mes"></asp:Label> Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm" runat="server" __designer:wfdid="w29" Text='<%# Bind("nr_teor_cbt") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#CCCCFF" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl" >
                                    <itemstyle backcolor="#CCCCFF" font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Amostra">
                                    <headertemplate>
<asp:Label id="lbl_menor_amostra_mes" runat="server" __designer:wfdid="w32" Text='<%# Bind("nr_teor_ccs_mensal1") %>'></asp:Label>&nbsp;Amostra 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_menoresalq" runat="server" __designer:wfdid="w31" Text='<%# Bind("nr_valor_menor_esalq_cbt") %>'></asp:Label> 
</itemtemplate>
                                    <itemstyle backcolor="LightCyan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl_analise" >
                                    <itemstyle backcolor="LightCyan" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="A&#231;&#227;o" DataField="dsacao" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nrcomplcbt" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt" runat="server" __designer:wfdid="w33" Text='<%# Bind("nrcomplcbt") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nrcomplcbt1" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt1" runat="server" Text='<%# Bind("nrcomplcbt1") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nrcomplcbt2" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt2" runat="server" Text='<%# Bind("nrcomplcbt2") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nranalisecomplcbt" Visible="False">
                                    <itemtemplate>
<asp:Label id="nranalisecomplcbt" runat="server" Text='<%# Bind("nranalisecomplcbt") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>

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
