<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_gestao_qualidade_dados_epl_excel.aspx.vb" Inherits="frm_gestao_qualidade_dados_epl_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Gestão Qualidade - Base de Dados EPLs</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    <table runat="server" id="tb_mg" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_mg" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Gordura</anthem:Label>
    </td></tr></table>
        <anthem:GridView ID="gridGordura" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
            UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_mg" runat="server" __designer:wfdid="w20" text="DAL"></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_mg" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w19"></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_mg" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_mg" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_mg" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_mg" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_mg" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_mg" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_mg" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_mg" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_mg" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_mg" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_mg" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_mg" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_mg" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_mg"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
    <table runat="server" id="tb_prot" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_prot" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Proteína</anthem:Label>
    </td></tr></table>
            <anthem:GridView ID="gridProteina" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center"
            PageSize="5" UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_prot" runat="server" Text='DAL'></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_prot" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" width="12%" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_prot" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_prot" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_prot" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_prot" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_prot" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_prot" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_prot" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_prot" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_prot" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_prot" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_prot" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_prot" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_prot" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_prot"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
    <table runat="server" id="tb_ccs" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_ccs" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">CCS</anthem:Label>
    </td></tr></table>
        <anthem:GridView ID="gridCCS" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center"
            PageSize="5" UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_ccs" runat="server" Text='DAL'></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_ccs" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" width="12%" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_ccs" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_ccs" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_ccs" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_ccs" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_ccs" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_ccs" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_ccs" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_ccs" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_ccs" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_ccs" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_ccs" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_ccs" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_ccs" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_ccs"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
     <table runat="server" id="tb_mg_tecnico" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_mg_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Técnico Gordura</anthem:Label>
    </td></tr></table>
        <anthem:GridView ID="gridEPLGordura" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center"
            PageSize="5" UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_epl_mg" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_epl_mg" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" width="12%" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_epl_mg" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_epl_mg" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_epl_mg" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_epl_mg" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_epl_mg" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_epl_mg" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_epl_mg" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_epl_mg" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_epl_mg" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_epl_mg" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_epl_mg" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_epl_mg" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_epl_mg" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_epl_mg"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
    <table runat="server" id="tb_prot_tecnico" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_prot_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Técnico Proteína</anthem:Label>
    </td></tr></table>
        <anthem:GridView ID="gridEPLProteina" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
            UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_epl_prot" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_epl_prot" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" width="12%" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_epl_prot" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_epl_prot" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_epl_prot" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_epl_prot" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_epl_prot" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_epl_prot" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_epl_prot" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_epl_prot" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_epl_prot" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_epl_prot" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_epl_prot" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_epl_prot" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_epl_prot" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_epl_prot"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
    <table runat="server" id="tb_ccs_tecnico" width="100%">
    <tr>
        <td style="font-weight: bold; background-color: white; border-right: #999999 1px solid; border-top: #999999 1px solid; border-left: #999999 1px solid; border-bottom: #999999 1px solid;" align="center">
            <anthem:Label ID="lbl_ccs_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Técnico CCS</anthem:Label>
    </td></tr></table>       
     <anthem:GridView ID="gridEPLCCS" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small"
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="tecnico">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lbl_tecnico_epl_ccs" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="lbl_nr_ano_epl_ccs" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle backcolor="#00C000" horizontalalign="Left" width="12%" />
                    <itemstyle horizontalalign="Right" width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JAN">
                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jan_epl_ccs" runat="server" Text='<%# bind("nr_valor_1") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FEV">
                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_fev_epl_ccs" runat="server" Text='<%# bind("nr_valor_2") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAR">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mar_epl_ccs" runat="server" Text='<%# bind("nr_valor_3") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ABR">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_abr_epl_ccs" runat="server" Text='<%# bind("nr_valor_4") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MAI">
                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_mai_epl_ccs" runat="server" Text='<%# Bind("nr_valor_5") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUN">
                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jun_epl_ccs" runat="server" Text='<%# bind("nr_valor_6") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JUL">
                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_jul_epl_ccs" runat="server" Text='<%# bind("nr_valor_7") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGO">
                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_ago_epl_ccs" runat="server" Text='<%# bind("nr_valor_8") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SET">
                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_set_epl_ccs" runat="server" Text='<%# bind("nr_valor_9") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OUT">
                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_out_epl_ccs" runat="server" Text='<%# Bind("nr_valor_10") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOV">
                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_nov_epl_ccs" runat="server" Text='<%# bind("nr_valor_11") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEZ">
                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_dez_epl_ccs" runat="server" Text='<%# bind("nr_valor_12") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="M&#233;dia">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="lbl_media_epl_ccs" runat="server" Text='<%# bind("nr_ponderado_media") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <edititemtemplate>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("nr_seq") %>' id="lbl_nr_seq_epl_ccs"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
        </anthem:GridView>
        &nbsp;&nbsp;<br />
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
