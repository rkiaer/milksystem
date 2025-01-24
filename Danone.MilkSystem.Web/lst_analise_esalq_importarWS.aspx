<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_analise_esalq_importarWS.aspx.vb" Inherits="lst_analise_esalq_importarWS" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Importar Análises Externas Propriedade</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		
	</head>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
			<script type="text/javascript"> 
    <!--
    function showaguarde() 
    
    {
        
        document.all.lbl_aguarde.value='aguardenormal';  	     
    }            
    //-->
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Importar Análises Externas Propriedade - Clínica do Leite via WebService</STRONG></TD>
					<TD  style="height: 27px">&nbsp;</TD>
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
								<TD width="10%" style="height: 12px; width: 18%;"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; width: 15%;"></TD>
								<TD style="height: 12px; width: 25%;"></TD>
							</TR>
                            <tr>
                                <TD width="10%" style="HEIGHT: 12px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 20px; ">
                                    &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                <TD  style="height: 12px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Grupo:</td>
                                <TD style="height: 12px">
                                    &nbsp;<asp:DropDownList ID="cbo_Grupo" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_Grupo"
                                        CssClass="texto" ErrorMessage="Preencha o campo Grupo para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Processamento:&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;<cc3:onlydatetextbox id="txt_dt_processamento" runat="server" cssclass="texto"
                                        width="96px"></cc3:onlydatetextbox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_dt_processamento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Processamento para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    <span style="color: #ff0000"><span style="color: #ff0000"><strong>*</strong></span><span
                                        style="color: #333333">Tipo da Coleta:</span></td>
                                <td style="height: 20px; ">
                                    &nbsp;<anthem:DropDownList ID="cbo_tipo_coleta" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem>Tanque</asp:ListItem>
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="cbo_tipo_coleta" CssClass="texto" ErrorMessage="Preencha o campo Tipo da Coleta para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
								<TD style="height: 20px; " align="right">
                                    <anthem:Label ID="lbl_totalimportadas" runat="server" Text="Status da Importação:" ></anthem:Label></TD>
								<TD style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_statusimportacaoclinica" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                            </tr>
                            <tr id="progresso">
                                <td colspan="3" style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                    <center>
                                        <anthem:Image ID="Image1" runat="server" Height="17px" ImageUrl="img/ProgressBar.gif"
                                            Visible="False" Width="194px" /></center>
                                    <center>
                                        <anthem:Label ID="Label2" runat="server" CssClass="texto" Visible="False" Width="336px"></anthem:Label></center>
                                    &nbsp;
                                </td>
                                <td align="right" style="height: 20px">
                                    &nbsp;<anthem:Timer ID="Timer1" runat="server">
                                    </anthem:Timer>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_importar.gif" ></anthem:imagebutton>
                                    <anthem:ImageButton ID="btn_resultado" runat="server" ImageUrl="~/img/bnt_resultado.gif" Enabled="False" Visible="False" />
                                    &nbsp;&nbsp; &nbsp;</td>
                            </tr>
							<TR>
								<TD style="height: 6px"></TD>
								<TD style="height: 6px; ">
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="100%">Aguarde... Geração do arquivo em andamento...</anthem:Label>&nbsp;
                                    </TD>
								<TD align="right" colspan="2" style="height: 6px" >&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_impressao1" runat="server" ImageUrl="~/img/ic_impressao.gif"></asp:Image>
                        <anthem:HyperLink ID="hl_imprimir" runat="server" CssClass="texto" NavigateUrl="~/frm_relatorio_analise_esalq.aspx"
                            Target="_blank" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Enabled="False">Relatório Consistências</anthem:HyperLink>&nbsp;
                        <asp:Image ID="img_impressao2" runat="server" ImageUrl="~/img/ic_impressao.gif" /><anthem:HyperLink
                            ID="hl_imprimirWS" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_analise_esalqWS.aspx" Target="_blank"
                            UpdateAfterCallBack="True">Relatório Dados Clínica Leite</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px; ">&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="20" AddCallBacks="False" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_importacao" HeaderText="Nr.Exec." />
                                                <asp:BoundField DataField="nr_linha" HeaderText="Nr Linha" SortExpression="nr_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Coop." />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_unidade_producao" HeaderText="UP" />
                                                <asp:BoundField DataField="id_linha" HeaderText="Rota" />
                                                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" />
                                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" />
                                                <asp:BoundField DataField="dt_processamento" HeaderText="Data Envio" />
                                                <asp:BoundField DataField="dt_analise" HeaderText="Data An&#225;lise" />
                                                <asp:BoundField DataField="cd_analise_esalq" HeaderText="C&#243;d.An&#225;lise" />
                                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado" />
                                                <asp:BoundField DataField="cd_protocolo" HeaderText="Protocolo" />
                                                <asp:BoundField DataField="nm_erro" HeaderText="Observa&#231;&#227;o" SortExpression="nm_erro" />
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
