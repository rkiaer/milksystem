<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_kpi_qualidade_excel.aspx.vb" Inherits="frm_curvaabc_kpi_qualidade_excel" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC - Overview Quality</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
		<form id="form1" method="post" runat="server">
            <anthem:GridView ID="gridVolumeTotalComplience" runat="server" AllowSorting="True"
                AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" BackColor="White"
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Verdana"
                Font-Size="XX-Small" PageSize="5" UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="% Volume total Compliance">
                        <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w39"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w41"></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp; 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w42"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w43"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>'  __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w9"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridCCSMensal" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="CCS M&#233;dia ponderada Mensal">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w3"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridCCSTrimestral" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="CCS M&#233;dia ponderada Trimestral">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w4" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w6"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridCBTMensal" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="CBT M&#233;dia ponderada Mensal">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w7" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w9"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridCBTTrimestral" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="CBT M&#233;dia ponderada Trimestral">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w10" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w12"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridProteinaMensal" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="Prote&#237;na M&#233;dia ponderada Mensal">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w13" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server"  Text='<%# Bind("nrset") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server"  Text='<%# Bind("nrout") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server"  Text='<%# Bind("nrnov") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server"  Text='<%# Bind("nrdez") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w15"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w14"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridGorduraMensal" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="Gordura M&#233;dia ponderada Mensal">
                        <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w16" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' ></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w18"></asp:TextBox>
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w17"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridVolumeRejeitado" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="% Rejei&#231;&#227;o ATB">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp; 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w49"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w51"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w53"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# bind("nrmai") %>' __designer:wfdid="w55"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w59"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w61"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# bind("nrset") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# bind("nrout") %>' __designer:wfdid="w65"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w70"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seq" Visible="False">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w23"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <anthem:GridView ID="gridTracadoControlado" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                UpdateAfterCallBack="True" Width="90%">
                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                    ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                    HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField HeaderText="Ano">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <headertemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w86"></asp:Label> 
</headertemplate>
                        <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w106"></asp:Label> 
</itemtemplate>
                        <headerstyle width="20%" />
                        <itemstyle horizontalalign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JAN">
                        <edititemtemplate>
&nbsp; 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w80"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FEV">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w88"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAR">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w90"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ABR">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w92"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MAI">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# bind("nrmai") %>' __designer:wfdid="w94"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUN">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w96"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JUL">
                        <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w98"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGO">
                        <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w100"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# bind("nrset") %>' __designer:wfdid="w102"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OUT">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# bind("nrout") %>' __designer:wfdid="w104"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOV">
                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w107"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEZ">
                        <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w109"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seq" Visible="False">
                        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w112"></asp:TextBox> 
</edititemtemplate>
                        <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w111"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="M&#233;dia Anual">
                        <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w26"></asp:Label> 
</itemtemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <RowStyle ForeColor="#000066" />
            </anthem:GridView>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
