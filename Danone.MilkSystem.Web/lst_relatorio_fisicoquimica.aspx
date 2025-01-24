<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_fisicoquimica.aspx.vb" Inherits="lst_relatorio_fisicoquimica" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
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
		<title>Relatório Análises Fisico-Quimicas</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Relatório de Análises Físico-Químicas do Leite 'in natura'</STRONG></TD>
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
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" Display="Dynamic">[!]</asp:CompareValidator></td>

                                <td align="right" style="height: 20px; color: #333333;">&nbsp;</td>
                                <td align="right" style="height: 20px">&nbsp;</td>
                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">
                                    Período:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_data" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    &nbsp;à&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Inicial para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_fim"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Final para continuar."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
								<TD align="right" style="height: 20px;"></TD>
								<TD align="right" style="height: 20px;"></TD>
 							</tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Nome
                                    Rota:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="texto" MaxLength="50"
                                        Width="100px"></anthem:TextBox>
                                    <cc4:OnlyNumbersTextBox ID="txt_cd_rota_ini" runat="server" CssClass="texto" Width="75px" Visible="False"></cc4:OnlyNumbersTextBox>&nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_cd_rota_fim" runat="server" CssClass="texto"
                                        Width="75px" Visible="False"></cc4:OnlyNumbersTextBox></td>
                                <TD align="right" style="height: 20px;">
                                </td>
                                <TD align="right" style="height: 20px;">
                                </td>
                            </tr>
 							
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" />&nbsp;
                                <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;
                                </TD>
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
					<TD >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_compartimento,id_romaneio_placa">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_analista" HeaderText="Analista" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                <asp:BoundField DataField="nm_linha_cooperativa" HeaderText="Rota/Coop." />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" ReadOnly="True" />
                                <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_dt_hora_entrada_completa" HeaderText="Cheg." />
                                <asp:BoundField HeaderText="LIT" />
                                <asp:BoundField HeaderText="LIB" />
                                <asp:BoundField HeaderText="LIM" />
                                <asp:BoundField HeaderText="CEA" />
                                <asp:BoundField DataField="dt_inicio_analise" HeaderText="An&#225;lise" />
                                <asp:BoundField HeaderText="Dens(g/l)" />
                                <asp:BoundField HeaderText="MG(%)" />
                                <asp:BoundField HeaderText="PROT(%)" />
                                <asp:BoundField HeaderText="EST(%)" />
                                <asp:BoundField HeaderText="ESD(%)" />
                                <asp:BoundField HeaderText="A.L&#225;tico" />
                                <asp:BoundField HeaderText="N.A." ReadOnly="True" />
                                <asp:BoundField HeaderText="Temp(oC)" />
                                <asp:BoundField HeaderText="Aliz78" />
                                <asp:BoundField HeaderText="Criosc." />
                                <asp:BoundField HeaderText="Snap" />
                                <asp:BoundField HeaderText="Charm" />
                                <asp:BoundField HeaderText="Redut &gt;=90mi" />
                                <asp:BoundField HeaderText="Peroxido" />
                                <asp:BoundField HeaderText="Fosfat." />
                                <asp:BoundField HeaderText="Cloreto" ReadOnly="True" />
                                <asp:BoundField HeaderText="Lacre" ReadOnly="True" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
