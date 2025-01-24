<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_coopera_importar.aspx.vb" Inherits="lst_coopera_importar" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Importar dados Coopera&nbsp;</STRONG></TD>
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
					<TD id="td_pesquisa" runat="server" style="height: 133px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%" style="height: 12px"></TD>
								<TD style="height: 12px; width: 439px;"></TD>
								<TD style="height: 12px; width: 156px;"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 12px" align="right">
                                    &nbsp;Nome Arquivo:</td>
                                 <td style="height: 20px; width: 439px;">
                                    &nbsp; &nbsp;<anthem:FileUpload ID="fup_nm_arquivo" runat="server" CssClass="texto" Width="405px"  />
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fup_nm_arquivo"
                                        CssClass="texto" ErrorMessage="Escolha o arquivo para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
 								<TD  style="height: 12px; width: 156px;" align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas lidas:"
                                         Width="160px"></anthem:Label></TD>
								<TD style="height: 12px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhaslidas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px" ></td>
                                <td align="right" style="height: 20px" ></td>
								<TD style="height: 20px; width: 156px;" align="right">
                                    <anthem:Label ID="lbl_totalimportadas" runat="server" Text="Total de linhas importadas:" Width="160px"></anthem:Label></TD>
								<TD style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhasimportadas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px; width: 439px;"></TD>
								<TD style="width: 156px">&nbsp;</TD>
								<TD align="right">
                                    &nbsp;<anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_importar.gif" ></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
						<BR>
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
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="12" AddCallBacks="False">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
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
