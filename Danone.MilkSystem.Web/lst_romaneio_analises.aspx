<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_analises.aspx.vb" Inherits="lst_romaneio_analises" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_compartimento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table1_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table1_onclick()">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 715px;"><STRONG>Registrar Análises &nbsp;&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 14px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 14px">
						<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp;
                                </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 14px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 47px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 47px; width: 100%;" align="center" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" border="0" style="height: 8px; width: 100%;" onclick="return Table2_onclick()" >
							<TR>
								<TD style="height: 12px; width: 141px;"></TD>
								<TD colspan="3" style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px; width: 141px;">
                                    Romaneio:</td>
                                <td style="height: 20px;width:27%">
                                    &nbsp;
                                    <asp:Label ID="lbl_romaneio" runat="server" CssClass="texto" ></asp:Label>
                                </td>
								<TD class="texto" align="right" style="height: 20px;width:20%" > Situação Romaneio:</TD>
								<TD style="height: 20px;width:235px" >
					                &nbsp;<asp:Label ID="lbl_nm_st_romaneio" runat="server" CssClass="texto" ></asp:Label>
                                </TD>
							</TR>
                            
                            <tr>
								<TD class="texto" align="right" style="height: 20px; width: 141px;" > Transportador:</TD>
								<TD style="height: 20px;" >
					                &nbsp;<asp:Label ID="lbl_ds_transportador" runat="server" CssClass="texto" ></asp:Label>
                                </TD>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Placa:</td>
                                <TD style="HEIGHT: 20px; width: 235px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_ds_placa" runat="server" CssClass="texto" ></asp:Label>
                                    </td>
                            </tr>
                            <tr>
								<TD class="texto" align="right" style="height: 24px; width: 141px;" > Data/Hora Entrada:</TD>
								<TD style="height: 24px;" >
					                &nbsp;<asp:Label ID="lbl_dt_hora_entrada" runat="server" CssClass="texto" ></asp:Label>
                                </TD>
                                <TD style="HEIGHT: 24px" align="right">
                                    Re-análise:&nbsp;</td>
                                <TD style="HEIGHT: 24px; width: 235px;">
                                    &nbsp;&nbsp;<asp:Label ID="lbl_reanalise" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 20px; width: 141px;" >
                                </td>
                                <TD style="height: 20px;" >
                                    &nbsp;
                                </td>
                                <TD style="HEIGHT: 20px" align="right">
                                    <asp:CustomValidator ID="cv_reanalise_obrigatorias" runat="server" CssClass="texto"
                                        ErrorMessage="CustomValidator" ForeColor="White" ValidationGroup="vg_registrar">[!]</asp:CustomValidator>&nbsp;</td>
                                <TD style="HEIGHT: 20px; width: 235px;" align="center">
                                    &nbsp;&nbsp;
                                    <anthem:ImageButton ID="btn_reanalise" runat="server" CssClass="texto" ImageUrl="~/img/btn_gerar_reanalise.gif"
                                        ValidationGroup="vg_registrar" AutoUpdateAfterCallBack="True" OnClientClick="if (confirm('Este processo substitui todas as análises existentes no Romaneio por novas a serem avaliadas. Deseja realmente prosseguir com a Re-Análise?' )) return true;else return false;" /></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="width: 141px; height: 2px">
                                </td>
                                <td style="height: 2px">
                                </td>
                                <td align="right" style="height: 2px">
                                </td>
                                <td style="width: 235px; height: 2px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="height: 47px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 715px;" vAlign="middle" background="img/faixa_filro.gif">
						</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 715px;">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
                <tr style="height: 13px">
					<TD style="height: 4px; width: 9px;"></TD>
					<TD vAlign="bottom" style="width: 100%; height: 4px;" class="texto">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="0"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="Horizontal" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="6" DataKeyNames="id_romaneio" ShowHeader="False" CssClass="texto" Height="40px" AddCallBacks="False">
                            <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Top" />
                            <EditRowStyle BackColor="#2461BF" VerticalAlign="Top" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField  >
                                    <itemtemplate>
&nbsp; <TABLE style="WIDTH: 100%; HEIGHT: 8px" class="texto" cellSpacing=0 border=0><TBODY><TR style="BACKGROUND-COLOR: #9bc5ff"><TD style="WIDTH: 3%; HEIGHT: 5px" colSpan=1></TD><TD style="WIDTH: 60%; HEIGHT: 5px" colSpan=5><asp:Label id="Label1" runat="server" Width="40%" __designer:wfdid="w84" Text="Análise do Compartimento" Font-Bold="True"></asp:Label> <asp:Label id="lbl_ds_compartimento" runat="server" __designer:wfdid="w85" Text='<%# Bind("ds_compartimento") %>'></asp:Label> </TD><TD style="WIDTH: 20%; HEIGHT: 5px" align=center>Placa <asp:Label id="lbl_ds_placa_compartimento" runat="server" __designer:wfdid="w86" Text='<%# Bind("ds_placa") %>'></asp:Label> </TD><TD style="WIDTH: 10%; HEIGHT: 5px" align=center><asp:Label id="lbl_nm_st_compartimento" runat="server" __designer:wfdid="w87" Text='<%# Bind("nm_st_analise") %>'></asp:Label></TD><TD style="WIDTH: 5%; HEIGHT: 5px">&nbsp;<asp:ImageButton id="btn_RegistrarAnaliseCompartimento" runat="server" ImageUrl="~/img/icon_registrar.gif" Width="24px" __designer:wfdid="w88" CommandName="Registrar_Analise_Compartimento" CommandArgument='<%# Bind("id_romaneio_compartimento") %>' ToolTip="Registrar Análise do Compartimento" ></asp:ImageButton><asp:Label id="lbl_id_romaneio_compartimento" runat="server" __designer:wfdid="w89" Text='<%# Bind("id_romaneio_compartimento") %>' Visible="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 7px" colSpan=2></TD><TD style="WIDTH: 95%; HEIGHT: 7px" colSpan=7><asp:GridView id="gridAnalisesUproducao" runat="server" CssClass="texto" DataKeyNames="id_romaneio_uproducao" Width="100%" CellPadding="0" AutoGenerateColumns="False" __designer:wfdid="w90"><Columns>
<asp:TemplateField><ItemTemplate>
<asp:Label id="Label2" runat="server" Font-Bold="True" Text="Análise Unid. Produção" __designer:wfdid="w39"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade"></asp:BoundField>
<asp:BoundField DataField="ds_uproducao" HeaderText="Unid. Produ&#231;&#227;o"></asp:BoundField>
<asp:BoundField DataField="ds_pessoa" HeaderText="Produtor"></asp:BoundField>
<asp:BoundField DataField="nm_status_analise_uproducao" HeaderText="Situa&#231;&#227;o" ShowHeader="False"></asp:BoundField>
<asp:TemplateField>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
<asp:ImageButton id="btn_registrar_analise_uproducao" runat="server" ImageUrl="~/img/icon_registrar.gif" __designer:wfdid="w111" ToolTip="Registrar Análise Unid. Produção / Produtor" CommandArgument='<%# Bind("id_romaneio_uproducao") %>' CommandName="Registrar_Analise_UProducao" OnCommand="btn_registrar_analise_uproducao_Command"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="id_romaneio_compartimento" Visible="False"></asp:BoundField>
</Columns>

<PagerStyle VerticalAlign="Top"></PagerStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Position="Top" />
                       </anthem:GridView>
                    </TD>
					<TD style="height: 4px"></TD>
                </tr>				
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; width: 715px;">&nbsp;&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
		</form>
	</body>
</HTML>
