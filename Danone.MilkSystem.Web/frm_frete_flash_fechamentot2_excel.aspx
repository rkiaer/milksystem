<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_flash_fechamentot2_excel.aspx.vb" Inherits="frm_frete_flash_fechamentot2_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Frete - Flash Fechamento T2</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
           <anthem:GridView id="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <Columns>
                                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="ds_referencia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transportador" >
                                    <headerstyle wrap="False" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_frete" HeaderText="Tipo Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Cooperativa" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_cooperativa" HeaderText="Cooperativa" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_eixo" HeaderText="Nr.Eixo" >
                                    <headerstyle wrap="True" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume M&#233;dio" DataField="volume_medio" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                     <itemstyle wrap="True" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="km_media" DataFormatString="{0:N0}" HeaderText="KM M&#233;dio">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_tarifa_custo_km" HeaderText="Tarifa KM" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume" HeaderText="Volume" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_qtde_viagens" HeaderText="Viagens" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Total" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_variavel" HeaderText="Custo Vari&#225;vel" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_valor_pedagio" HeaderText="Ped&#225;gio" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_valor_seguro_carga" HeaderText="SeguroCarga" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_total_custo_variavel" HeaderText="Total Custo Vari&#225;vel" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_tarifa_custo_fixo_dia" HeaderText="Tarifa C.Fixo Di&#225;rio" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_tarifa_custo_fixo_mes" HeaderText="Tarifa C.Fixo M&#234;s" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_veiculos_custo_mes" HeaderText="Nr.Ve&#237;culos C.Fixo M&#234;s" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_total_custo_fixo" HeaderText="Total C.Fixo" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_total_custo_rota_tipo" HeaderText="Total Custo Coop/TipoFrete/Placa" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_custo_extra_lancado" HeaderText="Custo Extra Lan&#231;ado" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="nr_desconto_lancado" HeaderText="Desconto Lan&#231;ado" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="ds_conta" HeaderText="Conta"  >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="nr_total_bruto" HeaderText="Total Bruto" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w84"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                               </Columns><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
               <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
               <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
               <RowStyle ForeColor="#000066" />
           </anthem:GridView>
        <anthem:GridView id="gridDivergencia" runat="server"
                            AutoGenerateColumns="False" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" HorizontalAlign="Center">
            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
            <Columns>
                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="ds_referencia" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transportador" >
                    <headerstyle wrap="False" horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_frete" HeaderText="Tipo Frete" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                <asp:BoundField DataField="id_transit_point" HeaderText="Transit Point" />
                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" />
                <asp:BoundField DataField="dt_hora_entrada" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Dt_Entrada" />
                <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Cooperativa" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_cooperativa" HeaderText="Cooperativa" />
                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_eixo" HeaderText="Nr.Eixo" >
                    <headerstyle wrap="True" horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume" HeaderText="Volume" DataFormatString="{0:N0}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" DataFormatString="{0:N0}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_km_frete_cooperativa" DataFormatString="{0:N0}" HeaderText="KM Coop." />
                <asp:BoundField DataField="nr_km_minima_t2" DataFormatString="{0:N0}" HeaderText="KM M&#237;nima" />
                <asp:BoundField DataField="nr_custo_km" HeaderText="Tarifa KM" DataFormatString="{0:N2}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_km_minima_t2" DataFormatString="{0:N2}" HeaderText="Tarifa KM M&#237;nima" />
                <asp:BoundField DataField="nr_custo_fixo_diaria" HeaderText="Tarifa C.Fixo Di&#225;rio" DataFormatString="{0:N2}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_custo_fixo_mes" HeaderText="Tarifa C.Fixo M&#234;s" DataFormatString="{0:N2}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_fixo_mes" HeaderText="TipoFixoMes" />
                <asp:BoundField DataField="nr_veiculos_fixo_mes" HeaderText="Nr.Ve&#237;culos C.Fixo M&#234;s" DataFormatString="{0:N0}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_perc_seguro_carga" HeaderText="%SeguroCarga" DataFormatString="{0:N4}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_seguro_carga" HeaderText="ValorSeguroCarga" DataFormatString="{0:N2}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_pedagio_eixo_cooperativa" HeaderText="ValorPed&#225;gioPorEixo" DataFormatString="{0:N2}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="dscalculo" HeaderText="TipoC&#225;lculo" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_preco_medio_leite" HeaderText="Pre&#231;o M&#233;dio Leite M-1" DataFormatString="{0:N4}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="dsnrdivergencia" HeaderText="Tem Diverg&#234;ncia?" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_cd_divergencia" HeaderText="CodDivergencia" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_divergencia" HeaderText="Divergencia" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" wrap="False" />
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        &nbsp;
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
