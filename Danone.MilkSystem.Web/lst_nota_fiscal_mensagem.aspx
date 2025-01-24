<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_nota_fiscal_mensagem.aspx.vb" Inherits="lst_nota_fiscal_mensagem" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_nota_fiscal_mensagem</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>Nota Fiscal Mensagem</STRONG></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<td width="10"></td>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 20px; text-align: right;">
                                    </TD>
								<TD style="height: 20px; width: 758px;">
                                    &nbsp;&nbsp;
                                    </TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px; width: 758px;">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto" Width="96px" TabIndex="1">
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right" style="width: 758px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<BR>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_mensagem_lst" HeaderText="Mensagem" SortExpression="ds_mensagem_lst" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_incentivo_21" HeaderText="Incentivo Fiscal 2,1" SortExpression="st_incentivo_21" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_incentivo_24" HeaderText="Incentivo Fiscal 2,4" SortExpression="st_incentivo_24" />
                                                <asp:BoundField DataField="st_incentivo_25" HeaderText="Incentivo Fiscal 2,5"
                                                    SortExpression="st_incentivo_25" />
                                                <asp:BoundField DataField="st_transferencia_credito" HeaderText="Transfer&#234;ncia Cr&#233;dito"
                                                    SortExpression="st_transferencia_credito" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w1" CommandArgument='<%# Bind("id_nota_fiscal_mensagem") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w2" CommandArgument='<%# Bind("id_nota_fiscal_mensagem") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="10%" />
                                                    <itemstyle horizontalalign="Center" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>&nbsp;&nbsp;&nbsp;
		</form>
	</body>
</HTML>
