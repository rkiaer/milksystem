<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_RelacaoCIQ_CIQPEmitidos.aspx.vb" Inherits="lst_RelacaoCIQ_CIQPEmitidos" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_util_ExportaVolumeRomaneio</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Relação de CIQ/CIQP Emitidos</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 6px;"></TD>
					<TD align="center" style="height: 6px">
						</TD>
					<TD width="10" style="height: 6px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" class="texto" style="height: 23px" width="23%">
                                    Estabelecimento<strong>:</strong></td>
                                <td style="height: 23px" width="77%">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="true"
                                        AutoPostBack="false" AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span style="color: #ff0000">*</span>Emitente:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_emitente" runat="server" CssClass="texto" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load"><asp:ListItem>[Selecione]</asp:ListItem>
<asp:ListItem>Produtor</asp:ListItem>
<asp:ListItem>Cooperativa</asp:ListItem>
</anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_emitente" ErrorMessage="O emitente deve ser informado!"
                                        InitialValue="[Selecione]" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Período:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" Width="72px" ValidationGroup="vg_load"></cc2:OnlyDateTextBox>&nbsp;
                                    à &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" Width="72px" ValidationGroup="vg_load"></cc2:OnlyDateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    </td>
                                <td style="height: 20px">
                                    &nbsp;
                                    </td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right">
                                    &nbsp;
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px; height: 24px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 24px" valign="middle">
                        &nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" /><anthem:HyperLink
                            ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_CIQ_CIQPEmitidos.aspx" Target="_blank"
                            UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink></td>
                    <td style="height: 24px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 5px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 5px">&nbsp;</TD>
					<TD style="height: 5px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Data de Entrada" SortExpression="dt_hora_entrada" />
                                                <asp:BoundField DataField="id_romaneio" HeaderText="N&#186; Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField DataField="nm_rota" HeaderText="Nome Rota" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                <asp:BoundField DataField="nm_compartimento" HeaderText="Compartimento" />
                                                <asp:HyperLinkField DataNavigateUrlFields="id_romaneio_compartimento" DataNavigateUrlFormatString="~/frm_relatorio_ciq.aspx?id_romaneio_compartimento={0}"
                                                    DataTextField="id_romaneio_compartimento" HeaderText="N&#186; CIQ" NavigateUrl="~/frm_relatorio_ciq.aspx"
                                                    Target="_blank" />
                                                <asp:HyperLinkField DataNavigateUrlFields="id_romaneio_uproducao" DataNavigateUrlFormatString="~/frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}"
                                                    DataTextField="id_romaneio_uproducao" HeaderText="N&#186; CIQP" NavigateUrl="~/frm_relatorio_CIQP.aspx"
                                                    Target="_blank" />
                                                <asp:TemplateField HeaderText="Qtd. N&#227;o Conf.">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_total_litros" runat="server" Text='<%# Bind("nr_total_litros") %>' __designer:wfdid="w37"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qtd. Rej.">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_litros" runat="server" Text='<%# Bind("nr_litros") %>' __designer:wfdid="w40"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                               <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d. Produtor" />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="C&#243;d. Propriedade" />
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="Unidade Produ&#231;&#227;o" />
                                                <asp:BoundField DataField="ds_motivo_rejeicao" HeaderText="Motivo Rejei&#231;&#227;o" />
                                                <asp:BoundField DataField="ds_destino_leite" HeaderText="Destino Leite" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
		</form>
	</body>
</HTML>
