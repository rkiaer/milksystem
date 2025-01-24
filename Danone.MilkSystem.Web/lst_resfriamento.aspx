<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_resfriamento.aspx.vb" Inherits="lst_resfriamento" %>

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
		<title>Resfriamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)">
                        <strong>Resfriamento</strong></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" class="texto" valign="middle" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 5px; width:20%"></TD>
								<TD style="height: 5px"></TD>
                                <td style="width: 18%; height: 5px">
                                </td>
                                <td style="width: 25%; height: 5px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 26px">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:
                                </td>
                                <td colspan="" style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="rf_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" ErrorMessage="O Estabelecimento deve ser preenchido."
                                        InitialValue="0" ToolTip="O Estabelecimento deve ser preenchido." ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" colspan="" style="height: 26px">
                                    <strong><span style="color: #ff0000">*</span></strong>Unidade Transit Point:</td>
                                <td colspan="" style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="rf_transitpoint" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_transit_point" ErrorMessage="A unidade de Transit Point deve ser preenchida."
                                        InitialValue="0" ToolTip="A unidade de Transit Point deve ser preenchida." ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    <anthem:Label ID="lbl_periodo" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Data Referência:</anthem:Label></td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DateMask="MonthYear" Width="88px"></cc4:OnlyDateTextBox></td>
                                <td align="right" style="height: 25px">
                                    Situação:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_situacao" runat="server"
                                        CssClass="texto">
                                        <asp:ListItem Selected="True" Value="1">Ativo</asp:ListItem>
                                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
                                                        <tr>
                                <td align="right" style="height: 5px">
                                    </td>
                                <td style="height: 5px">
                                    &nbsp;
                                    </td>
                                <td style="height: 5px">
                                </td>
                                <td style="height: 5px">
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
                            id="lk_novo" runat="server">Novo Resfriamento</anthem:linkbutton>&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;" class="texto"></TD>
					<TD vAlign="middle" style="height: 19px" class="texto">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;" class="texto"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_resfriamento">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True" />
                                <asp:BoundField DataField="ds_transit_point_unidade" HeaderText="Unidade TP" ReadOnly="True" />
                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" ReadOnly="True" DataFormatString="{0:MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor" HeaderText="Nr. Valor" ReadOnly="True" DataFormatString="{0:N4}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_situacao" HeaderText="Situa&#231;&#227;o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("id_resfriamento") %>' __designer:wfdid="w3"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" CommandName="delete" CommandArgument='<%# Bind("id_resfriamento") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w4"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="5%" />
                                    <itemstyle horizontalalign="Center" width="5%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        &nbsp;
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
