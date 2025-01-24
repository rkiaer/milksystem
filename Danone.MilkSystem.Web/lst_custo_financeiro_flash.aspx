<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_custo_financeiro_flash.aspx.vb" Inherits="lst_custo_financeiro_flash" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc5" %>

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
		<title>Custo Financeiro - Relatório</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Custo Financeiro - Relatório</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 23px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" align="center" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()" >
							<TR>
								<TD style="height: 3px; width: 15%" ></TD>
								<TD style="height: 3px; width: 35%"></TD>
								<TD style="height: 3px; width: 15%"></TD>
								<TD style="height: 3px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Ano Referência:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_ano" runat="server" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Width="72px" MaxLength="4"></cc4:OnlyNumbersTextBox>
                                    (aaaa)<anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txt_ano" CssClass="texto" ErrorMessage="Preencha o campo Ano para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator><anthem:RangeValidator
                                            ID="RangeValidator1" runat="server" ControlToValidate="txt_ano" CssClass="texto"
                                            ErrorMessage="O campo ANO deve ter 4 dígitos númericos." MaximumValue="3000"
                                            MinimumValue="2020" ToolTip="Ano deve ter 4 dígitos numéricos a partir de 2020."
                                            Type="Integer" ValidationGroup="gv_estabel">[!]</anthem:RangeValidator><asp:CustomValidator
                                                ID="cv_custo" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                                ValidationGroup="gv_estabel">[!] </asp:CustomValidator></td>
                                <td align="left" style="height: 20px" colspan="2">
                                    Nr Execução Cálculo <span>Projetado</span>:
                                    
                                        <anthem:Label ID="lbl_execucao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                       
                            </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 28px">
                                    </td>
								<TD align="left" colspan="2" style="height: 28px"></TD>
								<TD align="left" style="height: 28px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="1" style="height: 2px">
                                </td>
                                <td align="left" colspan="2" style="height: 2px">
                                </td>
                                <td align="right" style="height: 2px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 26px; font-size: xx-small;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;Data Execução do Último Cálculo Projetado:
                        <anthem:Label ID="lbl_calculoprojetado" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label></TD>
					<TD style="HEIGHT: 26px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 2px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 2px; ">
                       </td>
                    <TD style="height: 2px; width: 10px;">
                    </td>
                </tr>
				<TR  >
					<TD style="width: 9px;"></TD>
					<TD>
                        <anthem:GridView ID="gridVolume" runat="server"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Verdana"
                            Font-Size="XX-Small" PageSize="50" UpdateAfterCallBack="True" Visible="False"
                            Width="100%">
                            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                HorizontalAlign="Left" />
                            <Columns>
<asp:BoundField DataField="ds_descricao" HeaderText="Volumes por Cluster" ReadOnly="True">
    <itemstyle width="20%" />

</asp:BoundField>
<asp:BoundField DataField="mes1" DataFormatString="{0:N0}" HeaderText="JAN">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes2" DataFormatString="{0:N0}" HeaderText="FEV">
<HeaderStyle Wrap="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes3" DataFormatString="{0:N0}" HeaderText="MAR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes4" DataFormatString="{0:N0}" HeaderText="ABR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes5" DataFormatString="{0:N0}" HeaderText="MAI" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes6" DataFormatString="{0:N0}" HeaderText="JUN">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes7" DataFormatString="{0:N0}" HeaderText="JUL">
<ItemStyle HorizontalAlign="Right" Font-Bold="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes8" DataFormatString="{0:N0}" HeaderText="AGO">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes9" DataFormatString="{0:N0}" HeaderText="SET">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes10" DataFormatString="{0:N0}" HeaderText="OUT" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes11" DataFormatString="{0:N0}" HeaderText="NOV">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes12" DataFormatString="{0:N0}" HeaderText="DEZ">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_total" DataFormatString="{0:N0}" HeaderText="Total" Visible="False">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("Seq") %>' __designer:wfdid="w47"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                         <anthem:GridView
                                ID="gridResults" runat="server" AutoGenerateColumns="False"
                                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="70"
                                UpdateAfterCallBack="True" Width="100%">
                                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                    ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                    HorizontalAlign="Left" />
                                <Columns>
<asp:BoundField DataField="ds_cluster" HeaderText="cluster" ShowHeader="False">
<ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ds_descricao" HeaderText="Composi&#231;&#227;o do Pre&#231;o" ReadOnly="True">
<ItemStyle Wrap="True" Width="11%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes1" DataFormatString="{0:N4}" HeaderText="JAN">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes2" DataFormatString="{0:N4}" HeaderText="FEV">
<HeaderStyle Wrap="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes3" DataFormatString="{0:N4}" HeaderText="MAR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes4" DataFormatString="{0:N4}" HeaderText="ABR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes5" DataFormatString="{0:N4}" HeaderText="MAI" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes6" DataFormatString="{0:N4}" HeaderText="JUN">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes7" DataFormatString="{0:N4}" HeaderText="JUL">
<ItemStyle HorizontalAlign="Right" Font-Bold="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes8" DataFormatString="{0:N4}" HeaderText="AGO">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes9" DataFormatString="{0:N4}" HeaderText="SET">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes10" DataFormatString="{0:N4}" HeaderText="OUT" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes11" DataFormatString="{0:N4}" HeaderText="NOV">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes12" DataFormatString="{0:N4}" HeaderText="DEZ">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataFormatString="{0:N0}" HeaderText="Total" Visible="False">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="seq" ShowHeader="False" Visible="False"><ItemTemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                                </Columns>
                                <RowStyle ForeColor="#000066"></RowStyle>

                            </anthem:GridView>
                        <br />
                        <anthem:GridView ID="gridOutrosCustos" runat="server" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="50"
                            UpdateAfterCallBack="True" Width="100%">
                            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                HorizontalAlign="Left" />
                            <Columns>
<asp:BoundField DataField="ds_descricao" HeaderText="Outros Custos" ReadOnly="True">
<HeaderStyle Font-Bold="True" font-size="X-Small" ></HeaderStyle>

<ItemStyle Wrap="True" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes1" DataFormatString="{0:N4}" HeaderText="JAN">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes2" DataFormatString="{0:N4}" HeaderText="FEV">
<HeaderStyle Wrap="True"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes3" DataFormatString="{0:N4}" HeaderText="MAR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes4" DataFormatString="{0:N4}" HeaderText="ABR">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes5" DataFormatString="{0:N4}" HeaderText="MAI" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes6" DataFormatString="{0:N4}" HeaderText="JUN">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes7" DataFormatString="{0:N4}" HeaderText="JUL">
<ItemStyle HorizontalAlign="Right" Font-Bold="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes8" DataFormatString="{0:N4}" HeaderText="AGO">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes9" DataFormatString="{0:N4}" HeaderText="SET">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes10" DataFormatString="{0:N4}" HeaderText="OUT" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes11" DataFormatString="{0:N4}" HeaderText="NOV">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="mes12" DataFormatString="{0:N4}" HeaderText="DEZ">
<ItemStyle HorizontalAlign="Right" Wrap="False"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                    </TD>
					<TD style="width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD vAlign="top" align="center"  >
                        &nbsp;</TD>
					<TD style=" width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;&nbsp;
        </div>
		</form>
	</body>
</HTML>
