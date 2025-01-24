<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_calculo_frete_transportador_anexo.aspx.vb" Inherits="frm_calculo_frete_transportador_anexo" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

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
		<title>Flash Fechamento Transportador - Anexar Documentos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript">
		function clearData()
        {
           if (document.getElementById("<%=txt_nm_documento.ClientID %>").value == "")
           {
                var file = document.getElementById("<%=ful_documento.ClientID %>").files[0];
                if (file) 
                    {
                    document.getElementById("<%=txt_nm_documento.ClientID %>").value = file.name.slice(0,file.name.indexOf("."));
                    }
            }
		}
		
</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 1%">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 98%;">
                        <asp:Label ID="lbl_titulo_tela" runat="server"
                            CssClass="texto" Font-Bold="False" Font-Size="XX-Small" ForeColor="White">Flash Fechamento Transportador - Anexar Documentos</asp:Label></TD>
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
				
				<tr  >
				    <td style="width: 1%"></td>
				    <td class="texto">
						<TABLE id="Table8" cellSpacing="0" cellPadding="2" width="100%" class="texto">
							<TR>
								<TD class="titmodulo"  colSpan="6" style="height: 10px"> Dados do Transportador e Cálculo</TD>
							</TR>
							
                            <tr>
                                <td align="right" class="texto" style="height: 24px; width: 15%;">
                                    <span class="obrigatorio"></span><span style="color: #000000">
                                    Transportador:</span></td>
                                <td  class="texto" style="height: 24px; width: 24%;">
                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server" CssClass="texto"></asp:Label></td>
                                <td class="texto" style="height: 24px; width: 12%;" align="right">
                                    CNPJ:</td>
                                <td class="texto" style="height: 24px" >
                                    &nbsp;<asp:Label ID="lbl_cnpj" runat="server" CssClass="texto"></asp:Label></td>
                                <td class="texto" align="right" style="height: 24px; width: 10%;" >
                                    </td>
                                <td class="texto" style="height: 24px; width: 17%;" >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    Referência:</td>
                                <td id="lbl_destino" class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_referencia" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    Tipo Frete:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_tipo_frete" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    Calc. Definitivo:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_calculo_definitivo" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    Qtde Viagens:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_qtde_viagens" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    KM Total:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_km_frete" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    Valor Total:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_total_bruto" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 24px">
                                    Nr Cte Multi:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_nr_cte_multi" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                    Nr Viagem Multi:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;<asp:Label ID="lbl_nr_viagem_multi" runat="server" CssClass="texto"></asp:Label></td>
                                <td align="right" class="texto" style="height: 24px">
                                </td>
                                <td class="texto" style="height: 24px">
                                </td>
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
                                        &nbsp;<asp:FileUpload ID="ful_documento" runat="server" CssClass="texto" Width="70%" EnableTheming="True"   />
                                        <asp:RequiredFieldValidator ID="rqf_documento" runat="server" ControlToValidate="ful_documento"
                                            CssClass="texto" ErrorMessage="Escolha um Documento para Anexar" Font-Bold="False"
                                            ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" >
                                        <span style="color: #ff0000">*</span>Nome Documento Exibido:</td>
                                    <td  >
                                        &nbsp;<anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="60%" onfocus="clearData()" ></anthem:TextBox>
                                        <asp:RequiredFieldValidator ID="rqf_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                            CssClass="texto" ErrorMessage="Preencha o campo Nome do Documento para contiuar"
                                            Font-Bold="False" ValidationGroup="vg_anexar" ToolTip="Nome Documento deve ser informado">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                  <tr>
                                    <td align="right" >
                                        <span style="color: #ff0000">*</span>Tipo Documento:</td>
                                    <td class="texto">
                                        &nbsp;<anthem:DropDownList ID="cbo_tipo_documento" runat="server" AutoCallBack="True"
                                            AutoUpdateAfterCallBack="True" CssClass="texto">
                                            <asp:ListItem value="" Selected="True">[Selecione]</asp:ListItem>
                                            <asp:ListItem Value="CTE">CTE</asp:ListItem>
                                            <asp:ListItem Value="O">Outros</asp:ListItem>
                                        </anthem:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_tipo_documento"
                                            CssClass="texto" ErrorMessage="Preencha o campo Tipo do Documento para contiuar"
                                            Font-Bold="False" ToolTip="Tipo docimento deve ser informado." ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr runat="server" id="tr_nota" visible="false">
                                    <td align="right" >
                                        Nr CTE:</td>
                                    <td  >
                                        &nbsp;<cc4:OnlyNumbersTextBox ID="txt_nr_nota" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="14" Width="150px"></cc4:OnlyNumbersTextBox>
                                        <anthem:RequiredFieldValidator ID="rf_nrnota" runat="server" AutoUpdateAfterCallBack="True"
                                            ControlToValidate="txt_nr_nota" CssClass="texto" ErrorMessage="Preencha o campo Nr Nota Fiscal / CTE para contiuar"
                                            ToolTip="Nr Nota Fiscal / CTE deve ser informado." ValidationGroup="vg_anexar">[!]</anthem:RequiredFieldValidator>
                                        </td>
                                </tr>
                                <tr>
                                    <td align="right" >
                                        Descrição Documento:</td>
                                    <td  >
                                        &nbsp;<anthem:TextBox ID="txt_ds_descricao" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="200" Width="80%"></anthem:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" >
                                    </td>
                                    <td >
                                        &nbsp;<asp:Button ID="btn_anexar" runat="server" CssClass="texto" Text="Anexar Documento"
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
                                                        <br />
                                                        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"
                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_calculo_frete_transportador_anexo"
                                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                            UseAccessibleHeader="False" Visible="False" Width="98%">
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
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" CssClass="texto" Text='<%# Bind("nm_documento") %>' __designer:wfdid="w226"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="nm_tipo_anexo" HeaderText="Tipo" >
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dt_criacao" HeaderText="Inclus&#227;o" DataFormatString="{0:dd/MM/yyyy}" >
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="nm_usuario_abreviado" HeaderText="Usu&#225;rio" />
                                                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr.Nota" ReadOnly="True">
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ds_descricao" HeaderText="Descri&#231;&#227;o" />
                                                                <asp:TemplateField HeaderText="Download">
                                                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Font-Underline="True" __designer:wfdid="w229">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" CommandName="Update" __designer:wfdid="w232"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" CommandName="Cancel" __designer:wfdid="w233"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w234"></asp:ValidationSummary> 
</edititemtemplate>
                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" CommandName="Edit" __designer:wfdid="w230"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" ToolTip="Excluir Anexo" UpdateAfterCallBack="True" CommandName="delete" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_calculo_frete_transportador_anexo") %>' __designer:wfdid="w386"></anthem:ImageButton> 
</itemtemplate>
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_tipo_frete" Visible="False">
                                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frete" runat="server" Text='<%# Bind("id_tipo_frete") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_tipo_anexo" Visible="False">
                                                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_anexo" runat="server" Text='<%# Bind("id_tipo_anexo") %>' __designer:wfdid="w235"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_frete_periodo" Visible="False">
                                                                    <itemtemplate>
<asp:Label id="lbl_id_frete_periodo" runat="server" Text='<%# Bind("id_frete_periodo") %>' __designer:wfdid="w446"></asp:Label> 
</itemtemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                        </anthem:GridView>
                                                       
                                                    </td>
                                                </tr>
                                            </table>
                                           </td>
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
                ShowSummary="False" ValidationGroup="vg_anexar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpesquisar" />
		</form>
	</body>
</HTML>
