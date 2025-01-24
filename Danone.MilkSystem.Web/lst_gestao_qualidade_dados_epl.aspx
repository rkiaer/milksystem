<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_gestao_qualidade_dados_epl.aspx.vb" Inherits="lst_gestao_qualidade_dados_epl" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Gestão de Qualidade - Base de Dados EPLs</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Gestão de Qualidade - Base de Dados EPLs</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>
                        &nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 20%"></TD>
								<TD style="height: 12px; width: 10%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" Enabled="False">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 20px">
                                    Ano:&nbsp;&nbsp;<anthem:Label ID="lbl_ano" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    Código Técnico Danone:&nbsp;
                                    <anthem:DropDownList ID="cbo_tecnico" runat="server" CssClass="texto" AutoPostBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 20px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 20px; width: 10px;">&nbsp;</TD>
				</TR>
				<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_mg" runat="server" AutoUpdateAfterCallBack="True" CssClass="borda" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small">Gordura</anthem:Label>
                    </td> <td></td>
                </tr>
				<TR  >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; " align="center">
					<anthem:GridView ID="gridGordura" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
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
                        
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

				<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_prot" runat="server" AutoUpdateAfterCallBack="True" CssClass="borda" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small">Proteína</anthem:Label>
                    </td> <td></td>
                </tr>

				<TR  >
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center">
                        <anthem:GridView ID="gridProteina" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="#000066" />
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
                                <headerstyle backcolor="#00C000" width="12%" horizontalalign="Left" />
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
                                       
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

	
				<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_ccs" runat="server" AutoUpdateAfterCallBack="True" CssClass="borda" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small">CCS</anthem:Label>
                    </td> <td></td>
                </tr>
			<TR  >
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center"><anthem:GridView ID="gridCCS" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="#000066" />
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
                                <headerstyle backcolor="#00C000" width="12%" horizontalalign="Left" />
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
                                        
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

				<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_mg_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small"></anthem:Label>
                    </td> <td></td>
                </tr>
				<TR runat="server" id="tr_tecnico_gordura_grid" >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; " align="center">
					<anthem:GridView ID="gridEPLGordura" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="#000066" />
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
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
								<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_prot_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small"></anthem:Label>
                    </td> <td></td>
                </tr>

				<TR runat="server" id="tr_tecnico_proteina_grid" >
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center">
                        <anthem:GridView ID="gridEPLProteina" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
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
                                       
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

	
				<tr  >
				    <td></td>
                    <td align="center">
                        <anthem:Label style="border-bottom:none;" ID="lbl_ccs_tecnico" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="100%" Font-Bold="True" Font-Size="X-Small"></anthem:Label>
                    </td> <td></td>
                </tr>
			<TR runat="server" id="tr_tecnico_ccs_grid" >
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center"><anthem:GridView ID="gridEPLCCS" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#E0E0E0" Font-Bold="False" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
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
                                                               
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>


							<TR>
								<TD ></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD></TD>
							</TR>

			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
        </div>
		</form>
	</body>
</HTML>
