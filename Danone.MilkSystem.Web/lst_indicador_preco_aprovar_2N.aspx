<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_indicador_preco_aprovar_2N.aspx.vb" Inherits="lst_indicador_preco_aprovar_2N" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
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
		<title>Aprovar Indicador de Preço 2o Nível</title>
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


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Indicador de Preço 2.o Nível</STRONG></TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
                        <table id="Table3" cellpadding="0" cellspacing="0" class="borda" width="100%">
                            <tr>
                                <td align="right" style="height: 10px">
                                </td>
                                <td colspan="2" style="height: 10px">
                                </td>
                                <td align="right" class="texto" colspan="1" style="height: 10px">
                                </td>
                                <td colspan="1" style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 23px">
                                    &nbsp;Referência:</td>
                                <td colspan="2" style="width: 28%; height: 23px">
                                    &nbsp;&nbsp;<cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="caixatexto"
                                        DateMask="MonthYear" Width="79px"></cc3:OnlyDateTextBox></td>
                                <td align="right" class="texto" colspan="1" style="width: 12%; color: #333333; height: 23px">
                                    </td>
                                <td colspan="1" style="height: 23px">
                                    &nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="5">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
					    &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar </anthem:linkbutton>&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
					    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
					</TD>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;"></TD>
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px; width: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="texto" >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_indicador_preco" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<anthem:CheckBox id="ck_header" runat="server" AutoUpdateAfterCallBack="True" AutoPostBack="True" __designer:wfdid="w70" OnCheckedChanged="ck_header_CheckedChanged" AutoCallBack="True"></anthem:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" AutoPostBack="True" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w69"></anthem:CheckBox> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" />
                                                <asp:BoundField DataField="ds_indicador_tipo" HeaderText="Tipo Indicador" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Valor" DataField="nr_valor" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="id_indicador_preco" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_indicador_preco" runat="server" Text='<%# Bind("id_indicador_preco") %>' __designer:wfdid="w209"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_indicador_preco" runat="server" Text='<%# Bind("id_indicador_preco") %>' __designer:wfdid="w207"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#78A3E2" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; " class="texto">&nbsp; &nbsp;
					</TD>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;&nbsp;</div>
		</form>
	</body>
</HTML>
