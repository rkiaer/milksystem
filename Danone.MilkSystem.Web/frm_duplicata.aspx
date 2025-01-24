<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_duplicata.aspx.vb" Inherits="frm_duplicata" %>

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
    <title>Romaneio</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Nota Fiscal - Duplicata</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 5px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 5px" class="texto">
						<TABLE id="Table9" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                        ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top" >
					    <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td style="width: 7px; height: 39px">
                                </td>
                                <td style="height: 39px">
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Dados Nota Fiscal" HorizontalAlign="Center"
                                        Width="100%">
                                        <br />
                                        <table id="Table2" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Estabelecimento:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="height: 20px">
                                                    <strong>CNPJ:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnpj" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Cooperativa:</strong></td>
                                                <td align="left" colspan="3" rowspan="1" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cooperativa" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Nr. Nota Fiscal:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto" Width="80%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong>Série:</strong></td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;<asp:Label ID="lbl_serie" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Data Emissão:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_emissao" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong>Data Transação:</strong></td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;<asp:Label ID="lbl_dt_transacao" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Frete:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_frete" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong>Natureza Operação:</strong></td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;<asp:Label ID="lbl_natureza_operacao" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                </td>
                                <td style="height: 39px">
                                </td>
                            </tr>
						    <TR>
							    <TD style="height: 26px; width: 7px;"  ></TD>
								<TD style="height: 26px" >
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" 
                                        Font-Bold="False" GroupingText="Duplicatas" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" BorderStyle="None" CssClass="texto">
                                        <br />
                                        <table width="98%">
                                            <tr>
                                                <td align="center" class="texto" colspan="4">
                                                    <strong></strong>
                                                    <anthem:GridView ID="grdresults" runat="server"
                                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                        Width="99%" DataKeyNames="id_duplicata_nota">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Nr Parcela">
                                                                <edititemtemplate>
<asp:Label id="lbl_nr_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_parcela") %>' __designer:wfdid="w52"></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_parcela") %>' __designer:wfdid="w38"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nr Duplicata">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><cc3:OnlyNumbersTextBox id="txt_nr_duplicata" runat="server" Width="88px" CssClass="texto" Text='<%# Bind("nr_duplicata") %>' __designer:wfdid="w90" MaxLength="7"></cc3:OnlyNumbersTextBox>&nbsp; <asp:RequiredFieldValidator id="rfv_lacre" runat="server" ValidationGroup="vg_duplicata" Font-Bold="True" CssClass="texto" __designer:wfdid="w91" ControlToValidate="txt_nr_duplicata" ErrorMessage="Número do Lacre de entrada deve ser informado.">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_duplicata" runat="server" CssClass="texto" Text='<%# Bind("nr_duplicata") %>' __designer:wfdid="w89"></asp:Label>&nbsp; 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ds_tipo_especie" HeaderText="Tipo Esp&#233;cie" ReadOnly="True" NullDisplayText="N&#227;o Cadastrado" />
                                                            <asp:TemplateField HeaderText="Vencimento">
                                                                <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_vencimento" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" Width="96px" CssClass="texto" Text='<%# bind("dt_vencimento") %>' __designer:wfdid="w93" ErrorMessage="Data Invalida." DateFormat="Brazil" DateMask="DayMonthYear"></cc4:OnlyDateTextBox> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_dt_vencimento" runat="server" CssClass="texto" Text='<%# Bind("dt_vencimento") %>' __designer:wfdid="w92"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Valor Duplicata">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><cc6:OnlyDecimalTextBox id="txt_valor_duplicata" runat="server" Width="96px" CssClass="texto" Text='<%# Bind("nr_valor_duplicata") %>' __designer:wfdid="w12" MaxCaracteristica="10" DecimalSymbol="," MaxMantissa="2"></cc6:OnlyDecimalTextBox>&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_duplicata" __designer:wfdid="w13" ErrorMessage="O valor da duplicata deve ser preenchido!" ControlToValidate="txt_valor_duplicata">[!]</asp:RequiredFieldValidator> <asp:CustomValidator id="cmv_valor_duplicata" runat="server" ValidationGroup="vg_duplicata" __designer:wfdid="w14" ErrorMessage="O total de duplicatas deve ser igual ao total da nota" OnServerValidate="cmv_valor_duplicata_ServerValidate">[!]</asp:CustomValidator>
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_valor_duplicata" runat="server" Text='<%# Bind("nr_valor_duplicata") %>' __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="False">
                                                                <edititemtemplate>
<asp:Label id="lbl_valor_duplicata" runat="server" Text='<%# Eval("nr_valor_duplicata") %>' __designer:wfdid="w40"></asp:Label>
</edititemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_duplicata" ToolTip="Gravar Duplicata" Text="Update" __designer:wfdid="w33" CommandName="Update" CommandArgument='<%# bind("id_duplicata_nota") %>'></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" __designer:wfdid="w34" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_duplicata" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w35"></asp:ValidationSummary> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Lacre" Text="Edit" __designer:wfdid="w31" CommandName="Edit"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Lacre" Text="Edit" __designer:wfdid="w32" CommandName="Delete" CommandArgument='<%# bind("id_duplicata_nota") %>' OnClientClick="if (confirm('Deseja realmente excluir este lacre?' )) return true;else return false;"></asp:ImageButton> 
</itemtemplate>
                                                                <headerstyle width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </anthem:GridView>
                                                    &nbsp;
                                                    <br />
                                                    <anthem:Button ID="btn_novo_lacre" runat="server" AutoUpdateAfterCallBack="True"
                                                        Text="Adicionar" ToolTip="Adicionar novo lacre" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
									
								</TD>
								<TD style="height: 26px"  ></TD>
							</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" style="width: 977px">
					    <TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px; height: 17px;"></TD>
								<TD style="height: 17px">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                        <tr>
                                            <TD style="height: 20px"  >
                                            </td>
                                            <TD style="height: 20px" >
                                            </td>
                                            <TD style="height: 20px"  >
                                            </td>
                                        </tr>
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="true">Salvar</anthem:LinkButton></TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0" style="height: 17px"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"
                UpdateAfterCallBack="True" AutoUpdateAfterCallBack="true"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
