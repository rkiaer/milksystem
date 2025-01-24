<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_SAP_importar_selecao.aspx.vb" Inherits="lst_SAP_importar_selecao" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_SAP_importar</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Importar SAP&nbsp;</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 133px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%" style="height: 12px"></TD>
								<TD style="height: 12px; width: 439px;"></TD>
								<TD style="height: 12px; width: 156px;"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td colspan="2" style="height: 20px">
                                    &nbsp;Selecione o &nbsp;Arquivo para Importação:</td>
 								<TD  style="height: 20px; width: 156px;" align="right">
                                     </TD>
								<TD style="height: 20px">
                                    &nbsp;<asp:Button ID="btnteste" runat="server" Height="19px" Text="Teste Dir" Visible="False" /></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas lidas:"
                                         Width="160px"></anthem:Label></td>
                                <td align="left" style="height: 20px" ><anthem:Label ID="lbl_totallinhaslidas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
								<TD style="height: 20px; width: 156px;" align="right">
                                    <anthem:Label ID="lbl_totalimportadas" runat="server" Text="Total de linhas importadas:" Width="160px"></anthem:Label></TD>
								<TD style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhasimportadas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px; width: 439px;">
                                    <anthem:Label ID="lbl_Aguarde" runat="server" AutoUpdateAfterCallBack="True" Font-Italic="True"
                                        ForeColor="Blue" Text="Importação em andamento... Aguarde..." UpdateAfterCallBack="True"
                                        Visible="False"></anthem:Label></TD>
								<TD style="width: 156px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:CustomValidator ID="cv_importacao" runat="server" Font-Bold="True" ForeColor="White">[!]</anthem:CustomValidator>&nbsp;<anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_importar.gif" ></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
                            <tr>
                                <td align="center" colspan="4" style="height: 12px">
                                    <anthem:GridView ID="gridFiles" runat="server" AddCallBacks="False" AllowPaging="True" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"
                            GridLines="None" PageSize="12" UpdateAfterCallBack="True" Width="98%" DataKeyNames="nm_arquivo" AllowSorting="True">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="chk_todos" runat="server" __designer:wfdid="w3" AutoPostBack="True" oncheckedchanged="chk_todos_CheckedChanged"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<asp:CheckBox id="chk_item" runat="server" __designer:wfdid="w2"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_arquivo" HeaderText="Nome do Arquivo" SortExpression="nm_arquivo" ReadOnly="True" />
                                <asp:BoundField DataField="dt_criacao" HeaderText="Data de Cria&#231;&#227;o" SortExpression="dt_criacao" ReadOnly="True" />
                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor" SortExpression="nm_fornecedor" ReadOnly="True" />
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="Cod.Sap" ReadOnly="True" SortExpression="cd_codigo_sap" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;
                    </TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="12" AddCallBacks="False" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_arquivo" HeaderText="Nome Arquivo" />
                                                <asp:BoundField DataField="nr_linha" HeaderText="N&#250;mero da Linha" SortExpression="nr_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_importacao" HeaderText="Situa&#231;&#227;o da Importa&#231;&#227;o" SortExpression="st_importacao" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_erro" HeaderText="C&#243;digo do Erro" SortExpression="cd_erro" />
                                                <asp:BoundField DataField="nm_erro" HeaderText="Nome do Erro" SortExpression="nm_erro" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
&nbsp; 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
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
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
		</form>
	</body>
</HTML>
