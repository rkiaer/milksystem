<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_manutencao.aspx.vb" Inherits="lst_poupanca_manutencao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Mais Sólidos - Manutenção Site</title>
	<link href="css/estilo.css" type="text/css" rel="stylesheet" />
</head>

	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Mais Sólidos - Manutenção Site</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 2px;"></TD>
					<TD align="center" style="height: 2px">
						</TD>
					<TD style="height: 2px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD width="15%" style="width: 20%; height: 23px;" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 23px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="Texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    </td>
								<td style="height: 23px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
    	                        </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 23px;" >
                                    Período Referência Poupança:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>&nbsp;
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>
                                    <anthem:CompareValidator ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToCompare="txt_dt_fim" ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                        Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                        Type="Date" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
                                <td style="height: 23px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px">
                                    <strong><span style="color: #ff0000">*</span></strong>Situação Poupança:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_situacao_poupanca" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_situacao_poupanca"
                                        ErrorMessage="Informe a Situação do Programa Mais Sólidos que deseja visualizar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
							<tr>
			                    <td align="right" style="width: 20%; height: 25px"></td>
			                    <td align="right" style="height: 25px"></td>
								<TD align="right" style="height: 25px">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;" class="texto">
                        &nbsp;</td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" >
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" DataKeyNames="id_poupanca_parametro"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None"
                            PageSize="7" UpdateAfterCallBack="True" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" SortExpression="ds_estabelecimento">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_referencia_ini" HeaderText="Ref. Inicial"
                                    SortExpression="dt_referencia_ini">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_referencia_fim" HeaderText="Ref. Final" />
                                <asp:BoundField DataField="dt_adesao_limite" HeaderText="Data Limite Termo" ReadOnly="True" SortExpression="dt_adesao_limite" />
                                <asp:TemplateField HeaderText="Documento Anexado">
                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" Text='<%# bind("nm_documento") %>' ToolTip="Clique aqui para download do arquivo"></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_situacao_poupanca" HeaderText="Situa&#231;&#227;o Poupan&#231;a" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" CommandArgument='<%# Bind("id_poupanca_parametro") %>' CommandName="edit" ImageUrl="~/img/icone_editar.gif"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CommandArgument='<%# Bind("id_poupanca_parametro") %>' CommandName="delete" ImageUrl="~/img/icone_excluir.gif" Visible="False" OnClientClick="if (confirm('Deseja realmente excluiur o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="6%" />
                                    <itemstyle horizontalalign="Center" width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_poupanca" runat="server" Text='<%# Bind("id_situacao_poupanca") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_poupanca_parametro" HeaderText="id_poupanca_parametro"
                                    ReadOnly="True" Visible="False" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        </TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:AlertMessages ID="messageControl" runat="server"></cc1:AlertMessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
            &nbsp;
            &nbsp;&nbsp;<anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_aderir"  AutoUpdateAfterCallBack="true" />
            &nbsp;<anthem:HiddenField ID="hf_dt_referencia_ini" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_dt_referencia_fim" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
