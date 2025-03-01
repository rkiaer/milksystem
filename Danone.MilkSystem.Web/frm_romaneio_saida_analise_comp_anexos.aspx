<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_analise_comp_anexos.aspx.vb" Inherits="frm_romaneio_saida_analise_comp_anexos" %>

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
		<title>Romaneio Sa�da An�lises Compartimento - Anexar Documentos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 1%">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 98%;">
                        Romaneio Sa�da - An�lise dos Compartimentos - Anexar Documentos</TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 1%; " ></TD>
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
					<TD style="width: 1%" >&nbsp;</TD>
				</TR>
				
				<tr runat="server" id="tr_interrupcao" >
				    <td style="width: 1%"></td>
				    <td class="texto">
						<TABLE id="Table8" cellSpacing="0" cellPadding="2" width="100%" class="texto">
							<TR>
								<TD class="titmodulo"  colSpan="6" style="height: 10px"> Dados do Romaneio de Sa�da</TD>
							</TR>
                            <tr>
                                <td align="right" class="texto"  style="width: 15%; height: 30px">
                                    <span class="obrigatorio"></span> Nr. Romaneio Sa�da:</td>
                                <td class="texto" style="height: 30px">
                                    <asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label></td>
                                <td class="texto" style="height: 30px" align="right">
                                    Situa��o:</td>
                                <td class="texto" style="height: 30px">
                                    &nbsp;<asp:Label ID="lbl_nm_st_romaneio" runat="server" CssClass="texto"></asp:Label></td>
                                <td class="texto" style="width: 12%; height: 30px" align="right">
                                    Estabelecimento:</td>
                                <td class="texto" style="height: 30px">
                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
							
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    <span class="obrigatorio"></span><span style="color: #000000">
                                    Analista:</span></td>
                                <td  class="texto" style="height: 24px">
                                    <asp:Label ID="lbl_analista" runat="server" CssClass="texto"></asp:Label></td>
                                <td class="texto" style="height: 24px" align="right">
                                    In�cio An�lise:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<anthem:Label ID="lbl_dt_inicio_analise" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td class="texto" align="right" style="height: 24px" >
                                    Tipo Leite:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                          </table>
                    </td>
                    <td style="width: 1%"></td>
                </tr>
                

 				<tr >
				    <td style="width: 1%" ></td>
				    <td class="texto">
                     <table cellSpacing="0" cellPadding="2" width="100%" class="texto">
                        <TR>
							<TD class="titmodulo"  style="height: 15px"> Documento para Anexar</TD>
						</TR>
                        <tr>
                            <td align="center" class="texto" colspan="1">
                            <table class="texto" width="98%">
                                <tr>
                                    <td align="right"  style="width: 23%">
                                        <span style="color: #ff0000">*</span>Documento:</td>
                                    <td >
                                        &nbsp;<asp:FileUpload ID="ful_documento" runat="server" CssClass="texto" Width="70%" />
                                        <asp:RequiredFieldValidator ID="rqf_documento" runat="server" ControlToValidate="ful_documento"
                                            CssClass="texto" ErrorMessage="Escolha um Documento para Anexar" Font-Bold="False"
                                            ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" >
                                        <span style="color: #ff0000">*</span>Nome Documento a Ser Exibido:</td>
                                    <td  >
                                        &nbsp;<anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"></anthem:TextBox>
                                        <asp:RequiredFieldValidator ID="rqf_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" ErrorMessage="Preencha o campo Nome do Documento para contiuar"
                                            Font-Bold="False" ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator><asp:CustomValidator ID="cv_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" Font-Bold="False" ValidationGroup="vg_anexar">[!]</asp:CustomValidator>&nbsp;
                                    </td>
                                </tr>
                                  <tr>
                                    <td align="right" >
                                        C�digo An�lise:</td>
                                    <td class="texto">
                                        &nbsp;<anthem:DropDownList ID="cbo_cd_analise" runat="server" AutoCallBack="True"
                                            AutoUpdateAfterCallBack="True" CssClass="texto">
                                        </anthem:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right" >
                                    </td>
                                    <td >
                                        <asp:Button ID="btn_anexar" runat="server" CssClass="texto" Text="Anexar Documento"
                                            ValidationGroup="vg_anexar" /></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <TR id="tr_qualidade" runat="server" >
							<TD colSpan="1" class="texto">
								<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%">
									<TR>
										<TD class="titmodulo"  style="height: 15px">
                                            Documento Anexado</TD>
									</TR>
                                    <tr>
                                        <td align="center" class="texto">
                                            
                                            <table id="Table10" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                <tr>
                                                    <td align="center" class="texto" colspan="8">
                                                        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"
                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_romaneio_saida_analise_anexo"
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
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" CssClass="texto" Text='<%# Bind("nm_documento") %>' __designer:wfdid="w231"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ds_analise" HeaderText="An&#225;lise" >
                                                                    <itemstyle horizontalalign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dt_criacao" HeaderText="Inclus&#227;o" DataFormatString="{0:dd/MM/yyyy}" >
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Download">
                                                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Font-Underline="True" __designer:wfdid="w58">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w234" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w235" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w236"></asp:ValidationSummary> 
</edititemtemplate>
                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" __designer:wfdid="w232" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w77" CommandName="delete" ToolTip="Excluir Anexo Pedido" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_romaneio_saida_analise_anexo") %>'></anthem:ImageButton> 
</itemtemplate>
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_analise" Visible="False">
                                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                                    <itemtemplate>
<asp:Label id="lbl_id_analise" runat="server" Text='<%# Bind("id_analise") %>' __designer:wfdid="w237"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="cd_analise" Visible="False">
                                                                    <itemtemplate>
<asp:Label id="lbl_cd_analise" runat="server" Text='<%# Bind("cd_analise") %>' __designer:wfdid="w74"></asp:Label>
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
				    <td style="width: 1%"></td>
				</tr>

				<TR>
					<TD style="width: 1%; ">&nbsp;</TD>
					<TD  class="texto" >
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="width: 1px; height: 40px;"></TD>
								<TD style="height: 40px">
									<TABLE id="Table12" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" width="265"
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
					<TD style="width: 1%; ">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vganexar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpesquisar" />
		</form>
	</body>
</HTML>
