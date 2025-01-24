<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_coleta_amostra_frasco.aspx.vb" Inherits="lst_coleta_amostra_frasco" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_coleta_amostra_frasco</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Frascos para Coleta das Amostras</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD  align="right" style="height: 22px">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="height: 22px" >
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc2:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td align="right" style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<br />
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
					<table class="faixafiltro1a" width="100%">
					<tr>
					<td>						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server" ToolTip="Abrir Nova Referência para Período para Coleta das Amostras">Novo</anthem:linkbutton>
                        &nbsp; &nbsp;
                    </td>
					<td align="right">
                        Última ROTA Carregada do Coletor: &nbsp;<anthem:Label id="lbl_ultima_coleta" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Size="XX-Small"></anthem:Label></td>
					</tr>
					</table>
</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="dt_validade">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_validade" HeaderText="Validade" SortExpression="dt_validade">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderImageUrl="~/img/tampaamarela_peq.png" HeaderText="Frasco1">
                                                    <itemtemplate>
<anthem:Image id="img_chk1" runat="server" ImageUrl="~/img/ico_chk_false.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w1"></anthem:Image> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                    <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_descricao_frasco1" HeaderText="Descr. Coletor" />
                                                <asp:TemplateField HeaderImageUrl="~/img/tampaazul_peq.png" HeaderText="Frasco2">
                                                    <itemtemplate>
<anthem:Image id="img_chk2" runat="server" ImageUrl="~/img/ico_chk_true.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w193"></anthem:Image>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                    <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_descricao_frasco2" HeaderText="Descr. Coletor" />
                                                <asp:TemplateField HeaderImageUrl="~/img/tampabranca_peq.png" HeaderText="Frasco3">
                                                    <itemtemplate>
<anthem:Image id="img_chk3" runat="server" ImageUrl="~/img/ico_chk_true.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w196"></anthem:Image>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                    <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_descricao_frasco3" HeaderText="Descr. Coletor" />
                                                <asp:TemplateField HeaderImageUrl="~/img/tampavermelha_peq.png" HeaderText="Frasco4">
                                                    <itemtemplate>
<anthem:Image id="img_chk4" runat="server" ImageUrl="~/img/ico_chk_true.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w199"></anthem:Image>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                    <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_descricao_frasco4" HeaderText="Descr. Coletor" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w181" CommandArgument='<%# Bind("dt_validade") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w182" CommandArgument='<%# Bind("dt_validade") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="5%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style=" width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" 
                ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
