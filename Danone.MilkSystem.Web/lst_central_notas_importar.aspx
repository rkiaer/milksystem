<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_notas_importar.aspx.vb" Inherits="lst_central_notas_importar" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Central de Compras - Importação de Nota Fiscal Eletronica</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Central de Compras - Gerenciamento de Nota Fiscal Eletronica</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" class="texto" style="vertical-align: middle; text-align: center">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD width="16%" style="height: 2px">
                                    &nbsp;</TD>
								<TD style="height: 2px;"></TD>
								<TD style="height: 2px;"></TD>
								<TD style="height: 2px"></TD>
                                <td style="height: 2px" width="20%">
                                </td>
							</TR>
                            <tr>
                                <td align="right">
                                    &nbsp;Informe diretório das Notas:</td>
                                <td>
                                    &nbsp;<anthem:Label ID="lbl_nm_diretorio" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                    <anthem:CustomValidator ID="cv_importacao" runat="server" Font-Bold="True" ForeColor="White" ValidationGroup="vg_importar" AutoUpdateAfterCallBack="True">[!]</anthem:CustomValidator></td>
 								<TD align="right">
                                     <anthem:Label ID="lbl_totalarqsxml" runat="server" AutoUpdateAfterCallBack="True"
                                         Text="Total Arquivos NFe (xml):" UpdateAfterCallBack="True"></anthem:Label>
                                     <anthem:Label ID="lbl_nrarqsxml" runat="server" AutoUpdateAfterCallBack="True" Text="0"
                                         UpdateAfterCallBack="True"></anthem:Label></TD>
								<TD align="right">
                                    &nbsp;<anthem:Label ID="lbl_totalimportadas" runat="server" Text="Total NFe importadas:" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;<anthem:Label ID="lbl_totallinhasimportadas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                </TD>
                                <td align="center">
                                    <anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_importar.gif" ValidationGroup="vg_importar" ></anthem:imagebutton></td>
                           </tr>
							<TR>
								<TD style="height: 12px" align="right"></TD>
								<TD style="height: 12px;" colspan="2">
                                    &nbsp;<anthem:Label ID="lbl_Aguarde" runat="server" AutoUpdateAfterCallBack="True" Font-Italic="True"
                                        ForeColor="Blue" Text="Importação em andamento... Aguarde..." UpdateAfterCallBack="True"
                                        Visible="False"></anthem:Label></TD>
								<TD align="center" style="height: 12px" colspan="2">
                                    &nbsp; &nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD  >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 20px" vAlign="middle" background="img/faixa_filro.gif" align="left">
						&nbsp;&nbsp;&nbsp;&nbsp;<anthem:Image ID="Image1" runat="server" ImageUrl="~/img/sincronizar.png" Visible="False" />
                        <anthem:LinkButton ID="btn_atualizarpedido" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Size="XX-Small" ToolTip="Atualizar Pedidos das Notas Válidas" Visible="False">Atualizar Pedidos com Notas Válidas</anthem:LinkButton>
                        &nbsp; &nbsp;&nbsp;
                        <anthem:LinkButton ID="btn_atualizarmanual" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Size="XX-Small" ToolTip="Atualizar Pedidos das Notas Importadas ou com Divergências manualmente">Gerenciar Notas Divergentes</anthem:LinkButton>
                        &nbsp; &nbsp; &nbsp;</TD>
					<TD style="HEIGHT: 20px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; " class="texto">&nbsp;</TD>
					<TD id="td1" runat="server" align="center" class="texto">
                        <br />
						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD style="height: 2px; width: 13%" ></TD>
								<TD style="height: 2px; width: 14%"></TD>
								<TD style="height: 2px; width: 14%"></TD>
								<TD style="height: 2px"></TD>
                                <td style="width: 12%; height: 2px">
                                </td>
                                <td style="height: 2px">
                                </td>
                                <td style="height: 2px; width: 10%;">
                                </td>
                                <td style="height: 2px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right" >
                                    Referência Emissão:</td>
                                <TD style="HEIGHT: 20px; " width="12%">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px" AutoPostBack="True" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px" >
                                    Período em Dias Emissão:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_dia_ini" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox>
                                    à
                                    <cc2:OnlyNumbersTextBox ID="txt_dia_fim" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox><anthem:RangeValidator ID="RangeValidator1"
                                            runat="server" ControlToValidate="txt_dia_ini" ErrorMessage="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                            MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                            Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim" ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                    ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini" ControlToValidate="txt_dia_fim"
                                                    ErrorMessage="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 20px">
                                    Data Importação:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_importacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px">
                                    Nr Importação:</td>
                                <td style="height: 20px">
                                    <cc2:OnlyNumbersTextBox ID="txt_nr_importacao" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox>
                                    &nbsp;
                                </td>


                                         
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 23px; " align="right">
                                    Situação Nota:</td>
                                <TD style="HEIGHT: 23px; ">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_situacao_nota" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 23px">
                                     Nome Emitente:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_emitente" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="200" Width="200px"></anthem:TextBox></td>
                                <td align="right" style="height: 23px">
                                    Nome Destinatário:</td>
                                <td style="height: 23px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="200" Width="200px"></anthem:TextBox></td>
                                <td style="height: 23px">
                                </td>
                            </tr>
 							
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Nr. Nota:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_nr_nota" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox></td>
 								<TD style="HEIGHT: 3px; " align="right">
                                     Nr. Pedido Inf. Nota:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_nr_pedido_nota" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox></TD>
                                <td style="height: 3px" align="right">
                                    Nr Pedido Central:</td>
                                <td style="height: 3px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_id_pedido_central" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox></td>
                                <td align="center" colspan="2" style="height: 3px">
                                    </td>
                           </tr>
                          
							<tr>
								<TD align="right" style="height: 30px">&nbsp;Último Nr Importação:</TD>
                                <td align="left" style="height: 30px">
                                    &nbsp;&nbsp;<anthem:Label ID="lbl_nr_importacao_ultimo" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Italic="False" Font-Size="XX-Small" Text="1012" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" colspan="2" style="height: 30px">
                                    <anthem:CheckBox ID="chk_notasnaoimportadas" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Visualizar Notas Não Importadas no Sistema" /></td>
                                <td align="right" colspan="4" style="height: 30px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar" AutoUpdateAfterCallBack="True"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_pesquisar" Visible="False" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif" AutoUpdateAfterCallBack="True"></anthem:imagebutton>
                                    &nbsp;&nbsp;</td>
							</tr>
						</TABLE>
					</TD>
					<TD class="texto" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;" class="texto">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; font-size: x-small;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp; &nbsp;&nbsp;
                        <anthem:Image ID="Image2" runat="server" ImageUrl="~/img/sincronizar.png" />
                        <anthem:LinkButton ID="btn_revalidardivergencias" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Size="XX-Small" ToolTip="Revalidar Notas Com Impedimento">Revalidar Notas Com Impedimento</anthem:LinkButton>
                        &nbsp; &nbsp; &nbsp;
                        <anthem:Image ID="Image3" runat="server" ImageUrl="~/img/ico_excluir.gif" Visible="False" />
                        <anthem:LinkButton ID="btn_excluirnotas" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Size="XX-Small" ToolTip="Revalidar Notas Com Impedimento" Visible="False">Excluir Notas Selecionadas</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px" class="texto">&nbsp;</TD>
				</TR>				<TR>
					<TD style="height: 2px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 2px" class="texto">
                    </TD>
					<TD style="height: 2px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center">
                                    <anthem:GridView ID="gridFiles" runat="server" AddCallBacks="False" AllowPaging="True" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"
                            GridLines="None" UpdateAfterCallBack="True" Width="99%" DataKeyNames="id_central_notas_importacao" CellSpacing="2">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                                             <asp:TemplateField HeaderText="Det." ShowHeader="False">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe" runat="server" AutoUpdateAfterCallBack="True" Text="Select" ImageUrl="~/img/icon_preview.gif" CausesValidation="False" CommandName="Select" __designer:wfdid="w542"></anthem:ImageButton> 
</itemtemplate>
                                                                 <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                <asp:BoundField DataField="id_importacao" HeaderText="Nr Execu&#231;&#227;o" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_criacao" DataFormatString="{0:d}" HeaderText="Dt Imp." />
                                <asp:BoundField DataField="nm_emitente" HeaderText="Fornecedor" ReadOnly="True" />
                                <asp:BoundField DataField="cd_CNPJ_emit" HeaderText="CNPJ" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_destino" HeaderText="Produtor" />
                                <asp:BoundField DataField="cpf_cnpj_dest" HeaderText="CPF/CNPJ" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_remetente" HeaderText="Remetente" />
                                <asp:BoundField DataField="cd_cnpj_rem" HeaderText="CNPJ" />
                                <asp:TemplateField HeaderText="Nr Nota">
                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Text='<%# bind("nr_nota_fiscal") %>' __designer:wfdid="w543" Font-Underline="True"></asp:HyperLink> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_emissao" HeaderText="Emiss&#227;o" ReadOnly="True" DataFormatString="{0:d}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Vl Nota" DataField="nr_valor_nf" DataFormatString="{0:C2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_pedido" HeaderText="Pedido Inf." ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_central_notas" HeaderText="Sit. Nota" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="id_central_pedido" DataNavigateUrlFormatString="~/frm_central_pedido.aspx?id_central_pedido={0}"
                                    DataTextField="id_central_pedido" HeaderText="Nr Pedido" NavigateUrl="~/frm_central_pedido.aspx"
                                    Target="_blank" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:HyperLinkField>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Nota Importada" __designer:wfdid="w15" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir a nota importada?' )) return true;else return false;" CommandArgument='<%# Bind("id_central_notas_importacao") %>'></anthem:ImageButton>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_nota" ShowHeader="False" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_nota" runat="server" Text='<%# Bind("id_situacao_central_notas") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="12" AddCallBacks="False" UpdateAfterCallBack="True" Visible="False">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_importacao" HeaderText="Nr Execucao" />
                                                <asp:BoundField DataField="nm_arquivo" HeaderText="Diret&#243;rio Arquivos" />
                                                <asp:BoundField DataField="nr_linha" HeaderText="Nr Linha" SortExpression="nr_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_erro" HeaderText="Nome NFe" />
                                                <asp:BoundField DataField="nm_erro" HeaderText="Nome do Erro" SortExpression="nm_erro" />
                                                <asp:BoundField HeaderText="Nr Nota" />
                                                <asp:BoundField HeaderText="Nome Emitente" />
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
				<TR id="tr_detalhes" runat="server">
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top">
					<anthem:Panel ID="pnl_romaneio" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes das Divergências" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%"   id="TABLE4" 
                             cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" colspan="7" style="height: 18px">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>

                                </tr>
                            </table>
                        <anthem:GridView ID="gridDoc" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="20" UpdateAfterCallBack="True"
                            Width="95%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_cd_divergencia" HeaderText="C&#243;digo" >
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Diverg&#234;ncia" DataField="ds_divergencia" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>
                                       
					</anthem:Panel>				

					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_importar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
