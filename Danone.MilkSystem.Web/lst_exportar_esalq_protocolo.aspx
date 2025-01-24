<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_esalq_protocolo.aspx.vb" Inherits="lst_exportar_esalq_protocolo" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc6" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_exportar_esalq_protocolo</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG> Protocolos Clínica do Leite&nbsp; -&nbsp; Exportação e Pesquisa</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; width: 20%;"></TD>
                                <td style="height: 12px">
                                </td>
								<TD style="height: 12px; width: 22%;"></TD>
							</TR>
                            <tr>
                                <TD   align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD >
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" >
                                    </asp:DropDownList><anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
 								<TD   align="right">
                                     <strong><span style="color: #ff0000">*</span></strong><span style="color: #333333">Mes/Ano
                                        Referência</span>:</TD>
                                <td align="left">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc2:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_referencia"
                                            CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
								<TD align="left" >
                                    &nbsp;<anthem:CheckBox ID="ck_exportadas" runat="server" Text="Protocolos já exportados"  /></TD>
                           </tr>
							<TR>
								<TD align="right">
                                    Tipo de Coleta:</TD>
								<TD >
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_tipo_coleta" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
								<TD  align="right">
                                    Período em Dias:</TD>
                                <td align="left">
                                    &nbsp;
                                    <cc6:onlynumberstextbox id="txt_dia_ini" runat="server" cssclass="texto"
                                        maxlength="2" width="30px"></cc6:onlynumberstextbox>
                                    à
                                    <cc6:onlynumberstextbox id="txt_dia_fim" runat="server" cssclass="texto" maxlength="2"
                                        width="30px"></cc6:onlynumberstextbox>
                                    <anthem:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_dia_ini"
                                        ErrorMessage="O Dia Inicial da 1a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                        MinimumValue="1" ToolTip="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                        Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim" ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                            MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                            Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini" ControlToValidate="txt_dia_fim"
                                                ErrorMessage="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
								<TD align="left" >
                                    &nbsp;<anthem:CheckBox ID="chk_protocolo_descartado" runat="server" Text="Protocolos Descartados" AutoPostBack="True" Visible="False"  /></TD>
							</TR>
                            <tr>
                                <td style="height: 30px" align="center" colspan="3"  >
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="100%">Aguarde... Geração do arquivo em andamento...</anthem:Label></td>
                                <td align="right" colspan=2 style="height: 30px">
                                    <anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                        ToolTip="Pesquisar Protocolos ESALQ" ValidationGroup="vg_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisar" ToolTip="Exportar para Excel " ></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar_esalq" runat="server" ImageUrl="~/img/bnt_exportar_esalq.gif"
                                        ValidationGroup="vg_pesquisar" OnClientClick="if (confirm('Deseja realmente exportar os PROTOCOLOS para ESALQ?' )) return true;else return false;" ToolTip="Exportar Identificação de Protocolos ESALQ" AutoUpdateAfterCallBack="True" PostCallBackFunction="if (confirm('Deseja POST realmente exportar os PROTOCOLOS para ESALQ?' )) return true;else return false;" PreCallBackFunction="if (confirm('Deseja PRE realmente exportar os PROTOCOLOS para ESALQ?' )) return true;else return false;" />&nbsp;
                                    <anthem:ImageButton ID="btn_limparFiltros" runat="server" ImageUrl="img/btn_limparfiltro.gif" />
                                    &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<anthem:Label ID="lbl_totallidas" runat="server" Text="Total de Protocolos exportadas:" Visible="False"></anthem:Label>
                        <anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False"></anthem:Label></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 10px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 10px">&nbsp;</TD>
					<TD style="height: 10px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD valign="top">
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" DataKeyNames="id_analise_esalq_protocolo"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="15" UpdateAfterCallBack="True"
                            Width="100%" GridLines="None">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" SortExpression="id_propriedade_matriz" />
                                <asp:BoundField HeaderText="Rota" SortExpression="nm_linha" Visible="False" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"
                                    SortExpression="id_tipo_coleta_analise_esalq" />
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" />
                                <asp:BoundField DataField="nm_tipo_frasco" HeaderText="Frasco" ReadOnly="True" />
                                <asp:BoundField DataField="cd_protocolo_esalq" HeaderText="Protocolo" ReadOnly="True" />
                                <asp:BoundField DataField="st_exportacao" HeaderText="Exp." ReadOnly="True" />
                                <asp:BoundField DataField="dt_exportacao" HeaderText="Data Exp." SortExpression="dt_exportacao" />
                                <asp:BoundField DataField="nm_arquivo" HeaderText="Nome Arquivo" SortExpression="nm_arquivo" />
                                <asp:BoundField DataField="id_analise_esalq_protocolo" HeaderText="id_analise_esalq_protocolo" ReadOnly="True"
                                    Visible="False" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView><anthem:GridView ID="gridDescartados" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="15" UpdateAfterCallBack="True"
                            Width="100%" GridLines="None" Visible="False">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" SortExpression="id_propriedade_matriz" />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"
                                    SortExpression="id_tipo_coleta_analise_esalq" />
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" />
                                <asp:BoundField DataField="nm_tipo_frasco" HeaderText="Frasco" ReadOnly="True" />
                                <asp:BoundField DataField="cd_protocolo_esalq" HeaderText="Protocolo" ReadOnly="True" />
                                <asp:BoundField DataField="nm_motivo_nao_coleta_amostra" HeaderText="Descarte Coleta" ReadOnly="True" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" />
                                <asp:BoundField DataField="nm_motivo_descarte_romaneio_amostra" HeaderText="Descarte Romaneio" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                    </TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
