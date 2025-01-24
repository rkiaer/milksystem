<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_ciq_documento.aspx.vb" Inherits="lst_ciq_documento" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Controle de Incidente de Qualidade CIQ - Documentos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Controle de Incidente de Qualidade - Cadastro de Documentos</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 26px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 26px">&nbsp;</TD>
				</TR>
								<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td1" runat="server"  class="texto" >
                        <br />
						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="height: 3px"></TD>
								<TD style="height: 3px; ;"></TD>
								<TD style="height: 3px; "></TD>
								<TD style="height: 3px"></TD>
                                <td style="width: 10%; height: 3px">
                                </td>
							</TR>
                            <tr>
                                <TD  style="HEIGHT: 28px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 28px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Escolha o Estabelecimento para continuar." Font-Bold="True" AutoUpdateAfterCallBack="True" ValidationGroup="vgpedido" InitialValue="0">[!]</anthem:RequiredFieldValidator></td>
 								<TD  style="height: 28px; " align="right">
                                     Tipo de Incidente:</TD>
								<TD style="height: 28px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo_incidente_filtro" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto">
                                        <asp:ListItem Value="1">CIQ</asp:ListItem>
                                        <asp:ListItem Value="2">CIQP</asp:ListItem>
                                        <asp:ListItem Value="3">CIQT</asp:ListItem>
                                        <asp:ListItem Value="4">CIQR</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList>&nbsp;</TD>
                                <td style="height: 28px">
                                </td>
                           </tr>
							<TR>
								<TD style="height: 28px"></TD>
								<TD style="height: 28px; ">
                                    </TD>
								<TD style="height: 28px" >&nbsp;</TD>
                                <td align="right" colspan="2" style="height: 28px">
                                    &nbsp;<anthem:ImageButton ID="btn_pesquisar" runat="server" ImageUrl="~/img/bnt_pesquisa.gif"
                                        ValidationGroup="vgpesquisar" />
                                    &nbsp; &nbsp;<anthem:imagebutton id="btn_limpar" runat="server" imageurl="~/img/btn_limparfiltro.gif" ValidationGroup="vgpedido" ></anthem:imagebutton>&nbsp;&nbsp;
                                    &nbsp; &nbsp;</td>
							</TR>
						</TABLE>
					</TD>
					<TD  >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 26px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 2px; width: 9px;" class="texto"></TD>
					<TD vAlign="middle" style="height: 2px" class="texto">&nbsp;INCLUSÂO DOS DOCUMENTOS DE INCIDENTE:</TD>
					<TD style="height: 2px" class="texto"></TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="height: 28px; width: 16%; border-bottom: #f0f0f0 1px solid;" align="right" class="texto">
                                    Estabelecimento:</td>
                                <TD style="height: 28px; border-right: #f0f0f0 1px solid; width: 31%; border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Poços de Caldas" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                </td>
                                <TD style="height: 28px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="center" colspan="2">
                                    &nbsp;<span style="color: #ff0000"><strong>*</strong></span>Tipo de Incidente:&nbsp;
                                    <anthem:DropDownList ID="cbo_ds_tipo_incidente" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto">
                                        <asp:ListItem Value="1">CIQ</asp:ListItem>
                                        <asp:ListItem Value="2">CIQP</asp:ListItem>
                                        <asp:ListItem Value="3">CIQT</asp:ListItem>
                                        <asp:ListItem Value="4">CIQR</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_ds_tipo_incidente" CssClass="texto" ErrorMessage="Escolha o Tipo de Incidente para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vganexar" Visible="False">[!]</anthem:RequiredFieldValidator>
                                </td>
                                <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                    height: 28px">
                                    &nbsp;
                                    <anthem:CheckBox ID="chk_obrigatorio" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Documento Obrigatório" /></td>
                            </tr>
                            <tr>
                                <TD  style="HEIGHT: 28px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Selecione o Documento:</td>
                                <td align="left" colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                    height: 28px">
                                    &nbsp;<anthem:FileUpload ID="fup_documento" runat="server" CssClass="texto" Width="85%"  />
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fup_documento"
                                        CssClass="texto" ErrorMessage="Escolha o arquivo para continuar." Font-Bold="True" AutoUpdateAfterCallBack="True" ValidationGroup="vganexar">[!]</anthem:RequiredFieldValidator><anthem:Button
                                        ID="btn_limpar_selecao" runat="server" Text="Limpar" CssClass="texto" ToolTip="Limpar Seleção de Arquivo" /><span style="color: #ff0000"></span></td>
                                <TD style="height: 28px; width: 18%; border-bottom: #f0f0f0 1px solid;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000"> *</span></strong>Nome Documento a ser
                                    Exibido:</td>
                                <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 28px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"></anthem:TextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_nm_documento" CssClass="texto" ErrorMessage="Escolha o Nome do Documento para continuar."
                                        Font-Bold="True" ValidationGroup="vganexar" Visible="False">[!]</anthem:RequiredFieldValidator></td>
                           </tr>
                            <tr>
                                <td align="center" colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                    height: 25px" valign="bottom">
                                    &nbsp;&nbsp;
                                    <anthem:Label ID="lbl_msg" runat="server" Text="Arquivo Anexado com Sucesso!" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Bold="False" Font-Italic="True" ForeColor="Red"></anthem:Label>&nbsp;
                                    &nbsp;&nbsp; &nbsp;</td>
								<TD style="height: 25px; border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid;" align="right">
                                    </TD>
								<TD style="height: 25px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="right" colspan="2">
                                    &nbsp;<anthem:Button ID="btn_anexar" runat="server" Text="Anexar Documento" CssClass="texto" ValidationGroup="vganexar" />&nbsp;&nbsp;&nbsp;
                                </TD>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="200" AddCallBacks="False" UpdateAfterCallBack="True" DataKeyNames="id_ciq_documentos">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                ForeColor="White" HorizontalAlign="Left" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" SortExpression="ds_estabelecimento" />
                                                <asp:BoundField DataField="ds_tipo_incidente" HeaderText="Tipo Incidente" SortExpression="ds_tipo_incidente" />
                                                <asp:TemplateField HeaderText="Nome do Documento" SortExpression="nm_documento">
                                                    <itemtemplate>
<asp:Label id="lbl_nm_documento" runat="server" Text='<%# Bind("nm_documento") %>' __designer:wfdid="w327"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_extensao" HeaderText="Extens&#227;o" ReadOnly="True" />
                                                <asp:BoundField DataField="st_obrigatorio" HeaderText="Obrigat&#243;rio" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Arquivo">
                                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" __designer:wfdid="w332" Font-Underline="True">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w334"  OnClientClick="if (confirm('Deseja realmente excluir este documento de controle de incidente de qualidade?' )) return true;else return false;" CommandName="delete" ToolTip="Excluir Documento" CommandArgument='<%# bind("id_ciq_documentos") %>' ImageAlign="Baseline"></anthem:ImageButton>
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vganexar" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpesquisar" />
		</form>
	</body>
</HTML>
