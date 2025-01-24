<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_produtores_pagto_excel.aspx.vb" Inherits="frm_curvaabc_produtores_pagto_excel" %>

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
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop. Matriz" />
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
<anthem:Label id="lbl_nr_volume" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# Bind("nr_volume") %>' Height="16px" CssClass="texto" __designer:wfdid="w25"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_categoria" HeaderText="Cat." />
                                <asp:TemplateField HeaderText="M1 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta1" runat="server" __designer:wfdid="w30"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta1" runat="server" Text="1ª Col." __designer:wfdid="w31"></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# Bind("nr_valor_esalq_ref2_1") %>' __designer:wfdid="w28">---</anthem:Label><BR />
<anthem:Label id="lbl_nr_m1_recoleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w29" Visible="False"  Text='<%# bind("nr_valor_esalq_ref2_11") %>'>---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle"/>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta2" runat="server" __designer:wfdid="w20"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta2" runat="server" __designer:wfdid="w21" Text="2ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_2") %>' __designer:wfdid="w4">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_12") %>' __designer:wfdid="w5" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta3" runat="server" __designer:wfdid="w28"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta3" runat="server" __designer:wfdid="w29" Text="3ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_3") %>' __designer:wfdid="w6">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_13") %>' __designer:wfdid="w7" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta4" runat="server" __designer:wfdid="w36"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_coleta4" runat="server" __designer:wfdid="w37" Text="4ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_4") %>' __designer:wfdid="w8">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m1_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref2_14") %>' __designer:wfdid="w9" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recol.">
                                    <headertemplate>
<asp:Label id="lbl_mes1_recoleta" runat="server" __designer:wfdid="w44"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes1_recoleta" runat="server" __designer:wfdid="w45" Text="Recol."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m1_st_recoleta_N" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w10">N</anthem:Label><BR /><anthem:Label id="lbl_m1_st_recoleta_S" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w11" Visible="False">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta1" runat="server" __designer:wfdid="w52"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta1" runat="server" __designer:wfdid="w53" Text="1ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_1") %>' __designer:wfdid="w12">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_11") %>' __designer:wfdid="w13" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta2" runat="server" __designer:wfdid="w60"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta2" runat="server" __designer:wfdid="w61" Text="2ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_2") %>' __designer:wfdid="w14">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_12") %>' __designer:wfdid="w15" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta3" runat="server" __designer:wfdid="w68"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta3" runat="server" __designer:wfdid="w69" Text="3ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto"  Text='<%# bind("nr_valor_esalq_ref1_3") %>' __designer:wfdid="w16">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_13") %>' __designer:wfdid="w17" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta4" runat="server" __designer:wfdid="w76"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_coleta4" runat="server" __designer:wfdid="w77" Text="4ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_4") %>' __designer:wfdid="w18">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m2_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref1_14") %>' __designer:wfdid="w19" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recol.">
                                    <headertemplate>
<asp:Label id="lbl_mes2_recoleta" runat="server" __designer:wfdid="w84"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes2_recoleta" runat="server" __designer:wfdid="w85" Text="Recol."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m2_st_recoleta_N" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w20">N</anthem:Label><BR /><anthem:Label id="lbl_m2_st_recoleta_S" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w21" Visible="False">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta1" runat="server" __designer:wfdid="w92"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta1" runat="server" __designer:wfdid="w93" Text="1ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_1") %>' __designer:wfdid="w22">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta1" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_11") %>' __designer:wfdid="w23" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta2" runat="server" __designer:wfdid="w245"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta2" runat="server" __designer:wfdid="w246" Text="2ª Col."></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_2") %>' __designer:wfdid="w243" CssClass="Texto">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta2" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_12") %>' __designer:wfdid="w244" CssClass="Texto" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta3" runat="server" __designer:wfdid="w108"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta3" runat="server" __designer:wfdid="w109" Text="3ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_3") %>' __designer:wfdid="w26">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta3" __designer:dtid="281483566645274" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_13") %>' __designer:wfdid="w27" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta4" runat="server" __designer:wfdid="w116"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_coleta4" runat="server" __designer:wfdid="w117" Text="4ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_4") %>' __designer:wfdid="w28">---</anthem:Label><BR /><anthem:Label id="lbl_nr_m3_recoleta4" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" Text='<%# bind("nr_valor_esalq_ref_14") %>' __designer:wfdid="w29" Visible="False">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recol.">
                                    <headertemplate>
<asp:Label id="lbl_mes3_recoleta" runat="server" __designer:wfdid="w124"></asp:Label>&nbsp;<asp:Label id="lbl_ds_mes3_recoleta" runat="server" __designer:wfdid="w125" Text="Recol."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m3_st_recoleta_N" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w33">N</anthem:Label><BR /><anthem:Label id="lbl_m3_st_recoleta_S" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="Texto" __designer:wfdid="w34" Visible="False">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Teor">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_teor" __designer:dtid="281483566645284" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w32" Height="16px" Text='<%# Bind("nr_teor") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B&#244;nus/Desconto">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_bonus" __designer:dtid="281483566645284" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w130" CssClass="texto" Text='<%# Bind("nr_bonus_desconto") %>' Height="16px"></anthem:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_id_propriedade" __designer:dtid="281483566645284" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w133" CssClass="texto" Text='<%# Bind("id_propriedade") %>' Height="16px"></anthem:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Compliance">
                                    <itemtemplate>
<asp:Label id="lbl_complience" runat="server" __designer:wfdid="w22" Text='<%# Bind("ds_teor_complience") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
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
