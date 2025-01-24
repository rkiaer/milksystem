<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_contrato_aprovar_2N.aspx.vb" Inherits="lst_contrato_aprovar_2N" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

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
		<title>Aprovar Contrato 2o Nível</title>
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


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Contrato&nbsp;2.o Nível</STRONG></TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
                        <table id="Table3" cellpadding="0" cellspacing="0" class="borda" width="100%">
                            <tr>
                                <td align="right" style="height: 10px">
                                </td>
                                <td colspan="2" style="height: 10px">
                                </td>
                                <td align="right" class="texto" colspan="1" style="height: 10px">
                                </td>
                                <td colspan="1" style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 22%; height: 23px">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td colspan="2" style="width: 28%; height: 23px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual" Type="Integer"
                                        ValidationGroup="vg_pesquisar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                <td align="right" class="texto" colspan="1" style="width: 12%; color: #333333; height: 23px">
                                    <strong><span style="color: #ff0000">*</span></strong>Referência:</td>
                                <td colspan="1" style="width: 38%; height: 23px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="A Referência deve ser informada." Font-Bold="True" ValidationGroup="vg_pesquisar" ToolTip="A referência deve ser informada.">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr runat="server" id="tr_codigos" visible="false">
                                <td align="right" style="height: 23px">
                                    Código do Contrato:</td>
                                <td colspan="2" style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_contrato" runat="server" CssClass="caixatexto" MaxLength="5"
                                        Width="74px"></anthem:TextBox></td>
                                <td align="right" style="height: 23px">
                                    Nome Contrato:</td>
                                <td align="left" class="texto" style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_contrato" runat="server" CssClass="caixatexto" MaxLength="50"
                                        Width="350px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="5">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <br />
					</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
					    &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar </anthem:linkbutton>&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
					</TD>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 9px; width: 5px;"></TD>
					<TD vAlign="middle" style="height: 9px; ">&nbsp;</TD>
					<TD style="height: 9px; width: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="texto" >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_contrato_validade" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True" __designer:wfdid="w221"></asp:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server"  Checked='<%# bind("st_selecao") %>' __designer:wfdid="w219"></asp:CheckBox> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" SortExpression="nm_estabelecimento" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_contrato" HeaderText="Contrato" SortExpression="cd_contrato" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_contrato" HeaderText="Nome Contrato" />
                                                <asp:BoundField DataField="st_contrato_comercial" HeaderText="Comercial" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_contrato_mercado" HeaderText="Mercado" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a partir" />
                                                <asp:TemplateField HeaderText="Faixa Qualidade">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe_qualidade" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Visualizar Faixas de Qualidade do Contrato" ImageUrl="~/img/icon_preview.gif" __designer:wfdid="w204" CommandName="detalhequalidade"></anthem:ImageButton>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adicional Volume">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe_volume" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Visualizar Adicional de Volume do Contrato" ImageUrl="~/img/icon_preview.gif" __designer:wfdid="w201" CommandName="detalhevolume"></anthem:ImageButton>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_situacao_contrato" HeaderText="Situa&#231;&#227;o Contrato" />
                                                <asp:TemplateField HeaderText="id_contrato_validade" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_contrato_validade" runat="server" Text='<%# Bind("id_contrato_validade") %>' __designer:wfdid="w209"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_contrato_validade" runat="server" Text='<%# Bind("id_contrato_validade") %>' __designer:wfdid="w207"></asp:Label>
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
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; " class="texto">&nbsp;
                        <anthem:Panel ID="pnl_qualidade" runat="server" AutoUpdateAfterCallBack="True" BackColor="White"
                            CssClass="texto" Font-Size="X-Small" GroupingText="Detalhes Faixa Qualidade"
                            HorizontalAlign="Center" Visible="False" Width="100%">
                            <table width="100%">
                                <tr>
                                    <td align="left" style="width: 100%; height: 2px">
                                        &nbsp;
                                        <asp:Label ID="lbl_categoria" runat="server" CssClass="texto" Width="46px">Categoria:</asp:Label>&nbsp;<anthem:DropDownList
                                            ID="cbo_categoria" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True"
                                            CssClass="texto">
                                        </anthem:DropDownList>&nbsp;</td>
                                    <td align="right" style="width: 100%; height: 2px">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            &nbsp;<anthem:GridView ID="gridQualidade" runat="server" AutoGenerateColumns="False"
                                AutoUpdateAfterCallBack="True" DataKeyNames="id_faixa_qualidade" Font-Names="Verdana"
                                Font-Size="XX-Small" PageSize="50" UpdateAfterCallBack="True" Width="98%">
                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                <Columns>
                                    <asp:BoundField DataField="nm_categoria" HeaderText="Categoria" />
                                    <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a Partir" />
                                    <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" />
                                    <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True">
                                        <itemstyle wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_bonus_desconto" HeaderText="B&#244;nus/Desconto" />
                                    <asp:BoundField DataField="un_medida" HeaderText="Unid.Medida" />
                                    <asp:BoundField DataField="id_contrato_validade" ReadOnly="True" Visible="False" />
                                </Columns>
                            </anthem:GridView>
                        </anthem:Panel>
                        <anthem:Panel ID="pnl_adicionalvolume" runat="server" AutoUpdateAfterCallBack="True"
                            BackColor="White" CssClass="texto" Font-Size="X-Small" GroupingText="Detalhes Adicional de Volume"
                            HorizontalAlign="Center" Visible="False" Width="100%">
                            <br />
                            <anthem:GridView ID="grdAdicionalVolume" runat="server" AutoGenerateColumns="False"
                                AutoUpdateAfterCallBack="True"  CssClass="texto" DataKeyNames="id_contrato_adicional_volume"
                                Font-Names="Verdana" Font-Size="XX-Small" PageSize="100" UpdateAfterCallBack="True"
                                Visible="False" Width="98%">
                                <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                <PagerStyle Font-Names="Verdana" Font-Size="XX-Small"  />
                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />

                                <Columns>
                                    <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a Partir" />
                                    <asp:BoundField DataField="nr_litros_ini" HeaderText="De L/Dia" SortExpression="nr_litros_ini" />
                                    <asp:BoundField DataField="nr_litros_fim" HeaderText="At&#233; L/Dia" ReadOnly="True"
                                        SortExpression="nr_litros_fim" />
                                    <asp:BoundField DataField="nm_indicador_tipo" HeaderText="Indicador" />
                                    <asp:BoundField DataField="nr_indicador_percentual" HeaderText="%" SortExpression="nr_indicador_percentual" />
                                    <asp:TemplateField HeaderText="Ref. Ind.">
                                        <itemtemplate>
<asp:Label id="lbl_referencia_indicador" runat="server" __designer:wfdid="w79"></asp:Label>
</itemtemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nr_adicional_24hrs" HeaderText="Adicional 24hrs" SortExpression="nr_adicional_24hrs" />
                                    <asp:BoundField DataField="st_formato_24hrs" />
                                    <asp:BoundField DataField="nr_adicional_48hrs" HeaderText="Adicional 48hrs" SortExpression="nr_adicional_48hrs" />
                                    <asp:BoundField DataField="st_formato_48hrs" />
                                    <asp:TemplateField HeaderText="id_contrato_adicional_volume" Visible="False">
                                        <edititemtemplate>
<asp:Label id="lbl_id_contrato_adicional_volume" runat="server" Text='<%# Bind("id_contrato_adicional_volume") %>' __designer:wfdid="w49"></asp:Label>&nbsp;&nbsp; 
</edititemtemplate>
                                        <itemtemplate>
<asp:Label id="lbl_id_contrato_adicional_volume" runat="server" Text='<%# Bind("id_contrato_adicional_volume") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="nr_mes_indicador" Visible="False">
                                        <itemtemplate>
<asp:Label id="lbl_nr_mes_indicador" runat="server" Text='<%# Bind("nr_mes_indicador") %>' __designer:wfdid="w77"></asp:Label>
</itemtemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </anthem:GridView>
                            &nbsp;
                        </anthem:Panel>
					</TD>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;</div>
		</form>
	</body>
</HTML>
