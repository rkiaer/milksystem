<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_analise_global.aspx.vb" Inherits="frm_romaneio_analise_global" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_calculo_acompanhamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" >
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD  class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 971px; height: 25px;"><STRONG>Registrar Análise Global&nbsp;</STRONG></TD>
					<TD style="width: 10px; height: 25px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 10px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px; width: 971px;">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp;<asp:LinkButton ID="lk_analise_uproducao" runat="server" Visible="False">Registrar Análises das Unidades Produção / Produtores</asp:LinkButton>&nbsp;|&nbsp;
                                    <asp:LinkButton ID="lk_analise_compartimento" runat="server" Visible="False">Registrar Análises dos Compartimentos</asp:LinkButton>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 10px; width: 10px;">&nbsp;</TD>
				</TR>
			    <TR>
				    <TD style="width: 9px; height: 81px"  ></TD>
					<TD style="width: 971px; height: 81px" >
                        <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"
                            Font-Size="XX-Small" Height="24px" HorizontalAlign="Center"
                            Width="99%" CssClass="texto" GroupingText="Romaneio">

                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" style="height: 72px">
			                    <TR>
				                    <TD class="texto" align="right" style="height: 20px;width:18%"><STRONG>Nr. Romaneio:</STRONG></TD>
				                    <TD style="width:203px; height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto" Width="100%"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:22%; height: 20px;" ><STRONG>Situação Romaneio:</STRONG></TD>
				                    <TD style="width:32%; height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto" Width="80%"></asp:Label></TD>
			                    </TR>
			                    <TR>
			                        <TD class="texto" align="right" style="height: 20px;" ><STRONG>Estabelecimento:</STRONG></TD>
                                    <TD style=" height: 20px; width: 203px;" align="left" >&nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto" Width="176px"></asp:Label></TD>
				                    <TD class="texto" align="right" style="height: 20px" ><STRONG>Transportador:</STRONG></TD>
				                    <TD style="height: 20px" align="left">&nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto" Width="176px"></asp:Label></TD>
			                    </TR>
			                    <TR>
				                    <TD class="texto" align="right" style="height: 20px;" ><STRONG class="texto">Entrada:</STRONG></TD>
				                    <TD style="height: 20px; width: 203px;" align="left" >&nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto" Width="176px"></asp:Label></TD>
				                    <TD class="texto" align="right" style="height: 20px" ><STRONG>Saída:</STRONG></TD>
				                    <TD align="left" style="height: 20px" >&nbsp;<asp:Label ID="lbl_saida" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
			                    <TR>
				                    <TD class="texto" align="right" style="height: 22px;" ><STRONG class="texto">Placas:</STRONG></TD>
				                    <TD  style="height: 22px; width: 203px;" align="left" >&nbsp;<asp:Label ID="lbl_placas" runat="server"  CssClass="texto" Width="176px"></asp:Label></TD>
				                    <TD class="texto" align="right" style="height: 22px" ><STRONG class="texto"></STRONG></TD>
				                    <TD style="height: 22px; " align="left" >&nbsp;</TD>
			                    </TR>
			                    <TR>
				                    <TD colspan="4" style="height: 6px"></TD>
			                    </TR>
			                </table>
			            </asp:Panel>
			        </td>
					<TD style="width: 10px; height: 81px;"  ></TD>
                </tr>
                <tr>
					<TD style="width: 10px; height: 54px;"  ></TD>
			        <td style="height: 54px; width: 971px;" align="center">
                        <asp:Panel ID="pnlStatusAnalises" runat="server" BackColor="White" Font-Bold="False"
                            Font-Size="XX-Small" GroupingText="Situação das Análises" Height="24px" HorizontalAlign="Center"
                            Width="100%" CssClass="texto">
                            <table style="width: 98%">
                                <tr>
                                    <td align="right" class="texto" style="width: 10%; height: 20px">
                                        <strong class="texto">Global:</strong></td>
                                    <td align="left" style="width: 15%; height: 20px">
                                        <anthem:Label ID="lbl_nm_st_analise_global" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                    <td align="right" class="texto" style="width: 15%; height: 20px">
                                        <strong>Compartimentos:</strong></td>
                                    <td align="left" style="width: 15%; height: 20px">
                                        <asp:Label ID="lbl_nm_st_analise_compartimento" runat="server" CssClass="texto"></asp:Label></td>
                                    <td align="right" class="texto" style="width: 20%; height: 20px">
                                        <strong>Unidades de Produção:</strong></td>
                                    <td align="left" style="width: 15%; height: 20px">
                                        <asp:Label ID="lbl_nm_st_analise_uproducao" runat="server" CssClass="texto"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </TD>
					<TD style="width: 10px; height: 54px;"  ></TD>
                </TR>
<%--                <tr>
					<TD style="width: 10px; height: 22px;"  ></TD>
			        <td style="height: 22px; width: 971px;" align="right">
                        &nbsp;&nbsp;
                        &nbsp;</TD>
					<TD style="width: 10px; height: 22px;"  ></TD>
                </TR>
--%>				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 971px;" vAlign="middle" background="img/faixa_filro.gif" align="left">
                        &nbsp; &nbsp;&nbsp;
                        <asp:Image ID="img_novo" runat="server" ImageUrl="~/img/icon_analises.gif" />
                        <anthem:LinkButton
                            ID="lk_registrar_analise" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Registrar Situação para Análise Global">Registrar Análise Global Positiva</anthem:LinkButton>
						&nbsp;&nbsp;
                        <asp:Label ID="lbl_status_botao" runat="server" Text="Positivo" Visible="False"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 1px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 1px; width: 971px;">&nbsp;&nbsp;</TD>
					<TD style="height: 1px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; height: 116px;">&nbsp;</TD>
					<TD style="height: 116px; width: 971px;">
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_analise_global" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_analise" HeaderText="C&#243;digo" SortExpression="id_analise" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_analise" HeaderText="An&#225;lise" SortExpression="nm_analise" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa Referencial" SortExpression="ds_faixa" ReadOnly="True" NullDisplayText="N&#227;o Cadastrada" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo"
                                    SortExpression="nm_tipo_analise" ReadOnly="True" NullDisplayText="N&#227;o Cadastrada" />
                                <asp:TemplateField HeaderText="Valor">
                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Visible="False" Width="56px" AutoUpdateAfterCallBack="True" __designer:wfdid="w73"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" Visible="False" CssClass="texto" Width="8px" Font-Bold="True" __designer:wfdid="w74" ToolTip="Valor obrigatório" ValidationGroup="vg_salvar" ControlToValidate="txt_int_nr_valor" ErrorMessage="O valor para análise deve ser preenchido!">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Visible="False" Width="56px" AutoUpdateAfterCallBack="True" __designer:wfdid="w75" MaxCaracteristica="10" MaxMantissa="4" MaxLength="15" DecimalSymbol=","></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" Visible="False" Font-Bold="True" __designer:wfdid="w76" ToolTip="Valor obrigatório!" ValidationGroup="vg_salvar" ControlToValidate="txt_dec_nr_valor" ErrorMessage="O valor para análise deve ser preenchido!">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Visible="False" Width="88px" __designer:wfdid="w77"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" Visible="False" Font-Bold="True" __designer:wfdid="w78" ToolTip="Valor obrigatório" ValidationGroup="vg_salvar" ControlToValidate="cbo_nr_valor" ErrorMessage="O valor da análise deve ser preenchido.">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w79" ValidationGroup="vg_salvar" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w71"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Visible="False" Text='<%# Bind("nm_analise_logica") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                    <edititemtemplate>
    &nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" __designer:wfdid="w70" Font-Bold="True" ErrorMessage="O status da análise deve ser preenchido." ControlToValidate="cbo_id_st_analise" ValidationGroup="vg_salvar">!</asp:RequiredFieldValidator> <asp:DropDownList id="cbo_id_st_analise" runat="server" __designer:wfdid="w71"></asp:DropDownList> <asp:ValidationSummary id="ValidationSummary2" runat="server" __designer:wfdid="w72" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary> 
    
</edititemtemplate>
                                    <itemtemplate>
    <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w15"></asp:Label> 
    
</itemtemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_salvar" />
                                <asp:BoundField DataField="id_analise_global" Visible="False" ReadOnly="True" />
                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                    <itemtemplate>
    <asp:Label id="id_formato_analise" runat="server" Text='<%# Bind("id_formato_analise") %>' __designer:wfdid="w10"></asp:Label> 
    
</itemtemplate>
        </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#78A3E2" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
					    </TD>
					<TD style="height: 116px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="width: 971px;">&nbsp;&nbsp;
					</TD>
					<TD style="width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages></form>
	</body>
</HTML>
