<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_usuario_log.aspx.vb" Inherits="lst_usuario_log" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Usuário - LOG</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Usuário - LOG</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 22px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px; width: 14%;"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="width: 38%; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 21px" align="right">&nbsp;<strong><span style="color: #ff0000">*</span></strong>Período:</td>
                                <TD style="HEIGHT: 21px">
                                    &nbsp;<cc3:OnlyDateTextBox ID="txt_dt_inicio" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" DateMask="DayMonthYear" Width="90px" Columns="10"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server" AutoUpdateAfterCallBack="True" Columns="10" CssClass="texto" DateMask="DayMonthYear" Width="90px"></cc3:OnlyDateTextBox>
                                    
                                    <anthem:RequiredFieldValidator ID="rf_dt_inicio" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="True" ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="rf_dt_fim" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_fim"
                                            CssClass="texto" ErrorMessage="A referência final do período deve ser informada."
                                            Font-Bold="True" ToolTip="A referência final do período deve ser informada."
                                            ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                ID="cv_data" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="A Data de Início do período não pode ser maior que a data fim de período."
                                                ValidationGroup="vg_pesquisa">[!]</anthem:CustomValidator></td>
                                <td align="right" style="height: 21px">
                                    &nbsp;Tipo LOG:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_tipo_log" runat="server" CssClass="texto">
                                    </asp:DropDownList></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 21px">
                                    Menu:</td>
								<td style="height: 21px">
                                    &nbsp;&nbsp;<anthem:DropDownList id="cbo_menu" runat="server" CssClass="texto" AutoPostBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 21px">
                                    Item Menu:</td>
                                <td style="height: 21px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_menu_item" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Login:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_ds_login" runat="server" CssClass="texto" Width="100px" MaxLength="50"></asp:TextBox></td>
                                <td align="right" style="height: 21px">
                                    </td>
                                <td style="height: 21px">
                                    <anthem:RadioButtonList ID="opt_log" runat="server" CssClass="texto"
                                        RepeatDirection="Horizontal" AutoUpdateAfterCallBack="True">
                                        <Items>
                                            <asp:ListItem Selected="True" Value="A">Log Acessos</asp:ListItem>
                                            <asp:ListItem Value="C">Log Cr&#237;ticos</asp:ListItem>
                                        </Items>
                                    </anthem:RadioButtonList></td>
                            </tr>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisa"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisa" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_usuario_log" Visible="False">
                            <Columns>
                                <asp:BoundField DataField="ds_login" HeaderText="Login" SortExpression="ds_login" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_criacao" HeaderText="Data" SortExpression="dt_criacao" ReadOnly="True" >
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_log" HeaderText="Tipo LOG" ReadOnly="True"
                                    SortExpression="nm_tipo_log">
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_menu" HeaderText="Menu" ReadOnly="True" SortExpression="nm_menu" />
                                <asp:BoundField DataField="nm_menu_item" HeaderText="Item Menu" ReadOnly="True"
                                    SortExpression="nm_menu_item">
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_nm_processo" HeaderText="Processo" SortExpression="ds_nm_processo">
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_nr_processo" HeaderText="Nr ID" />
                                <asp:BoundField DataField="ds_id_session" HeaderText="IDSession" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                        </anthem:GridView><anthem:GridView ID="gridCriticos" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" Visible="False">
                                            <Columns>
                                                <asp:BoundField DataField="ds_login" HeaderText="Login" ReadOnly="True" SortExpression="ds_login" />
                                                <asp:BoundField DataField="dt_criacao" HeaderText="Data" ReadOnly="True" SortExpression="dt_criacao" />
                                                <asp:BoundField DataField="nm_menu" HeaderText="Menu" ReadOnly="True" SortExpression="nm_menu" />
                                                <asp:BoundField DataField="nm_menu_item" HeaderText="Item Menu" ReadOnly="True" SortExpression="nm_menu_item" />
                                                <asp:BoundField DataField="nm_erro" HeaderText="Erro" ReadOnly="True" SortExpression="nm_erro" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisa"  />
                	    <div visible="false">
                            &nbsp;</div>
		</form>
	</body>
</HTML>
