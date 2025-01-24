<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_interrupcao_fornec_resumo.aspx.vb" Inherits="frm_central_interrupcao_fornec_resumo" %>

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
		<title>Interrupção do Fornecimento de Leite - Resumo Financeiro</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Desligar Propriedade por Interrupção de Fornecimento de Leite - Resumo Financeiro Central</STRONG></TD>
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
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" align="center" valign="middle" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="98%" border="0" onclick="return Table2_onclick()">
                            <tr runat="server" id="tr_referencia">
                                <td align="right" style="width: 15%;" >
                                    Mês/Ano Desligamento:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_dt_referencia" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 20px">
                                    Nr Execução:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_id_execucao" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="width: 12%;">
                                    Produtor:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_produtor" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 12%;">
                                    Propriedade:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_propriedade_up" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                               <td align="right" style="height: 22px">
                                    Propriedade Matriz:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_id_propriedade_matriz" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                  <td align="right" style="height: 22px">
                                    Técnico:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_tecnico" runat="server" CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                          </tr>
                            <tr>
                                <td align="right" style="width: 12%;" >
                                    Total Pagto Fornec.:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_total_pagto_fornecedor" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 20px">
                                    Pagto Exportação:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_total_pagto_exportacao" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" >
                                    Pagto pelo Produtor:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_total_pagto_produtor" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>

                            </tr>
                            <tr>
                                <td align="right" style="width: 12%;" >
                                    Total Desc. Prod.:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_total_desconto_produtor" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 20px">
                                    Desc. Cálculo:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_total_desconto_calculo" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" >
                                    Desc. Depósito:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_total_desconto_deposito" runat="server" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>

                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;Pagamentos aos Parceiros</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 2px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 2px;">&nbsp;</TD>
					<TD style="height: 2px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD align="center" class="texto" >
									
                        <anthem:GridView ID="gridPagtoFornec" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20"><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Parceiro" DataField="cd_fornecedor" ReadOnly="True" SortExpression="cd_fornecedor" Visible="False" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Parceiro" DataField="nm_abreviado_fornecedor" ReadOnly="True" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="N.Fiscal" DataFormatString="{0:N0}" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_serie_nota_fiscal" HeaderText="Serie" Visible="False" />
                                <asp:BoundField DataField="nr_valor_nota_fiscal" HeaderText="Valor Total" DataFormatString="{0:N2}" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pagto" HeaderText="Dt.Pagto" DataFormatString="{0:dd/MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_parcela" HeaderText="Parc." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parc." DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Efetivado">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Image id="img_efetivado" runat="server" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w93"></asp:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pagto">
                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_pagto" runat="server" __designer:wfdid="w61" Text='<%# bind("st_tipo_pagto") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acerto">
                                    <itemtemplate>
<asp:Label id="lbl_acerto" runat="server" __designer:wfdid="w94" Text='<%# Bind("dt_acerto", "{0:dd/MM/yyyy}") %>'></asp:Label>&nbsp;<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w95" CommandName="editar" CommandArgument='<%# bind("id_central_pedido_pagto_fornecedor") %>' Visible="False"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="efetivado" Visible="False">
                                    <edititemtemplate>
<asp:Label id="efetivado" runat="server" __designer:wfdid="w58" Text='<%# Bind("efetivado") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="efetivado" runat="server" __designer:wfdid="w57" Text='<%# Bind("efetivado") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_tipo_pagto" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_tipo_pagto" runat="server" __designer:wfdid="w56" Text='<%# Bind("st_tipo_pagto") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" class="texto">
                        <table class="texto" width="100%">
                            <tr>
                                <td align="right" style="font-weight: bold; height: 18px">
                                    Total Pagamentos Efetivados:</td>
                                <td style="width: 15%;">
                                    <anthem:Label ID="lbl_total_pagto_fornec_efetivado" runat="server"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold">
                                    Total Pagamentos:</td>
                                <td style="width: 15%">
                                    <anthem:Label ID="lbl_total_pagto_fornec" runat="server"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 24px; width: 9px;">
                        &nbsp;</td>
                    <TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
                        &nbsp;&nbsp; &nbsp; &nbsp;Descontos ao Produtor</td>
                    <TD style="HEIGHT: 24px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="height: 2px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 2px;">
                        &nbsp;</td>
                    <TD style="height: 2px;">
                    </td>
                </tr>
                <tr>
                    <TD style="width: 9px; ">
                        &nbsp;</td>
                    <TD align="center" class="texto" >
                        <anthem:GridView ID="gridDescProdutor" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Parceiro" DataField="cd_fornecedor" ReadOnly="True" SortExpression="cd_fornecedor" Visible="False" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Parceiro" DataField="nm_abreviado_fornecedor" ReadOnly="True" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="N.Fiscal" DataFormatString="{0:N}" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nota_fiscal" HeaderText="Valor Total" DataFormatString="{0:N2}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pagto" HeaderText="Dt.Pagto" DataFormatString="{0:d}" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_parcela" HeaderText="Parc." >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parc." DataFormatString="{0:N2}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Efetivado">
                                    <edititemtemplate>
<asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Image id="img_efetivado" runat="server" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w90"></asp:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pagto">
                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_desconto" runat="server" Text='<%# bind("st_tipo_desconto") %>' __designer:wfdid="w176"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acerto">
                                    <itemtemplate>
<asp:Label id="lbl_acerto" runat="server" __designer:wfdid="w91" Text='<%# bind("dt_acerto", "{0:dd/MM/yyyy}") %>'></asp:Label> <anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w89" CommandName="editar" CommandArgument='<%# bind("id_central_pedido_desconto_produtor") %>' Visible="False"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="efetivado" Visible="False">
                                    <edititemtemplate>
<asp:Label id="efetivado" runat="server" __designer:wfdid="w25" Text='<%# Bind("efetivado") %>'></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="efetivado" runat="server" __designer:wfdid="w23" Text='<%# Bind("efetivado") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_tipo_desconto" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_tipo_desconto" runat="server" __designer:wfdid="w10" Text='<%# Bind("st_tipo_desconto") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                    </td>
                    <TD >
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" class="texto">
                        <table class="texto" width="100%">
                            <tr>
                                <td align="right" style="font-weight: bold; height: 18px">
                                    Total Descontos Efetivados:</td>
                                <td style="width: 15%; height: 18px">
                                    <anthem:Label ID="lbl_total_desc_prod_efetivado" runat="server"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="font-weight: bold">
                                    Total Descontos:</td>
                                <td style="width: 15%; height: 18px;">
                                    <anthem:Label ID="lbl_total_desc_prod" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 9px; height: 2px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 2px" valign="middle">
                        <table class="texto" width="100%">
                            <tr>
                                <td style="width: 25%">
                        <asp:Image ID="Image1" runat="server" ImageUrl="img/voltar.gif" />
                        <asp:LinkButton ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton></td>
                                <td align="right" style="font-weight: bold">
                                    Saldo a Pagar/Receber:</td>
                                <td style="width: 15%">
                                    <anthem:Label ID="lbl_saldo" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
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
		</form>
	</body>
</HTML>
