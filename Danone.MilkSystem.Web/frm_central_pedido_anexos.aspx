<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_anexos.aspx.vb" Inherits="frm_central_pedido_anexos" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Pedido - Anexar Documentos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 2px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)">Pedidos - Anexar Documentos</TD>
					<TD style="width: 6px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 2px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                     </TD>
					<TD style="width: 6px" >&nbsp;</TD>
				</TR>
				
				<tr runat="server" id="tr_interrupcao" >
				    <td style="width: 2px"></td>
				    <td class="texto">
						<TABLE id="Table8" cellSpacing="0" cellPadding="2" width="100%" class="texto">
							<TR>
								<TD class="titmodulo"  colSpan="6" style="height: 10px"> Dados da Interrupção de Fornecimento de Leite</TD>
							</TR>
                            <tr>
                                <td align="right" class="texto"  style="width: 15%; height: 30px">
                                    <span class="obrigatorio"></span> Mês/Ano Desligamento:</td>
                                <td class="texto" style="height: 30px">
                                    <anthem:Label ID="lbl_dt_referencia" runat="server"></anthem:Label></td>
                                <td class="texto" style="height: 30px" align="right">
                                    Nr Execução:</td>
                                <td class="texto" style="height: 30px">
                                    &nbsp;<anthem:Label ID="lbl_id_execucao" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" style="width: 12%; height: 30px" align="right">
                                    Tipo Acerto:</td>
                                <td class="texto" style="height: 30px">
                                    &nbsp;<anthem:Label ID="lbl_tipo_acerto" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    <span class="obrigatorio"></span><span style="color: #000000">Produtor:</span></td>
                                <td  class="texto" style="height: 24px">
                                    <anthem:Label ID="lbl_produtor" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" style="height: 24px" align="right">
                                    Propriedade:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_propriedade_up" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" align="right" style="height: 24px" >
                                    Prop. Matriz:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_id_propriedade_matriz" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto"  style="height: 24px">
                                    Pedido:</td>
                                <td style="height: 24px">
                                    <anthem:Label ID="lbl_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td style="height: 24px" align="right">
                                    Nota Fiscal:</td>
                                <td style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_nr_nota" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" align="right" style="height: 24px" >
                                    Valor Nota:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_valor_nota" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr >
                                <td align="right" style="height: 24px"  >
                                    Data Pagto:</td>
                                <td style="height: 24px" >
                                    <anthem:Label ID="lbl_dt_pagto" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 24px" >
                                    Valor Parcela:</td>
                                <td style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_valor_parcela" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 24px" >
                                    </td>
                                <td align="left" style="height: 24px">
                                    &nbsp;</td>
                            </tr>
                          </table>
                    </td>
                    <td style="width: 6px"></td>
                </tr>
                
                <tr runat="server" id="tr_pedido">
				    <td style="width: 2px"></td>
				    <td class="texto">
				        <table cellSpacing="0" cellPadding="2" width="100%" class="texto">
							<TR>
								<TD class="titmodulo"  colSpan="6" style="height: 10px"> Dados do Pedido</TD>
							</TR>
                            <tr>
                                <td align="right" class="texto"  style="width: 15%; height: 24px">
                                    <span class="obrigatorio"></span> Pedido:</td>
                                <td class="texto" style="height: 24px">
                                    <anthem:Label ID="lbl_central_pedido" runat="server"></anthem:Label></td>
                                <td class="texto" style="height: 24px" align="right">
                                    Data Pedido:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_dt_pedido" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" style="width: 12%; height: 24px" align="right">
                                    Situação:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_situacao" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    <span class="obrigatorio"></span><span style="color: #000000">Produtor:</span></td>
                                <td  class="texto" style="height: 24px">
                                    <anthem:Label ID="lbl_pedido_produtor" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" style="height: 24px" align="right">
                                    Propriedade:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_pedido_propriedade" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" align="right" style="height: 24px" >
                                    Prop. Matriz:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_pedido_prop_matriz" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto"  style="height: 24px">
                                    Fornecedor:</td>
                                <td style="height: 24px">
                                    <anthem:Label ID="lbl_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td style="height: 24px" align="right">
                                    Valor Pedido:</td>
                                <td style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_valor_pedido" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" align="right" style="height: 24px" >
                                    </td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;</td>
                            </tr>
                            <tr runat="server" id="tr_pedido_tipo">
                                <td align="right" class="texto" style="height: 24px">
                                    Tipo:</td>
                                <td style="height: 24px">
                                    <anthem:Label ID="lbl_pedido_tipo" runat="server" CssClass="Texto" Height="16px"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 24px">
                                    Nota Fiscal:</td>
                                <td style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_pedido_nota" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    Valor Parcela:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_pedido_valor_parcela" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
				        </table>
				    </td>
				    <td style="width: 6px"></td>
				</tr>

 				<tr >
				    <td style="width: 2px"></td>
				    <td class="texto">
                     <table cellSpacing="0" cellPadding="2" width="100%" class="texto">
                        <TR>
							<TD class="titmodulo" colSpan="4" style="height: 15px"> Documento para Anexar</TD>
						</TR>
                        <tr>
                            <td align="left" class="texto" colspan="2">
                            <table class="texto" width="100%">
                                <tr>
                                    <td align="right" style="height: 23px">
                                        <span style="color: #ff0000">*</span>Documento:</td>
                                    <td style="height: 23px">
                                        &nbsp;<asp:FileUpload ID="ful_documento" runat="server" CssClass="texto" Width="80%" />
                                        <asp:RequiredFieldValidator ID="rqf_documento" runat="server" ControlToValidate="ful_documento"
                                            CssClass="texto" ErrorMessage="Escolha um Documento para Anexar" Font-Bold="False"
                                            ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 23%">
                                        <span style="color: #ff0000">*</span>Nome Documento a Ser Exibido:</td>
                                    <td>
                                        &nbsp;<anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"></anthem:TextBox>
                                        <asp:RequiredFieldValidator ID="rqf_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" ErrorMessage="Preencha o campo Nome do Documento para contiuar"
                                            Font-Bold="False" ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator><asp:CustomValidator ID="cv_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" Font-Bold="False" ValidationGroup="vg_anexar">[!]</asp:CustomValidator>&nbsp;
                                    </td>
                                </tr>
                                  <tr>
                                    <td align="right" >
                                        <span style="color: #ff0000">*</span>Data Recebimento:</td>
                                    <td class="texto">
                                        &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_recebimento" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" Width="96px"></cc2:OnlyDateTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" ErrorMessage="Preencha o campo Nome do Documento para contiuar"
                                            Font-Bold="False" ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                   <tr>
                                    <td align="right" >
                                        Valor Documento:</td>
                                    <td>
                                        &nbsp;<cc3:OnlyDecimalTextBox ID="txt_valor" runat="server" CssClass="texto" MaxCaracteristica="7" Width="120px"></cc3:OnlyDecimalTextBox>
                                        <anthem:RequiredFieldValidator ID="rf_valor" runat="server" ControlToValidate="txt_valor"
                                            CssClass="texto" ErrorMessage="Preencha o campo Valor Documento para contiuar"
                                            Font-Bold="False" ValidationGroup="vg_anexar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                </tr>                             
                                <tr>
                                    <td align="right" style="height: 23px">
                                    </td>
                                    <td style="height: 23px">
                                        <asp:Button ID="btn_anexar" runat="server" CssClass="texto" Text="Anexar Documento"
                                            ValidationGroup="vg_anexar" /></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <TR id="tr_qualidade" runat="server" >
							<TD colSpan="2" class="texto">
								<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%">
									<TR>
										<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">
                                            Documento Anexado</TD>
									</TR>
                                    <tr>
                                        <td align="center" class="texto" colspan="2">
                                            <br />
                                            <table id="Table10" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                <tr>
                                                    <td align="center" class="texto" colspan="8">
                                                        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"
                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_central_pedido_anexos"
                                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                            UseAccessibleHeader="False" Visible="False" Width="95%">
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                ForeColor="White" HorizontalAlign="Left" />
                                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Nome do Documento">
                                                                    <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                                    <itemtemplate>
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" CssClass="texto" Text='<%# Bind("nm_documento") %>' __designer:wfdid="w252"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="dt_documento" HeaderText="Recebimento" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField DataField="nr_valor" HeaderText="Valor" DataFormatString="{0:N2}" />
                                                                <asp:BoundField DataField="dt_criacao" HeaderText="Inclus&#227;o" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:TemplateField HeaderText="Download">
                                                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Font-Underline="True" __designer:wfdid="w12">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w255" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w256" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w257"></asp:ValidationSummary> 
</edititemtemplate>
                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" __designer:wfdid="w253" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w254" CommandName="delete" ToolTip="Excluir Anexo Pedido" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_central_pedido_anexos") %>'></anthem:ImageButton> 
</itemtemplate>
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_central_pedido" Visible="False">
                                                                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("id_central_pedido") %>' id="Label1"></asp:Label>
</edititemtemplate>
                                                                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("id_central_pedido") %>' id="Label1"></asp:Label>
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_central_pedido_desconto_produtor" Visible="False">
                                                                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("id_central_pedido_desconto_produtor") %>' id="Label2"></asp:Label>
</edititemtemplate>
                                                                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("id_central_pedido_desconto_produtor") %>' id="Label2"></asp:Label>
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_central_pedido_pagto_fornecedor" Visible="False">
                                                                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("id_central_pedido_pagto_fornecedor") %>' id="Label3"></asp:Label>
</edititemtemplate>
                                                                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("id_central_pedido_pagto_fornecedor") %>' id="Label3"></asp:Label>
</itemtemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                        </anthem:GridView>
                                                        &nbsp; &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            &nbsp;</td>
                                    </tr>
								</TABLE>
							</TD>
						</TR>

					</TABLE>

				    </td>
				    <td style="width: 6px"></td>
				</tr>

				<TR>
					<TD style="width: 2px; height: 69px;">&nbsp;</TD>
					<TD style="height: 69px" class="texto" >
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="width: 1px; height: 40px;"></TD>
								<TD style="height: 40px">
									<TABLE id="Table12" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" style="height: 40px" ></TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="width: 6px; height: 69px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vganexar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpesquisar" />
		</form>
	</body>
</HTML>
