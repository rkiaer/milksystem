<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_natureza_operacao.aspx.vb" Inherits="lst_natureza_operacao" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_propriedade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Natureza de Operação&nbsp;</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="24%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
							
                            <tr>
                                <td align="right" style="height: 22px" width="24%">
                                    Código Natureza Operação:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_natureza_operacao" runat="server" CssClass="caixaTexto" Width="72px" MaxLength="6"></asp:TextBox></td>
                            </tr>
							<TR>
								<TD width="24%" align="right" style="height: 22px">
                                    Descrição:</TD>
								<TD style="height: 22px">&nbsp;&nbsp;<asp:textbox id="txt_nm_naturezao_operacao" runat="server" cssclass="caixaTexto"
                                        width="20%" MaxLength="35"></asp:textbox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 22px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 22px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_natureza_operacao" HeaderText="C&#243;digo" SortExpression="cd_natureza_operacao" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_natureza_operacao" HeaderText="Descri&#231;&#227;o" SortExpression="nm_natureza_operacao" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_especie_nf" HeaderText="Esp&#233;cie" ReadOnly="True"
                                    SortExpression="nm_especie_nf">
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle width="6%" />
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w34" CommandName="edit" CommandArgument='<%# Bind("id_natureza_operacao") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w2" CommandName="delete" CommandArgument='<%# Bind("id_natureza_operacao") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
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
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
                	    <div visible="false">
        </div>
		</form>
	</body>
</HTML>
