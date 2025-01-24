<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_cep.aspx.vb" Inherits="lst_cep" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>CEP</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	


		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)">
                        <strong>CEP</strong></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width:20%"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="width: 25%; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    <span style="color: #ff0000"><strong>*</strong></span>Estado:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estado" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estado"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estado para continuar." Font-Bold="True"
                                        ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td style="height: 21px" align="right">
                                    &nbsp;Cidade:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList></td>
                            </tr>
                                                        <tr>
                                <td align="right" style="height: 21px">
                                    CEP:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_cep" runat="server" CssClass="texto" MaxLength="8"
                                        Width="88px"></cc3:OnlyNumbersTextBox>
                                    <span style="color: #ff0000; font-size: xx-small; font-style: italic;">(somente números)</span></td>
                                <td style="height: 21px">
                                </td>
                                <td style="height: 21px">
                                </td>
                            </tr>

							<tr>
								<TD>&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton>
                        &nbsp;
                        &nbsp;</TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_cep">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ds_estado" HeaderText="Estado" ReadOnly="True" SortExpression="ds_estado" />
                                <asp:BoundField DataField="nm_cidade" HeaderText="Cidade" SortExpression="nm_cidade" />
                                <asp:BoundField DataField="cd_cep" HeaderText="Cod CEP" ReadOnly="True" SortExpression="cd_cep" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("id_cep") %>' __designer:wfdid="w25"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" CommandName="delete" CommandArgument='<%# Bind("id_cep") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w26"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
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
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
                	    <div visible="false">
                            &nbsp;</div>
		</form>
	</body>
</HTML>
