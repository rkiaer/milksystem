<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_preco_cooperativa_aprovar_2N.aspx.vb" Inherits="lst_preco_cooperativa_aprovar_2N" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_preco_negociado_aprovar_2N</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Preço Cooperativas 2.o Nível</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 23px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" valign="middle" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD width="15%" style="HEIGHT: 27px; width: 25%;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 27px; width: 40%;">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
			                    <td width="15%" align="right" style="height: 27px"></td>
								<td style="height: 27px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
    	                        </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    <span class="obrigatorio">*</span>Mês / Ano:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="Informe o Mes/Ano de Referência." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px" >
                                    </td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;Período:</td>
                                <td style="height: 20px">
                                    &nbsp;&nbsp;<anthem:CheckBox ID="chk_1quinz" runat="server" AutoUpdateAfterCallBack="True"
                                        Checked="True" Text="1a.Quinz" />
                                    &nbsp;&nbsp;
                                    <anthem:CheckBox ID="chk_2quinz" runat="server" AutoUpdateAfterCallBack="True" Checked="True"
                                        Text="2a.Quinz" /></td>
                                <td align="right" style="height: 20px">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;</td>
                            </tr>
							<tr>
			                    <td align="right" style="height: 20px"></td>
			                    <td align="right" style="height: 20px"></td>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_aprovar2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar 2.o Nível</anthem:linkbutton>
                        &nbsp;
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton
                            ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                            ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 6px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 6px; ">&nbsp;</TD>
					<TD style="height: 6px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_preco_negociado_cooperativa" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w41" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged"></asp:CheckBox>
</headertemplate>
                                    <itemtemplate>
&nbsp;<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w126"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_periodo" HeaderText="Per&#237;odo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cooperativa" DataField="nm_pessoa" SortExpression="nm_pessoa" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume M-1" DataField="nr_volume_anterior" ReadOnly="True" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Pre&#231;o M-1" DataField="nr_preco_anterior" ReadOnly="True" DataFormatString="{0:n4}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume" DataFormatString="{0:n0}" HeaderText="Volume">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Pre&#231;o">
                                    <edititemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_preco_negociado" runat="server" CssClass="texto" Width="94px" DecimalSymbol="," MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_preco_negociado") %>' MaxLength="15" __designer:wfdid="w128"></cc4:OnlyDecimalTextBox> 
</edititemtemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_preco_negociado" runat="server" CssClass="texto" Text='<%# bind("nr_preco_negociado") %>' __designer:wfdid="w127"></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" SortExpression="nm_aprovado" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_salvar" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:CommandField>
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
					<TD vAlign="top" style="height: 19px; ">&nbsp;
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;
        </div>
		</form>
	</body>
</HTML>
