<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_calculo_produtor.aspx.vb" Inherits="frm_calculo_produtor" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>


<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Cálculo do Produtor</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE class="borda" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 922px;"><STRONG>Cálculo do Produtor</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="width: 922px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 383px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 383px; width: 922px;">
						<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
							
							
                            <tr>
                                <td align="right"  width="25%">
                                    <span style="color: #ff0000">*</span>Mes/Ano Referência:</td>
                                <td width="25%">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="71px"></cc4:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                <td width="50%" colspan="2"></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 22px" align="right" width="25%">
                                    <span style="color: #ff0000">*</span>Tipo de Pagamento:</TD>
								<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_tipo_pagamento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="120px">
                                </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_tipo_pagamento"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Tipo de Pagamento para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></TD>
                                <td colspan="2">
                                    <anthem:CheckBox ID="ck_calculo_definitivo" runat="server" CssClass="texto" Text='Calculo Definitivo ' /></td>
							</TR>
                            <tr>
                                <td colspan="3" style="height: 20px">
                                </td>
                                <td align="left" style="height: 20px">
                                    <anthem:Label ID="Label1" runat="server" CssClass="texto" ForeColor="Red">ATENÇÃO: Se a opção "Cálculo Definitivo" estiver ligada, os dados serão efetivados e não poderão mais ser recalculados.</anthem:Label></td>
                            </tr>
	                        <tr id="progresso">
		                        <TD colspan=3 style="height: 20px" >&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                    <center><anthem:Image ID="Image1" runat="server" ImageUrl="img/ProgressBar.gif" Visible="False" Height="17px" Width="194px" /></center>
                                    <center><anthem:Label ID="Label2" runat="server" Visible="False" CssClass="texto" Width="336px"></anthem:Label></center>
                                    &nbsp;
                                                                    </TD>
		                        <TD align="right" style="height: 20px" >
                                    &nbsp;<anthem:Timer ID="Timer1" runat="server">
                                    </anthem:Timer>
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<anthem:Button ID="btn_resultado" runat="server" CssClass="texto" Enabled="False"
                                        Text="Resultados" />
                                    &nbsp;<anthem:Button ID="btn_calcula" runat="server" CssClass="texto"
                                        Text="Calcular" />
                                    &nbsp; &nbsp;&nbsp;</TD>
	                        </TR>

                            <TR>
                                <TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif" colspan="4">
                                    &nbsp;&nbsp;Produtores e Propriedades selecionados:</TD>
                            </TR>
                            
							<TR  runat="server">
								<TD colSpan="4">&nbsp;
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_calculo_produtor">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="X-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True"
                                    SortExpression="ds_propriedade">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="X-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
								
                                    </TD>
							</TR>
						</TABLE>
						
						</TD>
					<TD style="height: 383px">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 922px"></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
