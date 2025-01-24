<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_qualidade_web.aspx.vb" Inherits="frm_relatorio_qualidade_web" %>

    
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
                        EXTRATO MENSAL DO PRODUTOR</td>
                     <td width="10%" align="center" class="texto" >
                         <asp:Label ID="lbl_dtatual" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
               </tr>
                <tr>
                    <td align="center" class="texto" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">
                       <asp:Label ID="lbl_dtreferencia" runat="server" CssClass="textosmall" Font-Italic="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
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
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
               </table>
               
               <table class="texto" width="100%">
               <tr>
                   <td align="center" class="texto"  style="height: 13px; width: 38%">
                        MOVIMENTO DE LEITE</td>
                     <td align="center" class="texto" style="height: 13px; width: 2%">
                        &nbsp;</td>
                    <td align="center" class="texto" style="height: 13px; width: 60%">
                        ANÁLISE DE LEITE</td>
              </tr>
                <tr>
                    <td align="center" valign="top" class="texto" style="width: 38%">
                        <anthem:GridView ID="gridMovimento" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" GridLines="Horizontal" PageSize="14" UpdateAfterCallBack="True"
                            Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="#B5C7DE" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#F7F7F7" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#E7E7FF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#4A3C8C"
                                HorizontalAlign="Right" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="dt_movimento" HeaderText="Data Movimento" />
                                <asp:BoundField DataField="nr_volume" HeaderText="Litros" DataFormatString="{0:N0}" />
                                <asp:BoundField DataField="rejeicao_antibiotico" HeaderText="Rejei&#231;&#227;o" />
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w1"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <RowStyle BackColor="#E7E7FF" HorizontalAlign="Center" ForeColor="#4A3C8C" />
                        </anthem:GridView>
                        <asp:Label ID="lbl_volumenaopago" runat="server" CssClass="texto" Visible="False" >*Volume entregue após o fechamento para pagamento no próximo mês</asp:Label>
                    </td>
                     <td align="center" class="texto" style="width: 2%">
                        &nbsp;</td>
                     <td align="left" valign="top" class="texto" style="width: 60%">
                        <anthem:GridView ID="gridAnalise" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" GridLines="Horizontal" PageSize="14" UpdateAfterCallBack="True"
                            Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" BorderStyle="None">
                            <FooterStyle BackColor="#B5C7DE" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#F7F7F7" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#E7E7FF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#4A3C8C"
                                HorizontalAlign="Right" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:TemplateField HeaderText="Data">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("dt_analise") %>' __designer:wfdid="w5"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_dt_analise" runat="server" __designer:wfdid="w4" Text='<%# Bind("dt_analise") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MG">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w6" Text='<%# Bind("nr_valor_esalq") %>'></asp:TextBox> 
</edititemtemplate>
                                    <headertemplate>
<asp:Label id="lbl_MG_header" runat="server" __designer:wfdid="w7">MG</asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_MG" runat="server" __designer:wfdid="w5"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prot">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w9" Text='<%# Bind("nr_valor_esalq") %>'></asp:TextBox> 
</edititemtemplate>
                                    <headertemplate>
<asp:Label id="lbl_Prot_header" runat="server" __designer:wfdid="w10">Prot</asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_Prot" runat="server" __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CCS">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w12" Text='<%# Bind("nr_valor_esalq") %>'></asp:TextBox> 
</edititemtemplate>
                                    <headertemplate>
<asp:Label id="lbl_CCS_header" runat="server" __designer:wfdid="w13">CCS</asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_CCS" runat="server" __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CBT">
                                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w15" Text='<%# Bind("nr_valor_esalq") %>'></asp:TextBox> 
</edititemtemplate>
                                    <headertemplate>
<asp:Label id="lbl_CBT_header" runat="server" __designer:wfdid="w16">CBT</asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_CBT" runat="server" __designer:wfdid="w14"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_unid_producao" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_unid_producao" runat="server" __designer:wfdid="w2" Text='<%# Bind("id_unid_producao") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <RowStyle BackColor="#E7E7FF" HorizontalAlign="Center" ForeColor="#4A3C8C" />
                        </anthem:GridView>
                         &nbsp;&nbsp;
                         <br />
                         <asp:Label ID="lbl_media_linear" runat="server" CssClass="texto" Visible="False">MG¹ e Prot¹- Média linear do mês vigente.</asp:Label><br />
                         <asp:Label ID="lbl_media_geometrica" runat="server" CssClass="texto" Visible="False">CCS² e CBT²- Média geométrica trimestral.</asp:Label></td>
                   
                </tr>
                   <tr>
                       <td align="center" class="texto" style="width: 38%" valign="top">
                       </td>
                       <td align="center" class="texto" style="width: 2%">
                       </td>
                       <td align="left" class="texto" style="width: 60%" valign="top">
                           &nbsp;<br />
                         </td>
                   </tr>
                <tr>
                   <td align="left" class="texto"  colspan="3" style="height: 13px; ">
                   
                        </td>

                </tr>
            </table>
            <table class="texto" width="100%">
               <tr>
                   <td align="center" class="texto"  colspan="3" style="height: 13px; ">
                        MOVIMENTO FINANCEIRO</td>
               </tr>
                <tr>
                    <td align="center" class="texto" valign="top">
                    <anthem:GridView ID="GridFinanceiro" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" GridLines="Horizontal" PageSize="14" UpdateAfterCallBack="True"
                            Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="#B5C7DE" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="#F7F7F7" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#E7E7FF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#4A3C8C"
                                HorizontalAlign="Right" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="Descri&#231;&#227;o">
                                <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nm_conta") %>' id="TextBox2"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_descricao" runat="server" Text='<%# Bind("nm_conta") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                                <headerstyle horizontalalign="Left" />
                                <itemstyle horizontalalign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qtde">
                                <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("qtde") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_qtde" runat="server" Text='<%# Bind("qtde") %>' __designer:wfdid="w1"></asp:Label>
</itemtemplate>
                                <headerstyle horizontalalign="Left" />
                                <itemstyle horizontalalign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Vl Unit." DataField="preco" >
                                <headerstyle horizontalalign="Left" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Vl. Total" DataField="total" DataFormatString="{0:c}" >
                                <headerstyle horizontalalign="Left" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
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