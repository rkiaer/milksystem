<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_resumo_calculo.aspx.vb" Inherits="lst_relatorio_resumo_calculo" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Resumo Cálculo</title>
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


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Relatório Resumo Cálculo</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; " ></TD>
								<TD style="height: 12px; "></TD>
							</TR>
 			                <tr>
			                    <td align="right" style="height: 20px; width=20%;">
                                    Mes/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_data" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>
                                    &nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data"
                                        CssClass="texto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
 							</tr>
 							
                          
							<tr>
								<TD align="right"  style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif"></asp:Image>
                        <anthem:HyperLink ID="hl_imprimir" runat="server" CssClass="texto" NavigateUrl="~/frm_relatorio_motorista.aspx"
                            Target="_blank" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Enabled="False">Versão para Imprimir</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" ShowFooter="True"><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="T&#233;cnico" DataField="nm_tecnico" >
                                    <itemstyle width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="volumereal" HeaderText="Volume Real" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="negociado" HeaderText="Negociado" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="notafiscal" HeaderText="Nota Fiscal" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="incentivo" HeaderText="Incentivo" ReadOnly="True" >
                                    <itemstyle wrap="False" width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="frete" HeaderText="Frete" ReadOnly="True">
                                    <itemstyle wrap="False" width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="totalqualidade" HeaderText="Qualidade" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridCooperativa" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" ShowFooter="True" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="T&#233;cnico" DataField="nm_tecnico" >
                                    <itemstyle width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="volumereal" HeaderText="Volume Real" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="negociado" HeaderText="Negociado" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="notafiscal" HeaderText="Nota Fiscal" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="incentivo" HeaderText="Incentivo" ReadOnly="True" >
                                    <itemstyle wrap="False" width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="frete" HeaderText="Frete" ReadOnly="True">
                                    <itemstyle wrap="False" width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="totalqualidade" HeaderText="Qualidade" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total" >
                                    <itemstyle width="100px" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        &nbsp;
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
