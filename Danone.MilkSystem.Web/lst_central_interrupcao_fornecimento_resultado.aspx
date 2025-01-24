<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_interrupcao_fornecimento_resultado.aspx.vb" Inherits="lst_central_interrupcao_fornecimento_resultado" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc5" %>

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
		<title>Interrupção do Fornecimento de Leite - Resultado</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Desligar Produtor por Interrupção de Fornecimento de Leite - Resultados</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" align="center">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="right" style="width: 20%;" >
                                    Mês/Ano Desligamento:</td>
                                <td style="height: 20px" colspan="2">
                                    &nbsp;<anthem:Label ID="lbl_dt_referencia" runat="server"></anthem:Label></td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;">
                                    Código Produtor:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_produtor" runat="server"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;">
                                    Nr Execução:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_id_execucao" runat="server"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 4px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 4px;">&nbsp;</TD>
					<TD style="height: 4px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px;" class="texto">&nbsp;</TD>
					<TD align="center" class="texto" >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20" DataKeyNames="id_central_interrupcao_fornecimento">
                            <Columns>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" ReadOnly="True" />
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" SortExpression="ds_propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Resultado">
                                    <itemtemplate>
&nbsp;<anthem:HyperLink id="hl_resultado" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nm_central_interrupcao_resultado") %>' __designer:wfdid="w10"></anthem:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_central_interrupcao_resultado" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_central_interrupcao_resultado" runat="server" Text='<%# Bind("id_central_interrupcao_resultado") %>' __designer:wfdid="w13"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_central_interrupcao_resultado" runat="server" Text='<%# Bind("id_central_interrupcao_resultado") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" /><PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                        </anthem:GridView>
                        </TD>
					<TD class="texto" >&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px; height: 2px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 2px" valign="middle">
                        <asp:Image ID="Image1" runat="server" ImageUrl="img/voltar.gif" />
                        <asp:LinkButton ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton></td>
                    <td style="height: 2px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        </TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>&nbsp;
                	    <div visible="false">
                            &nbsp;&nbsp;
        </div>
		&nbsp;
		&nbsp;
		</form>
	</body>
</HTML>
