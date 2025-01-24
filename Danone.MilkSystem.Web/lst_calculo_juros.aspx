<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_calculo_juros.aspx.vb" Inherits="lst_calculo_juros" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_calculo_juros</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Cálculo - Valor de Juros</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 23px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
                            <tr>
                                <td align="right" style="height: 10px">
                                </td>
                                <td style="height: 10px">
                                </td>
                                <td align="right" class="texto" colspan="" style="height: 10px">
                                </td>
                                <td colspan="" style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 23px; width: 22%;" align="right">
                                    Referência:&nbsp;</td>
                                <TD style="HEIGHT: 23px; width: 25%;">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="70px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox>
                                    </td>
                                <td align="right" class="texto" colspan="" style="width: 12%; height: 23px">
                                    </td>
                                <td colspan="" style="height: 23px">
                                    &nbsp;
                                    </td>
                            </tr>
							<TR>
                                <td align="right" colspan="4" style="height: 26px">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</td>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				               <tr>
                    <td style="width: 9px">
                        &nbsp;</td>
                    <td id="Td2" runat="server" style="font-size: 8px" align="center">
                           <table id="Table8" cellpadding="0" cellspacing="0" class="borda texto" style="border-top-style: none;
                            border-right-style: none; border-left-style: none; border-bottom-style: none"
                            width="100%">
                            <tr>
                                <td style="font-size: x-small;">
                                </td>
                                <td style="height: 12px" align="left">
                                </td>
                                <td align="right" style="height: 12px">
                                </td>
                                <td style="height: 12px;" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px;  width: 20%;">
                                    <strong>Referência:&nbsp;
                                        <cc2:OnlyDateTextBox ID="txt_novo_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" DateMask="MonthYear" Width="70px"></cc2:OnlyDateTextBox>
                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_novo_referencia"
                                            CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar." Font-Bold="True"
                                            ToolTip="A referência deve ser informada." ValidationGroup="vg_novo">[!]</anthem:RequiredFieldValidator>&nbsp;</strong></td>
                                <td style="height: 22px;" align="left">
                                    &nbsp; <strong>Valor de Juros:&nbsp;
                                        <cc3:OnlyDecimalTextBox ID="txt_novo_valor" runat="server" CssClass="texto" MaxMantissa="5"
                                            Width="105px" AutoUpdateAfterCallBack="True"></cc3:OnlyDecimalTextBox>
                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_novo_valor"
                                            CssClass="texto" ErrorMessage="Preencha o campo Valor do Juros para continuar."
                                            Font-Bold="True" ToolTip="O campo Valor do Juros deve ser informado." ValidationGroup="vg_novo">[!]</anthem:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cv_novo" runat="server" CssClass="texto" Font-Bold="true"
                                            ForeColor="White" Text="[!]" ValidationGroup="vg_novo"></asp:CustomValidator>
                                        &nbsp; &nbsp;
                                        &nbsp; &nbsp;&nbsp;
                                    <anthem:Button ID="btn_nova_taxa" runat="server" Text="Adicionar Novo Valor" ToolTip="Adicionar novo valor de juros." CssClass="texto" ValidationGroup="vg_novo" /></strong></td>
                                <td align="right" style="height: 22px; font-size: x-small;">
                                </td>
                                <td style="height: 22px; font-size: x-small;" align="left">
                                    </td>
                            </tr>
                        </table>
                     <table id="Table6" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 9px; height: 19px">
                                </td>
                                <td align="left" class="titmodulo" style="height: 19px">
                                    </td>
                                <td style="width: 10px; height: 19px">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10px">
                        &nbsp;</td>
                </tr>

				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_calculo_juros" PageSize="15">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" SortExpression="ds_referencia">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor" HeaderText="Valor" SortExpression="nr_valor" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# bind("id_calculo_juros") %>' OnClientClick="if (confirm('Deseja realmente excluiur o registro?' )) return true;else return false;" __designer:wfdid="w35"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="6%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao" runat="server" Text='<%# Bind("id_situacao") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_referencia" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" Text='<%# Bind("dt_referencia") %>' __designer:wfdid="w54"></asp:Label>
</itemtemplate>
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
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False"   ValidationGroup="vg_novo" />
		</form>
	</body>
</HTML>
