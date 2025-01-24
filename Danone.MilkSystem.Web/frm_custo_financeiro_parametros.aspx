<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_custo_financeiro_parametros.aspx.vb" Inherits="frm_custo_financeiro_parametros" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo Financeiro - Parâmetros</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Custo Financeiro - Parâmetros</STRONG></TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto" >
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; | &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <anthem:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar" Enabled="False" AutoUpdateAfterCallBack="True">Salvar</anthem:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                        <tr>
                                            <td align="right" class="texto" style="height: 27px; width: 18%;">
                                                <span class="obrigatorio">*</span><strong>Ano:</strong></td>
                                            <td style="height: 27px" class="texto">
                                                &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ano" runat="server" CssClass="texto"
                                                    Width="80px" MaxLength="4"></cc3:OnlyNumbersTextBox>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_ano"
                                                    CssClass="texto" ErrorMessage="Ano com formato incorreto." MaximumValue="2100"
                                                    MinimumValue="2000" ToolTip="Ano  com formato incorreto." Type="Integer" ValidationGroup="vg_incluir">[!]</asp:RangeValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Ano para continuar."
                                                    Font-Bold="False" ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator ID="cv_custo" runat="server" CssClass="texto" ForeColor="White"
                                                    ValidationGroup="vg_incluir">[!]</anthem:CustomValidator>&nbsp;<anthem:Button ID="btn_incluirperiodo"
                                                        runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Text="Incluir Novo Período" ValidationGroup="vg_incluir" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <strong>Último Ano Referência cadastrado:&nbsp; </strong><anthem:Label ID="lbl_ultimo_ano" runat="server" AutoUpdateAfterCallBack="True" Font-Italic="False"
                                                    Font-Size="X-Small" UpdateAfterCallBack="True">2022</anthem:Label></td>
                                        </tr>
                                        <tr id="tr_valores" runat="server" visible="false">
											<TD class="titmodulo"  colSpan="2" style="height: 22px"> Valores dos Custos Financeiros</TD>
                                        </tr>
                                        <tr  >
                                            <td align="right" class="texto" style="height: 5px; " valign="top">
                                            </td>
                                            <td align="left" style="height: 5px" >
                                                </td>
                                        </tr>
                                        <tr  >
                                            <td align="center" class="texto" valign="top" colspan="2">
                                                <anthem:GridView ID="gridcusto" runat="server"
                                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                    Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="100" UpdateAfterCallBack="True"
                                                    Width="99%" Visible="False">
                                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Tipo Custo" ReadOnly="True" DataField="nm_tipo_custo_financeiro">
                                                            <itemstyle horizontalalign="Left" wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="st_sistema" HeaderText="Obrig">
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:BoundField>
                    <asp:TemplateField HeaderText="Janeiro">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes1" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_01") %>' MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w279" OnTextChanged="txt_mes1_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                        <itemstyle horizontalalign="Center" wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fevereivo">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes2" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_02") %>' MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w257" OnTextChanged="txt_mes2_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mar&#231;o">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes3" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_03") %>' MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w259" OnTextChanged="txt_mes3_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Abril">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes4" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_04") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w261" OnTextChanged="txt_mes4_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Maio">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes5" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_05") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w263" OnTextChanged="txt_mes5_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Junho">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes6" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_06") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w265" OnTextChanged="txt_mes6_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Julho">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes7" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_07") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w267" OnTextChanged="txt_mes7_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agosto">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes8" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_08") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w269" OnTextChanged="txt_mes8_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Setembro">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes9" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_09") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w271" OnTextChanged="txt_mes9_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Outubro">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes10" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_10") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w275" OnTextChanged="txt_mes10_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Novembro">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes11" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_11") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w273" OnTextChanged="txt_mes11_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dezembro">
                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes12" runat="server" MaxLength="15" Width="70px" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_12") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w277" OnTextChanged="txt_mes12_TextChanged" AutoPostBack="True"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                        <itemstyle horizontalalign="Center" />
                    </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_custo_financeiro" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_custo_financeiro" runat="server" Text='<%# bind("id_custo_financeiro") %>' __designer:wfdid="w177"></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_tipo_custo_financeiro" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_tipo_custo_financeiro" runat="server" Text='<%# bind("id_tipo_custo_financeiro") %>' __designer:wfdid="w100"></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </anthem:GridView>
                                            </td>
                                        </tr>
									</TABLE>
								</TD>
								<TD width="1px" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
    				<TD vAlign="top" align="center" background="images/faixa_filro.gif" ></TD>
    				<TD>
    					<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD class="faixafiltro1a" vAlign="middle" align="left" background="img/faixa_filro.gif">
                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" />
                                <anthem:LinkButton ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" Enabled="False">Salvar</anthem:LinkButton></TD>
							<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" >&nbsp;</TD>
						</TR>
					</TABLE>
				</TD>
				<TD ></TD>
			</TR>

				<TR>
					<TD >&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>&nbsp;
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir" />
</form>
	</body>
</HTML>
