<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_extrato_anual_web.aspx.vb" Inherits="frm_relatorio_extrato_anual_web" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
   <title>Relatório Extrato Produtor Web</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        EXTRATO ANUAL DE FORNECIMENTO DE LEITE</td>
                     <td width="10%" align="center" class="texto" >
                         <asp:Label ID="lbl_dtatual" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
               </tr>
                <tr>
                    <td align="center" class="texto" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">
                       Ano Referência:<asp:Label ID="lbl_dtreferencia" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td align="center" class="texto" colspan="3">
                        <b>FONTE PAGADORA</b></td>
                </tr>
                <tr>
                    <td align="left" class="texto" colspan="2">
                        <b>Fonte Pagadora:</b> <asp:Label ID="lbl_fonte_pagadora" runat="server" CssClass="texto" ></asp:Label></td>
                     <td align="left" class="texto" >
                        </td>
                </tr>
                <tr>
                    <td align="left" class="texto" colspan="2">
                        <b>Endereço:</b> <asp:Label ID="lbl_endereco_fp" runat="server" CssClass="texto" ></asp:Label></td>
                      <td align="left" class="texto" >
                        <asp:Label ID="lbl_numero_fp" runat="server" CssClass="texto" Visible="False" ></asp:Label></td>
               </tr>
                <tr>
                    <td align="left" class="texto" colspan="2">
                        <b>Município:</b> <asp:Label ID="lbl_municipio_fp" runat="server" CssClass="texto" ></asp:Label></td>
                      <td align="left" class="texto" >
                        <asp:Label ID="lbl_estado_fp" runat="server" CssClass="texto" ></asp:Label></td>
              </tr>
              <tr>
                    <td align="left" class="texto" colspan="3">
                        <b>CPF / CNPJ:</b> <asp:Label ID="lbl_cpf_cnpj" runat="server" CssClass="texto" ></asp:Label></td>
               </tr>
              <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                
                
                
                <tr>
                    <td align="center" class="texto" colspan="3">
                        <b>BENEFICIÁRIO</b></td>
                </tr>
                <tr>
                    <td align="left" class="texto" colspan="2">
                        <b>Produtor:</b> <asp:Label ID="lbl_dsprodutor" runat="server" CssClass="texto" ></asp:Label></td>
                     <td align="left" class="texto" >
                        <asp:Label ID="lbl_dsrota" runat="server" CssClass="texto" ></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" class="texto" colspan="3">
                        <b>Propriedade:</b> <asp:Label ID="lbl_dspropriedade" runat="server" CssClass="texto" ></asp:Label></td>
               </tr>
                <tr>
                    <td align="left" class="texto" colspan="3">
                        <b>Endereço:</b> <asp:Label ID="lbl_endereco" runat="server" CssClass="texto" ></asp:Label></td>
               </tr>
                <tr>
                    <td align="left" class="texto" colspan="2">
                        <b>Município:</b> <asp:Label ID="lbl_municipio" runat="server" CssClass="texto" ></asp:Label></td>
                      <td align="left" class="texto" >
                        <asp:Label ID="lbl_estado" runat="server" CssClass="texto" ></asp:Label></td>
              </tr>
              <tr>
                    <td align="left" class="texto" colspan="3">
                        <b>Inscr. Estadual:</b> <asp:Label ID="lbl_inscricao_estadual" runat="server" CssClass="texto" ></asp:Label></td>
               </tr>
              <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
               </table>
               

            <table class="texto" width="100%">
                <tr>
                    <td align="center" class="texto" valign="top">
                    <anthem:GridView ID="GridFinanceiro" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" GridLines="Horizontal" PageSize="14" UpdateAfterCallBack="True"
                            Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" ShowFooter="True">
                        <FooterStyle BackColor="#B5C7DE" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#F7F7F7" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#E7E7FF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#4A3C8C"
                                HorizontalAlign="Right" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:BoundField DataField="mes" HeaderText="M&#234;s" />
                            <asp:TemplateField HeaderText="Litros">
                                <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("litros") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_litros" runat="server" Text='<%# Bind("litros") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                                <footerstyle horizontalalign="Center" />
                                <headerstyle horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rend. Bruto">
                                <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("rend_bruto") %>' __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_rendbruto" runat="server" Text='<%# Bind("rend_bruto", "{0:c}") %>' __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                <footerstyle horizontalalign="Center" />
                                <headerstyle horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FunRural">
                                <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("funrural") %>' __designer:wfdid="w12"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_funrural" runat="server" Text='<%# Bind("funrural", "{0:c}") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                                <footerstyle horizontalalign="Center" />
                                <headerstyle horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desconto">
                                <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("desconto") %>' __designer:wfdid="w14"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_desconto" runat="server" Text='<%# Bind("desconto", "{0:c}") %>' __designer:wfdid="w13"></asp:Label>
</itemtemplate>
                                <footerstyle horizontalalign="Center" />
                                <headerstyle horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor L&#237;quido">
                                <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("liquido") %>' __designer:wfdid="w16"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_valorliquido" runat="server" Text='<%# Bind("liquido", "{0:c}") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                                <footerstyle horizontalalign="Center" />
                                <headerstyle horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <RowStyle BackColor="#E7E7FF" HorizontalAlign="Center" ForeColor="#4A3C8C" />
                    </anthem:GridView>
                    </td>
                </tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     <!--</div>-->
     </form>
	</body>
</HTML>