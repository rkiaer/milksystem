<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_contrato.aspx.vb" Inherits="lst_central_contrato" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Central de Compras - Contrato</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>CENTRAL DE COMPRAS - CONTRATO / EM GRUPO</STRONG></TD>
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
                                <td align="right" style="height: 5px">
                                </td>
                                <td colspan="2" style="height: 5px">
                                </td>
                                <td align="right" class="texto" colspan="" style="height: 5px">
                                </td>
                                <td colspan="" style="height: 5px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 23px; width: 22%;" align="right">
                                    &nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 23px; width: 28%;" colspan="2">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    </td>
                                <td align="right" class="texto" colspan="" style="width: 12%; height: 23px">
                                    Referência a partir de:</td>
                                <td colspan="" style="width: 38%; height: 23px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="88px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Código do Contrato / Em Grupo:</td>
                                <td colspan="2" style="height: 25px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" Width="88px"></cc3:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 25px">
                                    &nbsp;Nome Fornecedor:</td>
                                <td align="left" class="texto" style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_fornecedor" runat="server" CssClass="caixatexto" MaxLength="50" AutoUpdateAfterCallBack="True"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Tipo:</td>
                                <td style="height: 25px" colspan="2">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_tipo_contrato" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Value="C">Contrato</asp:ListItem>
                                        <asp:ListItem Value="P">Em Grupo</asp:ListItem>
                                        <asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 25px">
                                    &nbsp;Situação Contrato:</td>
                                <td align="left" style="height: 25px" class="texto">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_situacao_contrato" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Value="1">Aberto</asp:ListItem>
                                        <asp:ListItem Value="2">Finalizado</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 25px" align="right">
                                    Nome Item:&nbsp;</td>
                                <td align="left" colspan="2" style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_item" runat="server" CssClass="caixatexto" MaxLength="50"></anthem:TextBox></td>
                                <td style="height: 25px" align="right">
                                    </td>
                                <td align="left" style="height: 25px">
                                </td>
							</TR>
							<TR>
                                <td align="right" colspan="5" style="height: 30px">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;
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
                            id="lk_novo" runat="server">Novo</anthem:linkbutton>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_central_contrato">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_central_contrato" HeaderText="C&#243;digo" SortExpression="id_central_contrato" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_tipo_central_contrato" HeaderText="Tipo" ReadOnly="True"
                                                    SortExpression="ds_tipo_central_contrato">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_descricao_contrato" HeaderText="Descri&#231;&#227;o" SortExpression="ds_descricao_contrato" />
                                                <asp:BoundField DataField="dt_inicio_contrato" HeaderText="In&#237;cio" SortExpression="dt_inicio_contrato" DataFormatString="{0:MM/yyyy}">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_fim_contrato" HeaderText="Fim" DataFormatString="{0:MM/yyyy}">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Fornecedor" SortExpression="nm_abreviado_fornecedor" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Item" SortExpression="nm_item" />
                                                <asp:BoundField DataField="nm_situacao_contrato" HeaderText="Situa&#231;&#227;o Contrato" SortExpression="nm_situacao_contrato" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandName="edit" __designer:wfdid="w943"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" OnClientClick="if (confirm('Ao desativar uma validade do contrato, caso não haja outras referências válidas, todos os produtores ligados a este contrato serão atualizados com contrato comercial. Deseja realmente excluiur o registro?' )) return true;else return false;" UpdateAfterCallBack="True" CommandName="delete" Visible="False" __designer:wfdid="w944"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="6%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_contrato">
                                                    <itemtemplate>
<asp:Label id="lbl_id_contrato" runat="server" Text='<%# Bind("id_central_contrato") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_tipo_central_contrato" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_central_contrato" runat="server" Text='<%# Bind("st_tipo_central_contrato") %>' __designer:wfdid="w945"></asp:Label>
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
                ShowSummary="False" Style="z-index: 100; left: 132px; position: absolute; top: 578px"
                ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
