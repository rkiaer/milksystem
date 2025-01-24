<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio.aspx.vb" Inherits="frm_romaneio" %>

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Romaneio - Complementar Dados</STRONG></TD>
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
									colSpan="4">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/icone_anexar.gif" /><asp:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio"
                                        ValidationGroup="vg_salvar">Anexar Documento</asp:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;</TD>
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
							    <TD   ></TD>
								<TD  class="texto" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
							                    <TD class="texto" align="right" style="height: 20px;width:18%"><STRONG>Nr. Romaneio:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="width:17%; height: 20px;" ><STRONG>Situação:</STRONG></TD>
							                    <TD style="width:32%; height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
						                    </TR>
                                            <tr>
						                        <TD class="texto" align="right" style="height: 20px; " ><STRONG><span style="color: #ff0000">* </span>Estabelecimento:</STRONG></TD>
                                                <TD style=" height: 20px;" align="left" >&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server"
                                                        AutoPostBack="True" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG>Transportador:</STRONG></TD>
							                    <TD style="height: 20px" align="left">&nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
						                    <TR>
						                        <TD class="texto" align="right" style="height: 20px; " ><STRONG>Motorista:</STRONG></TD>
                                                <TD style=" height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_motorista" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG>CNH:</STRONG></TD>
							                    <TD style="height: 20px" align="left">&nbsp;<asp:Label ID="lbl_cd_cnh" runat="server"  CssClass="texto"></asp:Label></TD>
						                    </TR>
                                            <tr>
                                                <td  align="right" class="texto" style=" height: 20px"><strong>Placa Principal:</strong></td>
                                                <td  align="left" valign="middle" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_placa" runat="server" CssClass="texto" Height="16px"></asp:Label></td>
                                                <td  align="right"><strong>Tara:</strong></td>
                                                <td  align="left" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_tara" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px;" ><STRONG class="texto">Entrada:</STRONG></TD>
							                    <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG>Saída:</STRONG></TD>
							                    <TD align="left" >&nbsp;<asp:Label ID="lbl_saida" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
						                    <TR id="tr_caderneta2" runat="server" >
							                    <TD class="texto" align="right" style="height: 20px; " >
							                    <STRONG class="texto">Rota:</STRONG></TD>
							                    <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto"></asp:Label>
                                                </TD>
							                    <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="lbl_labeltipoleite" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <TD align="left" >&nbsp;<asp:Label ID="lbl_tipoleite" runat="server"  CssClass="texto" ></asp:Label></TD>
						                    </TR>
                                            <tr id="tr_caderneta" runat="server">
                                                <TD class="texto" align="right" style="height: 20px;" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="lbl_label_caderneta" runat="server" CssClass="texto">Nr. Caderneta:</asp:Label>
                                                    </strong>
                                                </td>
                                                <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" 
                                                            Width="100%" EnableTheming="False">Vol. Total Caderneta:</asp:Label></strong></td>
                                                <TD align="left" >
                                                    &nbsp;<asp:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_transbordo" runat="server" visible="false">
                                                <TD class="texto" align="right" style="height: 20px;" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="Label1" runat="server" CssClass="texto">Vol. Total Pré-Romaneios:</asp:Label>
                                                    </strong>
                                                </td>
                                                <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_liquido_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="Label2" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <TD align="left" >
                                                    &nbsp;<asp:Label ID="lbl_id_item" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="width: 9px" ></TD>
							</TR>
						    <TR id="tr_pnl_nota_fiscal_transferencia" runat="server">
							    <TD   ></TD>
								<TD  id="td2" runat="server" class="texto">
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" Font-Bold="False" GroupingText="Nota Fiscal de Transferência" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table2" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
						                        <TD class="texto" align="right" style="height: 22px; width: 18%;" ><STRONG>Nr. Nota Fiscal:</STRONG></TD>
                                                <TD style=" height: 22px;" align="left" >&nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_nota_fiscal_transf" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" MaxLength="7" Width="96px" AutoCallBack="True"></cc3:OnlyNumbersTextBox></TD>
							                    <TD class="texto" align="right" style="height: 22px; width: 17%;" ><STRONG>Série:</STRONG></TD>
							                    <TD style="width: 32%; height: 22px;" align="left">&nbsp;<anthem:TextBox ID="txt_serie_nota_fiscal_transf" runat="server" CssClass="texto"
                                                        Width="96px"></anthem:TextBox></TD>
						                    </TR>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px;" >
                                                    <STRONG class="texto">Peso Líquido da Nota:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" >&nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_peso_liquido_nota_transf" runat="server"
                                                        CssClass="texto" MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                    <anthem:RequiredFieldValidator ID="rfv_peso_nota_transf" runat="server" ControlToValidate="txt_nr_peso_liquido_nota_transf"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Peso Líquido da Nota de Transferência para continuar."
                                                        ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" Visible="False">[!]</anthem:RequiredFieldValidator></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>Data de Emissão:</STRONG></TD>
							                    <TD align="left" style="width: 32%" >&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_emissao_nota" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox></TD>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="width: 9px"   ></TD>
							</TR>
						    <TR id="tr_pnl_dados_cooperativa" runat="server">
							    <TD   ></TD>
								<TD  id="td_dados_cooperativa" runat="server" class="texto">
                                    <asp:Panel ID="pnlCooperativa" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados da Cooperativa / Nota Fiscal" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
							                    <TD class="texto" align="right" style="height: 20px;width:18%"><STRONG>Cooperativa:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" colspan="3" rowspan="" >&nbsp;<asp:Label ID="lbl_cooperativa" runat="server"  CssClass="texto"></asp:Label></TD>
						                    </TR>
						                    <TR>
						                        <TD class="texto" align="right" style="height: 20px; width: 18%;" ><STRONG>Data Entrada/Saída Nota:</STRONG></TD>
                                                <TD style=" height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_dt_saida_nota" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>Nr. Nota Fiscal:</STRONG></TD>
							                    <TD style="width: 32%;" align="left">&nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server"  CssClass="texto"></asp:Label></TD>
						                    </TR>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px; width: 18%;" >
                                                    <STRONG class="texto">Peso Líquido da Nota:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>Valor da Nota:</STRONG></TD>
							                    <TD align="left" style="width: 32%" >&nbsp;<asp:Label ID="lbl_nr_valor_nota" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px; width: 18%;" ><STRONG class="texto">Tipo do Leite:</strong></td>
                                                <TD style="height: 20px;" align="left" >
                                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px; width: 17%;" >
                                                    <STRONG></strong></td>
                                                <TD align="left" style="width: 32%" >
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="width: 9px" ></TD>
							</TR>
						    <TR >
							    <TD   ></TD>
								<TD  id="td1" runat="server" class="texto">
                                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados de Placas e Compartimentos" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
							                    <TD class="texto" align="center" style="height: 20px" colspan="4" >
                                                    <anthem:GridView ID="gridRomaneioCompartimento" runat="server" AllowSorting="True"
                                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                        Width="80%" DataKeyNames="id_romaneio_compartimento">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_volume"  HeaderText="Volume M&#225;ximo"
                                                                ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Volume Total Compartimento">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* <cc3:OnlyNumbersTextBox id="txt_nr_total_litros" runat="server" CssClass="texto" Width="80px" __designer:wfdid="w23"></cc3:OnlyNumbersTextBox></SPAN></STRONG> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_grid" CssClass="texto" Font-Bold="True" ErrorMessage="O volume total do compartimento deve ser preenchido." ControlToValidate="txt_nr_total_litros" __designer:wfdid="w24">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_total_litros" runat="server" CssClass="texto" Text='<%# bind("nr_total_litros") %>' __designer:wfdid="w22"></asp:Label>&nbsp; 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" EditImageUrl="~/img/icone_editar_grid.gif"
                                                                ShowEditButton="True" UpdateImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_grid" />
                                                            <asp:BoundField DataField="id_romaneio_compartimento" HeaderText="id_romaneio_compartimento"
                                                                ReadOnly="True" Visible="False" />
                                                        </Columns>
                                                    </anthem:GridView>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="vg_grid" Visible="False" />
                                                    <asp:CustomValidator ID="cv_gridcomp" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:CustomValidator></TD>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 21px; width: 9px;"  ></TD>
							</TR>
						    <TR>
							    <TD   ></TD>
								<TD class="texto" >
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" 
                                        Font-Bold="False" GroupingText="Lacres de Placas" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" BorderStyle="None" CssClass="texto">
                                        <br />
                                        <table width="98%">
                                            <tr>
                                                <td align="center" class="texto" colspan="4">
                                                    <strong></strong>
                                                    <anthem:GridView ID="grdlacres" runat="server"
                                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                        Width="80%" DataKeyNames="id_romaneio_lacre">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Placa">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><asp:DropDownList id="cbo_ds_placa" runat="server" ValidationGroup="vg_lacre" CssClass="texto" __designer:wfdid="w50"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfv_placa" runat="server" ValidationGroup="vg_lacre" CssClass="texto" Font-Bold="True" ErrorMessage="A Placa deve ser informada." ControlToValidate="cbo_ds_placa" __designer:wfdid="w51">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_ds_placa" runat="server" CssClass="texto" Text='<%# Bind("ds_placa") %>' __designer:wfdid="w58"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nr Lacre">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><cc3:OnlyNumbersTextBox id="txt_nr_lacre_entrada" runat="server" CssClass="texto" Text='<%# Bind("nr_lacre_entrada") %>' MaxLength="20" __designer:wfdid="w52"></cc3:OnlyNumbersTextBox>&nbsp; <asp:RequiredFieldValidator id="rfv_lacre" runat="server" ValidationGroup="vg_lacre" CssClass="texto" Font-Bold="True" ErrorMessage="Número do Lacre de entrada deve ser informado." ControlToValidate="txt_nr_lacre_entrada" __designer:wfdid="w53">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_lacre_entrada" runat="server" CssClass="texto" Text='<%# Bind("nr_lacre_entrada") %>' __designer:wfdid="w46"></asp:Label>&nbsp; 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_lacre" ToolTip="Gravar Lacre" Text="Update" __designer:wfdid="w59" CommandName="Update" CommandArgument='<%# bind("id_romaneio_lacre") %>'></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" __designer:wfdid="w60" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_lacre" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w61"></asp:ValidationSummary> 
</edititemtemplate>
                                                                <headerstyle width="10%" />
                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Lacre" Text="Edit" __designer:wfdid="w62" CommandName="Edit"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Lacre" Text="Edit" __designer:wfdid="w63" CommandName="Delete" CommandArgument='<%# bind("id_romaneio_lacre") %>' OnClientClick="if (confirm('Deseja realmente excluir este lacre?' )) return true;else return false;"></asp:ImageButton> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </anthem:GridView>
                                                    <asp:CustomValidator ID="cv_gridlacre" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                                        Font-Bold="True" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator>
                                                    <br />
                                                    <anthem:Button ID="btn_novo_lacre" runat="server" AutoUpdateAfterCallBack="True"
                                                        Text="Adicionar" ToolTip="Adicionar novo lacre" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
									
								</TD>
								<TD style="width: 9px" ></TD>
							</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" class="texto">
					    <TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD   ></TD>
								<TD  >
                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados da Pesagem" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table8" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
							                    <TD class="texto" align="right" style="height: 20px;width:23%"><STRONG><span style="color: #ff0000">* </span><strong>Data Pesagem Inicial:</strong></STRONG></TD>
							                    <TD style="width:152px; height: 20px;" align="left" >
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto" MaxLength="10"
                                                        ValidationGroup="vg_salvar" Width="88px"></cc4:OnlyDateTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
							                    <TD class="texto" align="right" style="width:17%; height: 20px;" ><STRONG><span style="color: #ff0000">* <strong><span style="color: #000000">Horário
                                                        :</span></strong></span></STRONG></TD>
							                    <TD style="width:32%; height: 20px;" align="left" >&nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_ini"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem inicial esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_ini" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem inicial é inválido."
                                                            Font-Bold="True" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_ini"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário da Pesagem Inicial para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_ini"
                                                                    CssClass="texto" ErrorMessage="Preencha os Minutos do Horário da Pesagem Inicial para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
						                    </TR>
                                            <tr>
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança:</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" AutoCallBack="True" Enabled="False">
                                                        <asp:ListItem Value="02">Portaria 02 - Sa&#237;da</asp:ListItem>
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqf_balanca" runat="server" ControlToValidate="cbo_balanca"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar." Font-Bold="True"
                                                        ValidationGroup="vg_balanca">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Inicial?' )) {lbl_aguarde.className='aguardedestaque';return true;};else return false; " Text="Ler Balança" ToolTip="Buscar peso da balança"
                                                        ValidationGroup="vg_balanca" Enabled="False" />
                                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                                        UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                                            </tr>
						                    <TR>
						                        <TD class="texto" align="right" style="height: 20px" ><STRONG><span style="color: #ff0000">* </span><strong>Pesagem Inicial:</strong></STRONG></TD>
                                                <TD style=" height: 20px; width: 152px;" align="left" >&nbsp;<cc6:OnlyDecimalTextBox ID="txt_pesagem_inicial" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="88px" ToolTip="Pesagem Inicial" ValidationGroup="vg_salvar" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="A Pesagem Inicial deve ter valor maior que zero (0)."
                                                        Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Inicial maior que zero."
                                                        ValidationGroup="vg_salvar" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></TD>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG></STRONG></TD>
							                    <TD style="height: 20px" align="left">&nbsp;</TD>
						                    </TR>

                                        </table>
                                        <br />
                                    </asp:Panel>
                                    
									
								</TD>
								<TD ></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px; height: 17px;"></TD>
								<TD style="height: 17px">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
					<TD style="width: 9px">&nbsp;</TD>
				</TR>
				
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"
                UpdateAfterCallBack="True" AutoUpdateAfterCallBack="true"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
