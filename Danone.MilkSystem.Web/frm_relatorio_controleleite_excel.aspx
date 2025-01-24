<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_controleleite_excel.aspx.vb" Inherits="frm_relatorio_controleleite_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
           <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_compartimento">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="N.o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Rota" DataField="rota" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." >
                                    <headerstyle width="5%" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Chegada" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_fim_descarga" HeaderText="Hr Desc" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_ini_CIP" HeaderText="Hr CIP" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_ph_solucao" HeaderText="PH FIM" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="peso_liquido_balanca" HeaderText="Peso Balan&#231;a" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Dens (g/ml)" DataField="nr_valor_dens" DataFormatString="{0:n4}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pesoemlitros" DataFormatString="{0:n0}" HeaderText="Volume (lts)">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_mg" DataFormatString="{0:n2}" HeaderText="MG(%)">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume Caderneta (lts)" DataField="nr_litros_compartimento" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-Cader (lts)" DataField="nr_variacao_volume" DataFormatString="{0:n0}" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_nr_silo" HeaderText="Destino Leite Cru" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada" HeaderText="Dt.Entrada" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_divergencia_km_frete" HeaderText="Diverg&#234;ncias" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_aprovacao_km_frete" HeaderText="Aprova&#231;&#227;o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_batch" HeaderText="Batch">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_analise_compartimento" HeaderText="Sit.Comp">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_destino_leite_rejeitado" HeaderText="Dest Rejeitado">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                          <anthem:GridView ID="gridResultsRom" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True"  HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="N.o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa Princ." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Rota" DataField="rota" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada" HeaderText="Entrada" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Chegada" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_fim_descarga" HeaderText="Hr Desc" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_ini_CIP" HeaderText="Hr CIP" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_ph_solucao" HeaderText="PH FIM" >
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso Balan&#231;a" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Dens (g/ml)" DataField="nr_valor_dens" DataFormatString="{0:n4}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pesoemlitros" DataFormatString="{0:n0}" HeaderText="Volume (lts)">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume Cad./NF (lts)" DataField="nr_litros_compartimento" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-Cad./NF (lts)" DataField="nr_variacao_volume" DataFormatString="{0:n0}" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_nr_silo" HeaderText="Destino Leite Cru Silo" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_batch" HeaderText="Batch">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="volumerejeitado" DataFormatString="{0:n0}" HeaderText="Vol. Rejeitado" />
                                <asp:BoundField DataField="ds_destino_leite_rejeitado" HeaderText="Dest Rejeitado">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_divergencia_km_frete" HeaderText="Diverg&#234;ncias" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_aprovacao_km_frete" HeaderText="Aprova&#231;&#227;o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cod. Milk Transp.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap_transportador" HeaderText="Cod. SAP Transp.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_variacao_transportador" DataFormatString="{0:n0}" HeaderText="Varia&#231;&#227;o 0,2% (lts)" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataFormatString="{0:n0}" HeaderText="Desconto Transportador" DataField="valordescontotransportador" />
                                <asp:TemplateField HeaderText="id_cooperativa" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_cooperativa" runat="server" Text='<%# Bind("id_cooperativa") %>' __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
      &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
