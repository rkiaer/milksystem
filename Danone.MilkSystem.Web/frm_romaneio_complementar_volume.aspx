<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_complementar_volume.aspx.vb" Inherits="frm_romaneio_complementar_volume" %>

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
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0" width="100%">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Complementar Volume de Romaneio fechado</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 5px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 5px" class="texto">
						<TABLE id="Table9" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
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
						    <TR>
							    <TD style="height: 39px; width: 7px;"  ></TD>
								<TD class="texto" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
							                    <TD class="texto" align="right" style="height: 20px;width:21%"><STRONG>Nr. Romaneio:</STRONG></TD>
							                    <TD style="width:28%; height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto" Width="100%"></asp:Label></TD>
							                    <TD class="texto" align="right" style="width:20%; height: 20px;" ><STRONG>Situação:</STRONG></TD>
							                    <TD style="width:31%; height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto" Width="80%"></asp:Label></TD>
						                    </TR>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px; width: 21%;" ><STRONG class="texto">Entrada:</STRONG></TD>
							                    <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto" Width="176px"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG>
                                                        <asp:Label ID="lbl_labeltipoleite" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></STRONG></TD>
							                    <TD align="left" >&nbsp;<asp:Label ID="lbl_tipoleite" runat="server"  CssClass="texto" ></asp:Label></TD>
                                            </tr>
                                            <tr id="tr_caderneta" runat="server">
                                                <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="lbl_label_caderneta" runat="server" CssClass="texto">Nr. Caderneta:</asp:Label>
                                                    </strong>
                                                </td>
                                                <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" Height="16px"
                                                            Width="100%" EnableTheming="False">Somatória Caderneta:</asp:Label></strong></td>
                                                <TD align="left" >
                                                    &nbsp;<anthem:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 39px"  ></TD>
							</TR>
						    <TR id="tr_transbordo" runat="server" visible="false">
							    <TD style="height: 21px; width: 7px;"  ></TD>
								<TD style="height: 21px; " id="td3" runat="server" class="texto">
                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados do Transbordo / Nota Fiscal Transferência" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table8" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
						                        <TD class="texto" align="right" style="height: 20px; width: 21%;" ><STRONG>Nr. Nota Fiscal Transf.:</STRONG></TD>
                                                <TD style=" height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_nr_nota_transf" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <strong>Série Nota Fiscal Transf.:</strong></TD>
							                    <TD style="width: 31%;" align="left">&nbsp;<asp:Label ID="lbl_serie_transf" runat="server"  CssClass="texto" Width="80%"></asp:Label></TD>
						                    </TR>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <STRONG class="texto">Data Emissão Nota Transf.:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" >&nbsp;<anthem:Label ID="lbl_dt_emissao_transf" runat="server"  CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 21%;" ><STRONG>Peso Líquido da Nota Transf.:</STRONG></TD>
							                    <TD align="left" style="width: 31%" >&nbsp;<asp:Label ID="lbl_nr_peso_nota_transf" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px; width: 21%;" ><STRONG class="texto">Tipo do Leite:</strong></td>
                                                <TD style="height: 20px;" align="left" >
                                                    &nbsp;<asp:Label ID="lbl_id_item" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <STRONG>Volume Total Pré-Romaneios:</strong></td>
                                                <TD align="left" style="width: 31%" >
                                                    &nbsp;
                                                    <anthem:Label ID="lbl_soma_nr_peso_liquido_caderneta" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
						    <TR id="tr_panel_caderneta" runat="server" >
							    <TD style="height: 21px; width: 7px;"  ></TD>
								<TD style="height: 21px; " id="td2" runat="server" class="texto">
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False" GroupingText="Ajuste de Valores" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table2" border="0" cellpadding="1" cellspacing="0" width="100%">
                                                 <tr>
            <td  align="right" class="texto" colspan="4" style="height: 8px">&nbsp;</td>
        </tr>

                                            <tr >
							                    <TD class="texto" align="center" style="height: 17px;" colspan="4" >
                                                    <anthem:GridView ID="grdresults" runat="server" AllowSorting="True"
                                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                        Width="99%" DataKeyNames="id_romaneio_uproducao">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                        <Columns>
                                                            <asp:BoundField DataField="nr_ordem" HeaderText="Seq." ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ds_pessoa" HeaderText="Produtor" ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True" />
                                                            <asp:BoundField DataField="ds_uproducao" HeaderText="Unid. Produ&#231;&#227;o" ReadOnly="True" />
                                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." ReadOnly="True" />
                                                            <asp:BoundField HeaderText="Vol. Coletado"
                                                                ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Volume Ajustado">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* <cc3:OnlyNumbersTextBox id="txt_nr_litros_ajustado" runat="server" CssClass="texto" Width="88px" __designer:wfdid="w48"></cc3:OnlyNumbersTextBox></SPAN></STRONG> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" CssClass="texto" Font-Bold="True" ValidationGroup="vg_grid" __designer:wfdid="w49" ErrorMessage="O volume coletado para o Produtor deve ser preenchido." ControlToValidate="txt_nr_litros_ajustado">[!]</asp:RequiredFieldValidator><asp:CustomValidator id="cv_volumeajustado" runat="server" CssClass="texto" Font-Bold="True" ValidationGroup="vg_grid" __designer:wfdid="w50" ErrorMessage="CustomValidator" ControlToValidate="txt_nr_litros_ajustado" OnServerValidate="cv_volumeajustado_ServerValidate">[!]</asp:CustomValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_litros_ajustado" runat="server" CssClass="texto" __designer:wfdid="w10"></asp:Label>&nbsp; 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Diferen&#231;a" ReadOnly="True" />
                                                            <asp:TemplateField ShowHeader="False">
                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w41" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w42" CommandName="Cancel"></asp:ImageButton> 
</edititemtemplate>
                                                                <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" AutoUpdateAfterCallBack="True" Text="Edit" __designer:wfdid="w39" CommandName="Edit"></anthem:ImageButton>&nbsp;<asp:ImageButton id="btn_excluir" runat="server" ImageUrl="~/img/icone_excluir.gif" CausesValidation="False" Text="Delete" __designer:wfdid="w40" CommandName="Delete" Visible="False" OnClientClick="if (confirm('Deseja realmente excluir o ajuste do volume?' )) return true;else return false;" CommandArgument='<%# Bind("id_romaneio_uproducao") %>'></asp:ImageButton> 
</itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle horizontalalign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="nr_litros" Visible="False">
                                                                <edititemtemplate>
<asp:Label id="nr_litros" runat="server" __designer:wfdid="w100" Text='<%# Bind("nr_litros") %>'></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="nr_litros" runat="server" __designer:wfdid="w92" Text='<%# Bind("nr_litros") %>'></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="nr_litros_sem_reajuste" Visible="False">
                                                                <edititemtemplate>
<asp:Label id="nr_litros_sem_reajuste" runat="server" __designer:wfdid="w91" Text='<%# Bind("nr_litros_sem_reajuste") %>'></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="nr_litros_sem_reajuste" runat="server" __designer:wfdid="w90" Text='<%# Bind("nr_litros_sem_reajuste") %>'></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="nr_total_litros" Visible="False">
                                                                <edititemtemplate>
<asp:Label id="nr_total_litros" runat="server" __designer:wfdid="w63" Text='<%# Bind("nr_total_litros") %>'></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="nr_total_litros" runat="server" __designer:wfdid="w62" Text='<%# Bind("nr_total_litros") %>'></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="nr_total_litros_sem_ajuste" Visible="False">
                                                                <edititemtemplate>
<asp:Label id="nr_total_litros_sem_reajuste" runat="server" Text='<%# Bind("nr_total_litros_sem_reajuste") %>' __designer:wfdid="w20"></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="nr_total_litros_sem_reajuste" runat="server" __designer:wfdid="w86" Text='<%# Bind("nr_total_litros_sem_reajuste") %>'></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="False">
                                                                <edititemtemplate>
<asp:Label id="id_romaneio_compartimento" runat="server" Text='<%# bind("id_romaneio_compartimento") %>' __designer:wfdid="w9"></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="id_romaneio_compartimento" runat="server" Text='<%# bind("id_romaneio_compartimento") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle horizontalalign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                                                <edititemtemplate>
<asp:Label id="lbl_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w13"></asp:Label>
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle HorizontalAlign="Left" /><EditRowStyle HorizontalAlign="Left" />
                                                        <AlternatingRowStyle HorizontalAlign="Left" />
                                                    </anthem:GridView>
                                                    &nbsp;
                                                    </TD>
                                            </tr>
                                        </table>
                                                        </asp:Panel>
								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
					    <TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px; height: 17px;"></TD>
								<TD style="height: 17px">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0" class="texto">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" 
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4" style="height: 25px">&nbsp;</TD>
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
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="vg_grid" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="vg_adicionar" />
        </form>
	</body>
</HTML>
