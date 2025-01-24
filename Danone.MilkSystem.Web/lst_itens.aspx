<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_itens.aspx.vb" Inherits="lst_itens" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_itens</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Item</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_item" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="16"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD width="20%" align="right" style="height: 20px">&nbsp;Nome:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;<anthem:textbox id="txt_nm_item" runat="server" cssclass="caixaTexto"
                                        width="224px" MaxLength="60"></anthem:textbox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Grupo:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_cd_grupo" runat="server" CssClass="texto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    Categoria:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_categoria" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<!-- <TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD> -->
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server">Novo</anthem:LinkButton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_item" HeaderText="C&#243;digo" SortExpression="cd_item" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Nome" SortExpression="nm_item" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_deposito" HeaderText="Dep&#243;sito" SortExpression="cd_deposito" />
                                                <asp:BoundField DataField="cd_classificacao_fiscal" HeaderText="Classifica&#231;&#227;o Fiscal"
                                                    SortExpression="cd_classificacao_fiscal" />
                                                <asp:BoundField DataField="ds_unidade_medida" HeaderText="Unidade de Medida" SortExpression="ds_unidade_medida" />
                                                <asp:BoundField DataField="ds_grupo_itens" HeaderText="Grupo" SortExpression="ds_grupo_itens" />
                                                <asp:BoundField DataField="ds_conta" HeaderText="Conta" SortExpression="ds_conta" />
                                                <asp:BoundField DataField="nm_categoria_item" HeaderText="Categoria" SortExpression="nm_categoria_item" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_item") %>' CommandName="edit" __designer:wfdid="w1"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandArgument='<%# Bind("id_item") %>' CommandName="delete" __designer:wfdid="w2" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
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
		</form>
	</body>
</HTML>
