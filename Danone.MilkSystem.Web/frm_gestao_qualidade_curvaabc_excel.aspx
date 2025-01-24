<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_gestao_qualidade_curvaabc_excel.aspx.vb" Inherits="frm_gestao_qualidade_curvaabc_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Curva ABC Gestão</title>
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
                                <asp:BoundField DataField="nm_tecnico_conquali" HeaderText="ComQuali" />
                                <asp:BoundField DataField="nm_cidade" HeaderText="Cidade" />
				<asp:TemplateField HeaderText="nr_volume_jan_1">
					<headertemplate>
<asp:Label id="lbl_volume_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>' __designer:wfdid="w78"></asp:Label>&nbsp;Volume JAN
</headertemplate>
					<itemtemplate>
<asp:Label id="lbl_nr_volume_1_ant" runat="server" Text='<%# Bind("nr_volume_ant_1") %>' __designer:wfdid="w77"></asp:Label> 
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_fev_1">
					<headertemplate>
<asp:Label id="lbl_volume_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>' __designer:wfdid="w80"></asp:Label>&nbsp;Volume FEV
</headertemplate>
					<itemtemplate>
<asp:Label id="lbl_nr_volume_2_ant" runat="server" Text='<%# Bind("nr_volume_ant_2") %>' __designer:wfdid="w79"></asp:Label> 
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_mar_1">
					<headertemplate>
<asp:Label id="lbl_volume_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>' __designer:wfdid="w82"></asp:Label>&nbsp;Volume MAR
</headertemplate>
					<itemtemplate>
<asp:Label id="lbl_nr_volume_3_ant" runat="server" Text='<%# Bind("nr_volume_ant_3") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_abr_1">
					<headertemplate>
						<asp:Label id="lbl_volume_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_4_ant" runat="server" Text='<%# Bind("nr_volume_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_mai_1">
					<headertemplate>
						<asp:Label id="lbl_volume_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_5_ant" runat="server" Text='<%# Bind("nr_volume_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_jun_1">
					<headertemplate>
						<asp:Label id="lbl_volume_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_6_ant" runat="server" Text='<%# Bind("nr_volume_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_jul_1">
					<headertemplate>
						<asp:Label id="lbl_volume_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_7_ant" runat="server" Text='<%# Bind("nr_volume_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_ago_1">
					<headertemplate>
						<asp:Label id="lbl_volume_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_8_ant" runat="server" Text='<%# Bind("nr_volume_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_set_1">
					<headertemplate>
						<asp:Label id="lbl_volume_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_9_ant" runat="server" Text='<%# Bind("nr_volume_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_out_1">
					<headertemplate>
						<asp:Label id="lbl_volume_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_10_ant" runat="server" Text='<%# Bind("nr_volume_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_nov_1">
					<headertemplate>
						<asp:Label id="lbl_volume_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_11_ant" runat="server" Text='<%# Bind("nr_volume_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_dez_1">
					<headertemplate>
						<asp:Label id="lbl_volume_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label>&nbsp;Volume DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_12_ant" runat="server" Text='<%# Bind("nr_volume_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_volume_jan">
					<headertemplate>
						<asp:Label id="lbl_volume_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_1" runat="server" Text='<%# Bind("nr_volume_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_fev">
					<headertemplate>
						<asp:Label id="lbl_volume_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_volume_2" runat="server" Text='<%# Bind("nr_volume_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_mar">
					<headertemplate>
						<asp:Label id="lbl_volume_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_3" runat="server" Text='<%# Bind("nr_volume_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_volume_abr">
					<headertemplate>
						<asp:Label id="lbl_volume_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_4" runat="server" Text='<%# Bind("nr_volume_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_5" runat="server" Text='<%# Bind("nr_volume_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_6" runat="server" Text='<%# Bind("nr_volume_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_7" runat="server" Text='<%# Bind("nr_volume_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_8" runat="server" Text='<%# Bind("nr_volume_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_9" runat="server" Text='<%# Bind("nr_volume_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_10" runat="server" Text='<%# Bind("nr_volume_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_11" runat="server" Text='<%# Bind("nr_volume_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_volume_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_volume_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label>&nbsp;Volume DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_12" runat="server" Text='<%# Bind("nr_volume_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_jan_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_1_ant" runat="server" Text='<%# Bind("nr_cbt_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_fev_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_2_ant" runat="server" Text='<%# Bind("nr_cbt_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_mar_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_3_ant" runat="server" Text='<%# Bind("nr_cbt_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_abr_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_4_ant" runat="server" Text='<%# Bind("nr_cbt_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_mai_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_5_ant" runat="server" Text='<%# Bind("nr_cbt_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_jun_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_6_ant" runat="server" Text='<%# Bind("nr_cbt_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_jul_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_7_ant" runat="server" Text='<%# Bind("nr_cbt_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ago_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_8_ant" runat="server" Text='<%# Bind("nr_cbt_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_set_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_9_ant" runat="server" Text='<%# Bind("nr_cbt_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_out_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_10_ant" runat="server" Text='<%# Bind("nr_cbt_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_nov_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_11_ant" runat="server" Text='<%# Bind("nr_cbt_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_dez_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CBT DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_12_ant" runat="server" Text='<%# Bind("nr_cbt_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_cbt_jan">
					<headertemplate>
						<asp:Label id="lbl_cbt_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_1" runat="server" Text='<%# Bind("nr_cbt_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_fev">
					<headertemplate>
						<asp:Label id="lbl_cbt_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_2" runat="server" Text='<%# Bind("nr_cbt_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_mar">
					<headertemplate>
						<asp:Label id="lbl_cbt_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_3" runat="server" Text='<%# Bind("nr_cbt_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_abr">
					<headertemplate>
						<asp:Label id="lbl_cbt_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_4" runat="server" Text='<%# Bind("nr_cbt_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_5" runat="server" Text='<%# Bind("nr_cbt_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_6" runat="server" Text='<%# Bind("nr_cbt_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_7" runat="server" Text='<%# Bind("nr_cbt_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_8" runat="server" Text='<%# Bind("nr_cbt_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_9" runat="server" Text='<%# Bind("nr_cbt_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_10" runat="server" Text='<%# Bind("nr_cbt_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_11" runat="server" Text='<%# Bind("nr_cbt_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CBT DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_12" runat="server" Text='<%# Bind("nr_cbt_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_ccs_jan_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_1_ant" runat="server" Text='<%# Bind("nr_ccs_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_fev_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_2_ant" runat="server" Text='<%# Bind("nr_ccs_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_mar_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_3_ant" runat="server" Text='<%# Bind("nr_ccs_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_abr_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_4_ant" runat="server" Text='<%# Bind("nr_ccs_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_mai_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_5_ant" runat="server" Text='<%# Bind("nr_ccs_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_jun_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_6_ant" runat="server" Text='<%# Bind("nr_ccs_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_jul_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_7_ant" runat="server" Text='<%# Bind("nr_ccs_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ago_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_8_ant" runat="server" Text='<%# Bind("nr_ccs_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_set_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_9_ant" runat="server" Text='<%# Bind("nr_ccs_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_out_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_10_ant" runat="server" Text='<%# Bind("nr_ccs_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_nov_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_11_ant" runat="server" Text='<%# Bind("nr_ccs_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_dez_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> CCS DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_12_ant" runat="server" Text='<%# Bind("nr_ccs_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_ccs_jan">
					<headertemplate>
						<asp:Label id="lbl_ccs_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_1" runat="server" Text='<%# Bind("nr_ccs_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_fev">
					<headertemplate>
						<asp:Label id="lbl_ccs_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_2" runat="server" Text='<%# Bind("nr_ccs_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_mar">
					<headertemplate>
						<asp:Label id="lbl_ccs_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_3" runat="server" Text='<%# Bind("nr_ccs_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_abr">
					<headertemplate>
						<asp:Label id="lbl_ccs_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_4" runat="server" Text='<%# Bind("nr_ccs_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_5" runat="server" Text='<%# Bind("nr_ccs_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_6" runat="server" Text='<%# Bind("nr_ccs_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_7" runat="server" Text='<%# Bind("nr_ccs_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_8" runat="server" Text='<%# Bind("nr_ccs_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_9" runat="server" Text='<%# Bind("nr_ccs_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_10" runat="server" Text='<%# Bind("nr_ccs_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_11" runat="server" Text='<%# Bind("nr_ccs_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> CCS DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_12" runat="server" Text='<%# Bind("nr_ccs_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_prot_jan_1">
					<headertemplate>
						<asp:Label id="lbl_prot_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_1_ant" runat="server" Text='<%# Bind("nr_prot_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_fev_1">
					<headertemplate>
						<asp:Label id="lbl_prot_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_2_ant" runat="server" Text='<%# Bind("nr_prot_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_mar_1">
					<headertemplate>
						<asp:Label id="lbl_prot_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_3_ant" runat="server" Text='<%# Bind("nr_prot_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_abr_1">
					<headertemplate>
						<asp:Label id="lbl_prot_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_4_ant" runat="server" Text='<%# Bind("nr_prot_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_mai_1">
					<headertemplate>
						<asp:Label id="lbl_prot_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_5_ant" runat="server" Text='<%# Bind("nr_prot_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_jun_1">
					<headertemplate>
						<asp:Label id="lbl_prot_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_6_ant" runat="server" Text='<%# Bind("nr_prot_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_jul_1">
					<headertemplate>
						<asp:Label id="lbl_prot_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_7_ant" runat="server" Text='<%# Bind("nr_prot_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ago_1">
					<headertemplate>
						<asp:Label id="lbl_prot_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_8_ant" runat="server" Text='<%# Bind("nr_prot_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_set_1">
					<headertemplate>
						<asp:Label id="lbl_prot_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_9_ant" runat="server" Text='<%# Bind("nr_prot_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_out_1">
					<headertemplate>
						<asp:Label id="lbl_prot_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_10_ant" runat="server" Text='<%# Bind("nr_prot_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_nov_1">
					<headertemplate>
						<asp:Label id="lbl_prot_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_11_ant" runat="server" Text='<%# Bind("nr_prot_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_dez_1">
					<headertemplate>
						<asp:Label id="lbl_prot_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Proteína DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_12_ant" runat="server" Text='<%# Bind("nr_prot_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_prot_jan">
					<headertemplate>
						<asp:Label id="lbl_prot_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_1" runat="server" Text='<%# Bind("nr_prot_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_fev">
					<headertemplate>
						<asp:Label id="lbl_prot_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_2" runat="server" Text='<%# Bind("nr_prot_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_mar">
					<headertemplate>
						<asp:Label id="lbl_prot_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_3" runat="server" Text='<%# Bind("nr_prot_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_abr">
					<headertemplate>
						<asp:Label id="lbl_prot_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_4" runat="server" Text='<%# Bind("nr_prot_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_5" runat="server" Text='<%# Bind("nr_prot_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_6" runat="server" Text='<%# Bind("nr_prot_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_7" runat="server" Text='<%# Bind("nr_prot_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_8" runat="server" Text='<%# Bind("nr_prot_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_9" runat="server" Text='<%# Bind("nr_prot_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_10" runat="server" Text='<%# Bind("nr_prot_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_11" runat="server" Text='<%# Bind("nr_prot_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Proteína DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_12" runat="server" Text='<%# Bind("nr_prot_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_mg_jan_1">
					<headertemplate>
						<asp:Label id="lbl_mg_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_1_ant" runat="server" Text='<%# Bind("nr_mg_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_fev_1">
					<headertemplate>
						<asp:Label id="lbl_mg_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_2_ant" runat="server" Text='<%# Bind("nr_mg_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_mar_1">
					<headertemplate>
						<asp:Label id="lbl_mg_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_3_ant" runat="server" Text='<%# Bind("nr_mg_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_abr_1">
					<headertemplate>
						<asp:Label id="lbl_mg_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_4_ant" runat="server" Text='<%# Bind("nr_mg_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_mai_1">
					<headertemplate>
						<asp:Label id="lbl_mg_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_5_ant" runat="server" Text='<%# Bind("nr_mg_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_jun_1">
					<headertemplate>
						<asp:Label id="lbl_mg_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_6_ant" runat="server" Text='<%# Bind("nr_mg_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_jul_1">
					<headertemplate>
						<asp:Label id="lbl_mg_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_7_ant" runat="server" Text='<%# Bind("nr_mg_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ago_1">
					<headertemplate>
						<asp:Label id="lbl_mg_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_8_ant" runat="server" Text='<%# Bind("nr_mg_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_set_1">
					<headertemplate>
						<asp:Label id="lbl_mg_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_9_ant" runat="server" Text='<%# Bind("nr_mg_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_out_1">
					<headertemplate>
						<asp:Label id="lbl_mg_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_10_ant" runat="server" Text='<%# Bind("nr_mg_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_nov_1">
					<headertemplate>
						<asp:Label id="lbl_mg_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_11_ant" runat="server" Text='<%# Bind("nr_mg_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_dez_1">
					<headertemplate>
						<asp:Label id="lbl_mg_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Gordura DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_12_ant" runat="server" Text='<%# Bind("nr_mg_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_mg_jan">
					<headertemplate>
						<asp:Label id="lbl_mg_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_1" runat="server" Text='<%# Bind("nr_mg_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_fev">
					<headertemplate>
						<asp:Label id="lbl_mg_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_2" runat="server" Text='<%# Bind("nr_mg_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_mar">
					<headertemplate>
						<asp:Label id="lbl_mg_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_3" runat="server" Text='<%# Bind("nr_mg_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_abr">
					<headertemplate>
						<asp:Label id="lbl_mg_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_4" runat="server" Text='<%# Bind("nr_mg_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_5" runat="server" Text='<%# Bind("nr_mg_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_6" runat="server" Text='<%# Bind("nr_mg_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_7" runat="server" Text='<%# Bind("nr_mg_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_8" runat="server" Text='<%# Bind("nr_mg_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_9" runat="server" Text='<%# Bind("nr_mg_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_10" runat="server" Text='<%# Bind("nr_mg_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_11" runat="server" Text='<%# Bind("nr_mg_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Gordura DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_12" runat="server" Text='<%# Bind("nr_mg_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_cbt_ponderado_jan_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_1_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_fev_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_2_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_mar_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_3_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_abr_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_4_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_mai_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_5_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_jun_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_6_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_jul_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_7_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_ago_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_8_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_set_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_9_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_out_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_10_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_nov_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_11_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_dez_1">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CBT DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_12_ant" runat="server" Text='<%# Bind("nr_cbt_ponderado_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_cbt_ponderado_jan">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_1" runat="server" Text='<%# Bind("nr_cbt_ponderado_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_fev">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_cbt_ponderado_2" runat="server" Text='<%# Bind("nr_cbt_ponderado_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_mar">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_3" runat="server" Text='<%# Bind("nr_cbt_ponderado_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_cbt_ponderado_abr">
					<headertemplate>
						<asp:Label id="lbl_cbt_ponderado_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_4" runat="server" Text='<%# Bind("nr_cbt_ponderado_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_5" runat="server" Text='<%# Bind("nr_cbt_ponderado_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_6" runat="server" Text='<%# Bind("nr_cbt_ponderado_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_7" runat="server" Text='<%# Bind("nr_cbt_ponderado_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_8" runat="server" Text='<%# Bind("nr_cbt_ponderado_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_9" runat="server" Text='<%# Bind("nr_cbt_ponderado_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_10" runat="server" Text='<%# Bind("nr_cbt_ponderado_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_11" runat="server" Text='<%# Bind("nr_cbt_ponderado_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_cbt_ponderado_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_cbt_ponderado_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CBT DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_cbt_ponderado_12" runat="server" Text='<%# Bind("nr_cbt_ponderado_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_jan_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_1_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_fev_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_2_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_mar_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_3_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_abr_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_4_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_mai_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_5_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_jun_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_6_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_jul_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_7_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_ago_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_8_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_set_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_9_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_out_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_10_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_nov_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_11_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_dez_1">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado CCS DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_12_ant" runat="server" Text='<%# Bind("nr_ccs_ponderado_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_ccs_ponderado_jan">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_1" runat="server" Text='<%# Bind("nr_ccs_ponderado_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_fev">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_ccs_ponderado_2" runat="server" Text='<%# Bind("nr_ccs_ponderado_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_mar">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_3" runat="server" Text='<%# Bind("nr_ccs_ponderado_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_ccs_ponderado_abr">
					<headertemplate>
						<asp:Label id="lbl_ccs_ponderado_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_4" runat="server" Text='<%# Bind("nr_ccs_ponderado_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_5" runat="server" Text='<%# Bind("nr_ccs_ponderado_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_6" runat="server" Text='<%# Bind("nr_ccs_ponderado_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_7" runat="server" Text='<%# Bind("nr_ccs_ponderado_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_8" runat="server" Text='<%# Bind("nr_ccs_ponderado_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_9" runat="server" Text='<%# Bind("nr_ccs_ponderado_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_10" runat="server" Text='<%# Bind("nr_ccs_ponderado_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_11" runat="server" Text='<%# Bind("nr_ccs_ponderado_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_ccs_ponderado_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_ccs_ponderado_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado CCS DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ccs_ponderado_12" runat="server" Text='<%# Bind("nr_ccs_ponderado_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_prot_ponderado_jan_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_1_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_fev_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_2_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_mar_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_3_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_abr_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_4_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_mai_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_5_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_jun_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_6_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_jul_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_7_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_ago_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_8_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_set_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_9_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_out_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_10_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_nov_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_11_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_dez_1">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado ProT DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_12_ant" runat="server" Text='<%# Bind("nr_prot_ponderado_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_prot_ponderado_jan">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_1" runat="server" Text='<%# Bind("nr_prot_ponderado_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_fev">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_prot_ponderado_2" runat="server" Text='<%# Bind("nr_prot_ponderado_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_mar">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_3" runat="server" Text='<%# Bind("nr_prot_ponderado_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_prot_ponderado_abr">
					<headertemplate>
						<asp:Label id="lbl_prot_ponderado_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_4" runat="server" Text='<%# Bind("nr_prot_ponderado_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_5" runat="server" Text='<%# Bind("nr_prot_ponderado_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_6" runat="server" Text='<%# Bind("nr_prot_ponderado_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_7" runat="server" Text='<%# Bind("nr_prot_ponderado_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_8" runat="server" Text='<%# Bind("nr_prot_ponderado_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_9" runat="server" Text='<%# Bind("nr_prot_ponderado_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_10" runat="server" Text='<%# Bind("nr_prot_ponderado_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_11" runat="server" Text='<%# Bind("nr_prot_ponderado_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_prot_ponderado_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_prot_ponderado_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado ProT DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_prot_ponderado_12" runat="server" Text='<%# Bind("nr_prot_ponderado_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>

				<asp:TemplateField HeaderText="nr_mg_ponderado_jan_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_1_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG JAN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_1_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_fev_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_2_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG FEV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_2_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_mar_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_3_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG MAR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_3_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_3") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_abr_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_4_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG ABR
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_4_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_4") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_mai_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_5_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG MAI
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_5_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_5") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_jun_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_6_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG JUN
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_6_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_6") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_jul_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_7_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG JUL
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_7_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_7") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_ago_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_8_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG AGO
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_8_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_8") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_set_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_9_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG SET
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_9_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_9") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_out_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_10_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG OUT
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_10_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_10") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_nov_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_11_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG NOV
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_11_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_11") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_dez_1">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_12_ant" runat="server" Text='<%# Bind("nr_ano_ant") %>'></asp:Label> Ponderado MG DEZ
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_12_ant" runat="server" Text='<%# Bind("nr_mg_ponderado_ant_12") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>

				<asp:TemplateField HeaderText="nr_mg_ponderado_jan">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_1" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG JAN
                                    
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_1" runat="server" Text='<%# Bind("nr_mg_ponderado_1") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle  horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_fev">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_2" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG FEV
                                    
					
</headertemplate>
					<itemtemplate>
						<asp:Label id="lbl_nr_mg_ponderado_2" runat="server" Text='<%# Bind("nr_mg_ponderado_2") %>'></asp:Label>
					
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_mar">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_3" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG MAR
					
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_3" runat="server" Text='<%# Bind("nr_mg_ponderado_3") %>'></asp:Label>
</itemtemplate>
					<headerstyle horizontalalign="Center" />
					<itemstyle horizontalalign="Right" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="nr_mg_ponderado_abr">
					<headertemplate>
						<asp:Label id="lbl_mg_ponderado_4" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG ABR
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_4" runat="server" Text='<%# Bind("nr_mg_ponderado_4") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_mai">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_5" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG MAI
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_5" runat="server" Text='<%# Bind("nr_mg_ponderado_5") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_jun">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_6" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG JUN
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_6" runat="server" Text='<%# Bind("nr_mg_ponderado_6") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_jul">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_7" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG JUL
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_7" runat="server" Text='<%# Bind("nr_mg_ponderado_7") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_ago">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_8" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG AGO
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_8" runat="server" Text='<%# Bind("nr_mg_ponderado_8") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_set">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_9" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG SET
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_9" runat="server" Text='<%# Bind("nr_mg_ponderado_9") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_out">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_10" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG OUT
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_10" runat="server" Text='<%# Bind("nr_mg_ponderado_10") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_nov">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_11" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG NOV
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_11" runat="server" Text='<%# Bind("nr_mg_ponderado_11") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle  horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_mg_ponderado_dez">
                                    <headertemplate>
                                        <asp:Label id="lbl_mg_ponderado_12" runat="server" Text='<%# Bind("nr_ano") %>'></asp:Label> Ponderado MG DEZ
                                    
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_mg_ponderado_12" runat="server" Text='<%# Bind("nr_mg_ponderado_12") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
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
