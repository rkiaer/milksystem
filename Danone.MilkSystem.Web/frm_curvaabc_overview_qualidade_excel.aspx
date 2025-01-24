<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_curvaabc_overview_qualidade_excel.aspx.vb" Inherits="frm_curvaabc_overview_qualidade_excel" %>

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


                        <anthem:GridView ID="gridCBT" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridCCS" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridProteina" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView><anthem:GridView ID="gridGordura" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
