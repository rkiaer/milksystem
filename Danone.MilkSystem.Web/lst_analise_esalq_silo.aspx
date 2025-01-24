<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_analise_esalq_silo.aspx.vb" Inherits="lst_analise_esalq_silo" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_conta_parcelada</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Dados Análises Externas Silo</STRONG></TD>
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
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%" colspan="2"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 25px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 25px; " colspan="2">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 25px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Coleta:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_ini" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_coleta_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 25px; ">
                                    Número Silo:</td>
								<td style="height: 25px; width: 30%;">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_nr_silo" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    &nbsp; &nbsp;&nbsp;
    	                        </td>
                                 <td align="right" colspan="2" style="height: 25px">
                                    Código Análise Esalq:</td>
								<TD style="height: 25px">&nbsp;&nbsp;<asp:DropDownList id="cbo_codigo_esalq" runat="server" CssClass="caixaTexto">
                                </asp:DropDownList></td>
 							</tr>
 							
                            <tr>
                                <td align="right" style="height: 25px; "></td>
                                <td style="height: 25px; " colspan="2">
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
 								<TD style="HEIGHT: 25px; " align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 25px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                           </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 28px">&nbsp;</TD>
								<TD align="right" style="height: 28px" colspan="2">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
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
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_analise_esalq_silo">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" SortExpression="ds_estabelecimento" />
                                <asp:BoundField DataField="nr_silo" HeaderText="Nr. Silo" SortExpression="nr_silo" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="dt_processamento" HeaderText="Data Processamento" SortExpression="dt_processamento" />
                                <asp:BoundField DataField="dt_analise" HeaderText="Data An&#225;lise" SortExpression="dt_analise" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" ReadOnly="True"
                                    SortExpression="ds_analise_esalq">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado da An&#225;lise"
                                    SortExpression="nr_valor_esalq" />
                                <asp:BoundField DataField="nm_st_analise" HeaderText="Status" />
                                <asp:TemplateField>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle width="6%" />
                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w10" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_analise_esalq_silo") %>' CommandName="delete" ImageUrl="~/img/icone_excluir.gif" ToolTip="Desativar"></anthem:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_situacao" runat="server" __designer:wfdid="w11" Text='<%# Bind("id_situacao") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
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
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
