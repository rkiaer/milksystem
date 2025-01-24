<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_cooperativa_abertura_nota.aspx.vb" Inherits="lst_romaneio_cooperativa_abertura_nota" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_romaneio_cooperativa_abertura_nota</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 26px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 26px;"><STRONG>Abrir Romaneio Cooperativa por Nota Fiscal Eletronica&nbsp;</STRONG></TD>
					<TD width="10" style="height: 26px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%" style="height: 8px; width: 15%;"></TD>
								<TD style="height: 8px; "></TD>
								<TD style="height: 8px; width: 15%;"></TD>
								<TD style="height: 8px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 25px" width="10%">
                                    Estabelecimento:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="False" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td style="height: 25px" align="right">
                                    Local das Notas:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:Label ID="lbl_diretorio" runat="server" Text="..\RomaneioNotas" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							<TR>
								<TD style="height: 12px">
                                <asp:Button ID="btnteste" runat="server" Height="19px" Text="Teste Dir" Visible="False" /></TD>
								<TD style="height: 12px; " valign="bottom">
                                    <anthem:Label ID="lbl_Aguarde" runat="server" AutoUpdateAfterCallBack="True" Font-Italic="True"
                                        ForeColor="Blue" Text="Carregando Notas... Aguarde..." UpdateAfterCallBack="True"
                                        Visible="False"></anthem:Label></TD>
                                <td align="right" colspan="2" valign="bottom">
                                    <anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar" ></anthem:imagebutton>
                                    &nbsp;&nbsp; &nbsp;&nbsp;</td>
							</TR>
                            <tr>
                                <td align="center" colspan="4" style="height: 12px">
                                    &nbsp;</td>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<strong>Selecione a NFe para abrir o Romaneio de Cooperativa:</strong></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 4px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 4px">&nbsp;
                    </TD>
					<TD style="height: 4px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD align="center">
                                    <anthem:GridView ID="gridFiles" runat="server" AddCallBacks="False" AllowPaging="True" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"
                            GridLines="None" PageSize="12" UpdateAfterCallBack="True" Width="98%" DataKeyNames="nm_arquivo" AllowSorting="True">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="CNPJ Emitente">
                                    <itemtemplate>
<asp:Label id="lbl_cnpj_cooperativa" runat="server" Text='<%# Bind("cd_cnpj_emitente") %>' __designer:wfdid="w97"></asp:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Nome">
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CNPJ Transp.">
                                    <itemtemplate>
<asp:Label id="lbl_cnpj_transportador" runat="server" Text='<%# Bind("cd_cnpj_transportador") %>' __designer:wfdid="w298"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Nome">
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Nr. NF">
                                    <itemtemplate>
<asp:Label id="lbl_nr_nota_fiscal" runat="server" Text='<%# Bind("nr_nota_fiscal") %>' __designer:wfdid="w299"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chave NF" ShowHeader="False" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_ds_chave" runat="server" Text='<%# Bind("ds_chave") %>' __designer:wfdid="w300"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome do Arquivo" SortExpression="nm_arquivo">
                                    <itemtemplate>
<asp:Label id="lbl_nm_arquivo" runat="server" Text='<%# Bind("nm_arquivo") %>' __designer:wfdid="w301"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Abrir">
                                    
                                    <itemtemplate>
<anthem:ImageButton id="btn_abrir" onclick="btn_abrir_Click" runat="server" ValidationGroup="vg_abrir" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w119" ImageUrl="~/img/abrir_romaneio.gif" ToolTip="Abrir Romaneio Cooperativa" Enabled="False"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle wrap="False" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_cooperativa" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_cooperativa" runat="server" Text='<%# Bind("id_cooperativa") %>' __designer:wfdid="w294"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" Text='<%# Bind("id_transportador") %>' __designer:wfdid="w295"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_modelo_frete" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_modelo_frete" runat="server" Text='<%# Bind("nr_modelo_frete") %>' __designer:wfdid="w304"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_serie" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_serie" runat="server" Text='<%# Bind("nr_serie") %>' __designer:wfdid="w286"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="dt_emissao" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_dt_emissao" runat="server" Text='<%# Bind("dt_emissao") %>' __designer:wfdid="w290"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_nf" runat="server" Text='<%# Bind("nr_valor_nf") %>' __designer:wfdid="w101"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_peso_liquido_nota" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_peso_liquido_nota" runat="server" Text='<%# Bind("nr_peso_liquido_nota") %>' __designer:wfdid="w100"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="serro" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_serro" runat="server" Text='<%# Bind("serro") %>' __designer:wfdid="w99"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_po_cooperativa" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_po_cooperativa" runat="server" Text='<%# Bind("nr_po_cooperativa") %>' __designer:wfdid="w98"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cfop" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_cd_cfop" runat="server" Text='<%# bind("cd_cfop") %>' __designer:wfdid="w102"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        &nbsp;&nbsp;</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_abrir" />
		</form>
	</body>
</HTML>
