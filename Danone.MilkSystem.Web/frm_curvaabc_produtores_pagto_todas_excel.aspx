<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_produtores_pagto_todas_excel.aspx.vb" Inherits="frm_curvaabc_produtores_pagto_todas_excel" %>

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
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True"
                             BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" Wrap="True" />
                <Columns>
                    <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento">
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor">
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Prop. Matriz" DataField="id_propriedade_matriz" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_grupo" HeaderText="Grupo">
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Educampo" DataField="nm_tecnico_educampo" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ComQuali" DataField="nm_tecnico_comquali" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_tecnico_danone" HeaderText="Danone" >
                        <headerstyle  horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular">
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="st_transferencia" HeaderText="Transf.">
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Vol.">
                        <itemtemplate>
<anthem:Label id="lbl_nr_volume" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# Bind("nr_volume") %>' Height="16px" CssClass="texto" __designer:wfdid="w14"></anthem:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 1&#170; Coleta ">
                        <headertemplate>
<asp:Label id="lbl_mes1_coleta1_53" runat="server" __designer:wfdid="w17"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta1_53" runat="server" Text="1ª Col. CCS" __designer:wfdid="w18"></asp:Label> 
</headertemplate>
                        <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# Bind("nr_valor_esalq_53_ref2_1") %>' CssClass="Texto" __designer:wfdid="w15">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_53_ref2_11") %>' CssClass="Texto" __designer:wfdid="w16" Visible="False">---</anthem:Label> 
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle"/>
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta2_53" runat="server" __designer:wfdid="w20"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta2_53" runat="server" __designer:wfdid="w21" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_2") %>' __designer:wfdid="w4">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_12") %>' __designer:wfdid="w5" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta3_53" runat="server" __designer:wfdid="w28"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta3_53" runat="server" __designer:wfdid="w29" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_3") %>' __designer:wfdid="w6">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_13") %>' __designer:wfdid="w7" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta4_53" runat="server" __designer:wfdid="w36"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta4_53" runat="server" __designer:wfdid="w37" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_4") %>' __designer:wfdid="w8">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref2_14") %>' __designer:wfdid="w9" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_recoleta_53" runat="server" __designer:wfdid="w44"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_recoleta_53" runat="server" __designer:wfdid="w45" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m1_st_recoleta_N_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w10">N</anthem:Label><BR /><anthem:Label id="lbl_m1_st_recoleta_S_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w11" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta1_53" runat="server" __designer:wfdid="w52"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta1_53" runat="server" __designer:wfdid="w53" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_1") %>' __designer:wfdid="w12">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_11") %>' __designer:wfdid="w13" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta2_53" runat="server" __designer:wfdid="w60"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta2_53" runat="server" __designer:wfdid="w61" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_2") %>' __designer:wfdid="w14">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_12") %>' __designer:wfdid="w15" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta3_53" runat="server" __designer:wfdid="w68"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta3_53" runat="server" __designer:wfdid="w69" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# bind("nr_valor_esalq_53_ref1_3") %>' __designer:wfdid="w16">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_13") %>' __designer:wfdid="w17" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta4_53" runat="server" __designer:wfdid="w76"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta4_53" runat="server" __designer:wfdid="w77" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_4") %>' __designer:wfdid="w18">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref1_14") %>' __designer:wfdid="w19" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_recoleta_53" runat="server" __designer:wfdid="w84"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_recoleta_53" runat="server" __designer:wfdid="w85" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m2_st_recoleta_N_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w20">N</anthem:Label><BR /><anthem:Label id="lbl_m2_st_recoleta_S_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w21" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta1_53" runat="server" __designer:wfdid="w92"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta1_53" runat="server" __designer:wfdid="w93" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_1") %>' __designer:wfdid="w22">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta1_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_11") %>' __designer:wfdid="w23" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta2_53" runat="server" __designer:wfdid="w245"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta2_53" runat="server" __designer:wfdid="w246" Text="2ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_53_ref_2") %>' __designer:wfdid="w243" CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta2_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_53_ref_12") %>' __designer:wfdid="w244" CssClass="Texto" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta3_53" runat="server" __designer:wfdid="w108"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta3_53" runat="server" __designer:wfdid="w109" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_3") %>' __designer:wfdid="w26">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta3_53" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_13") %>' __designer:wfdid="w27" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                            <itemstyle horizontalalign="Center" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta4_53" runat="server" __designer:wfdid="w116"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta4_53" runat="server" __designer:wfdid="w117" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_4") %>' __designer:wfdid="w28">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta4_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_53_ref_14") %>' __designer:wfdid="w29" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#C0FFC0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_recoleta_53" runat="server" __designer:wfdid="w124"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_recoleta_53" runat="server" __designer:wfdid="w125" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m3_st_recoleta_N_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w33">N</anthem:Label><BR /><anthem:Label id="lbl_m3_st_recoleta_S_53" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w34" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#C0FFC0"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teor CCS">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_teor_53" __designer:dtid="281483566645284" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w32" Height="16px" Text='<%# Bind("nr_teor_ccs") %>'></anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="LightGreen" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="B&#244;nus/Desc CCS">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_bonus_53" __designer:dtid="281483566645284" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w130" CssClass="texto" Text='<%# Bind("nr_bonus_desconto_ccs") %>' Height="16px"></anthem:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="LightGreen" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compl. CCS">
                        <itemtemplate>
                            <asp:Label id="lbl_complience_53" runat="server" __designer:wfdid="w22" Text='<%# Bind("ds_teor_complience_ccs") %>'></asp:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="LightGreen" />
                    </asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="M1 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta1_52" runat="server"></asp:Label>&nbsp;
                            <asp:Label id="lbl_ds_mes1_coleta1_52" runat="server" Text="1ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# Bind("nr_valor_esalq_52_ref2_1") %>'>---</anthem:Label><BR />
                            <anthem:Label id="lbl_nr_m1_recoleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle"/>
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta2_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta2_52" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta3_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta3_52" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta4_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta4_52" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref2_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_recoleta_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_recoleta_52" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m1_st_recoleta_N_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m1_st_recoleta_S_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta1_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta1_52" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta2_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta2_52" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta3_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta3_52" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# bind("nr_valor_esalq_52_ref1_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta4_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta4_52" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref1_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_recoleta_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_recoleta_52" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m2_st_recoleta_N_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m2_st_recoleta_S_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta1_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta1_52" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta1_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta2_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta2_52" runat="server" Text="2ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_52_ref_2") %>' CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta2_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_52_ref_12") %>' CssClass="Texto" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta3_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta3_52" runat="server" Text="2ª Col."></asp:Label> 
                            
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_52_ref_3") %>' CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta3_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_52_ref_13") %>' CssClass="Texto" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta4_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta4_52" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta4_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_52_ref_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#D9C09F" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_recoleta_52" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_recoleta_52" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m3_st_recoleta_N_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m3_st_recoleta_S_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#D9C09F"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teor CBT">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_teor_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Height="16px" Text='<%# Bind("nr_teor_ctm") %>'></anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="Tan" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="B&#244;nus/Desc CBT">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_bonus_52" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Text='<%# Bind("nr_bonus_desconto_ctm") %>' Height="16px"></anthem:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="Tan" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compl CBT">
                        <itemtemplate>
                            <asp:Label id="lbl_complience_52" runat="server" Text='<%# Bind("ds_teor_complience_ctm") %>'></asp:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="Tan" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="M1 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta1_11" runat="server"></asp:Label>&nbsp;
                            <asp:Label id="lbl_ds_mes1_coleta1_11" runat="server" Text="1ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# Bind("nr_valor_esalq_11_ref2_1") %>'>---</anthem:Label><BR />
                            <anthem:Label id="lbl_nr_m1_recoleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle"/>
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta2_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta2_11" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta3_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta3_11" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta4_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta4_11" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref2_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_recoleta_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_recoleta_11" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m1_st_recoleta_N_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m1_st_recoleta_S_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta1_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta1_11" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta2_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta2_11" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta3_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta3_11" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# bind("nr_valor_esalq_11_ref1_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta4_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta4_11" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref1_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_recoleta_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_recoleta_11" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m2_st_recoleta_N_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m2_st_recoleta_S_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta1_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta1_11" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta1_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta2_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta2_11" runat="server" Text="2ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_11_ref_2") %>' CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta2_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_11_ref_12") %>' CssClass="Texto" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta3_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta3_11" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta3_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                            <itemstyle horizontalalign="Center" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta4_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta4_11" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta4_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_11_ref_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#CCCCFF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_recoleta_11" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_recoleta_11" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m3_st_recoleta_N_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m3_st_recoleta_S_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#CCCCFF"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teor Prot.">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_teor_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Height="16px" Text='<%# Bind("nr_teor_proteina") %>'></anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#C0C0FF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="B&#244;nus/Desc Prot">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_bonus_11" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Text='<%# Bind("nr_bonus_desconto_proteina") %>' Height="16px"></anthem:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#C0C0FF" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compl Prot">
                        <itemtemplate>
                            <asp:Label id="lbl_complience_11" runat="server" Text='<%# Bind("ds_teor_complience_proteina") %>'></asp:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#C0C0FF" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="M1 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta1" runat="server"></asp:Label>&nbsp;
                            <asp:Label id="lbl_ds_mes1_coleta1" runat="server" Text="1ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# Bind("nr_valor_esalq_ref2_1") %>'>---</anthem:Label><BR />
                            <anthem:Label id="lbl_nr_m1_recoleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle"/>
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta2" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta2" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta3" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta3" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_coleta4" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta4" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m1_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes1_recoleta" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_recoleta" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m1_st_recoleta_N" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m1_st_recoleta_S" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta1" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta1" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta2" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta2" runat="server" Text="2ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_2") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_12") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta3" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta3" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# bind("nr_valor_esalq_ref1_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_coleta4" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta4" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m2_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes2_recoleta" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_recoleta" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m2_st_recoleta_N" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m2_st_recoleta_S" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta1" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta1" runat="server" Text="1ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_1") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta1" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_11") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta2" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta2" runat="server" Text="2ª Col."></asp:Label> 
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_2") %>' CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta2" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_12") %>' CssClass="Texto" Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta3" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta3" runat="server" Text="3ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_3") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta3" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_13") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                            <itemstyle horizontalalign="Center" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_coleta4" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta4" runat="server" Text="4ª Col."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_m3_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_4") %>'>---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_14") %>' Visible="False">---</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" wrap="True" backcolor="#FFE0C0" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recol.">
                        <headertemplate>
                            <asp:Label id="lbl_mes3_recoleta" runat="server"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_recoleta" runat="server" Text="Recol."></asp:Label>
                        
</headertemplate>
                        <itemtemplate>
                            <anthem:Label id="lbl_m3_st_recoleta_N" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto">N</anthem:Label><BR /><anthem:Label id="lbl_m3_st_recoleta_S" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Visible="False">S</anthem:Label> 
                        
</itemtemplate>
                        <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                        <itemstyle horizontalalign="Center" backcolor="#FFE0C0"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teor Gor.">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_teor" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Height="16px" Text='<%# Bind("nr_teor_mg") %>'></anthem:Label> 
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#FFD9B3" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="B&#244;nus/Desc Gord">
                        <itemtemplate>
                            <anthem:Label id="lbl_nr_bonus" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Text='<%# Bind("nr_bonus_desconto_mg") %>' Height="16px"></anthem:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#FFD9B3" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compl Gor.">
                        <itemtemplate>
                            <asp:Label id="lbl_complience" runat="server" Text='<%# Bind("ds_teor_complience_mg") %>'></asp:Label>
                        
</itemtemplate>
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" backcolor="#FFD9B3" />
                    </asp:TemplateField>


                                <asp:BoundField DataField="nr_total_qualidade" HeaderText="Total Qualidade" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_qualidade_volume" HeaderText="Total Qualidade x Volume" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compliance Geral">
                                    <itemtemplate>
<asp:Label id="lbl_complience_geral" runat="server" __designer:wfdid="w24" Text='<%# Bind("nr_total_complience") %>'></asp:Label>
</itemtemplate>
<headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                        <itemtemplate>
                            <anthem:Label id="lbl_id_propriedade" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Text='<%# Bind("id_propriedade") %>' Height="16px"></anthem:Label>
                        
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
