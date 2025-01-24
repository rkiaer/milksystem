<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_custo_financeiro_calculo_excel.aspx.vb" Inherits="frm_custo_financeiro_calculo_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo Financeiro Cálculo</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="70" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="ds_agrupamento" HeaderText="Grupo" ShowHeader="False">
                </asp:BoundField>
                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia"
                    ReadOnly="True" DataFormatString="{0:MMM/yyyy}">
                    <itemstyle wrap="True" horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="st_pagamento" HeaderText="C&#225;lculo" />
                <asp:BoundField DataField="produtorresp" HeaderText="Respons&#225;vel">
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="contrato" HeaderText="Contrato">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_cooperativa" HeaderText="Coop.">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop Matriz" />
                <asp:BoundField DataField="produtor" HeaderText="Produtor" />
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade">
                    <headerstyle wrap="True" />
                    <itemstyle wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_mes" DataFormatString="{0:N0}" HeaderText="Volume">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_preco" DataFormatString="{0:N4}" HeaderText="Pre&#231;o">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_qualidade" DataFormatString="{0:N4}" HeaderText="Qualidade" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_incentivo25" DataFormatString="{0:N4}" HeaderText="Incentivo 2.5%">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_incentivo24" DataFormatString="{0:N4}" HeaderText="Incentivo 2.4%">
                    <itemstyle font-bold="False" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_incentivo25_volume" DataFormatString="{0:N4}" HeaderText="Inc 2.5 x Vol">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_incentivo24_volume" DataFormatString="{0:N4}" HeaderText="Inc 2.4 x Vol">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_piscofins_volume" DataFormatString="{0:N4}" HeaderText="P&amp;C x Vol">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_icms_volume" DataFormatString="{0:N4}" HeaderText="ICMS x Vol">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                 <asp:BoundField DataField="nr_frete" DataFormatString="{0:N4}" HeaderText="Frete">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
               <asp:BoundField DataField="volumecoletado" DataFormatString="{0:N0}" HeaderText="Volume Coletado" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_incentivo" DataFormatString="{0:N0}" HeaderText="Volume Incentivo 2.5">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_sem_incentivo" DataFormatString="{0:N0}" HeaderText="Volume Sem Incentivo">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_sazonal" DataFormatString="{0:N4}" HeaderText="Sazonalidade">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_destino"  HeaderText="Prop Destino">
                    <itemstyle horizontalalign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_mensal_inicial" DataFormatString="{0:N0}" HeaderText="Volume Ini M&#234;s">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_transferido" DataFormatString="{0:N0}" HeaderText="Volume Transferido">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_origem"  HeaderText="Prop Origem">
                    <itemstyle horizontalalign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_mensal_origem" DataFormatString="{0:N0}" HeaderText="Volume M&#234;s Origem">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_adicional_volume" HeaderText="Adicional Volume">
                    <itemstyle horizontalalign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_indicador" DataFormatString="{0:N4}" HeaderText="Indicador" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_indicador_calculado" DataFormatString="{0:N4}" HeaderText="Indicador Calculado">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade_grupo_volume"  HeaderText="Propriedade Grupo Compartilha Vol">
                    <itemstyle horizontalalign="Center"  />
                </asp:BoundField>
                       <asp:BoundField DataField="nr_volume_mes_tabela_calculo" DataFormatString="{0:N0}" HeaderText="Volume Grupo Tabela">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                 <asp:BoundField DataField="nr_volume_produtor_clustercpm" DataFormatString="{0:N0}" HeaderText="Total Vol. CPM" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                  <asp:BoundField DataField="nr_volume_produtor_clustergerencial" DataFormatString="{0:N0}" HeaderText="Total Vol. Nego Gerencial" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                 <asp:BoundField DataField="nr_volume_produtor_contrato" DataFormatString="{0:N0}" HeaderText="Total Vol. Contrato" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                  <asp:BoundField DataField="nr_volume_produtor_mercado" DataFormatString="{0:N0}" HeaderText="Total Vol. Mercado" ReadOnly="True">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>               
                <asp:BoundField DataField="nr_volume_coop_contrato" DataFormatString="{0:N0}" HeaderText="Total Vol. Coop Contrato">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_coop_spot" DataFormatString="{0:N0}" HeaderText="Total Vol. Coop SPOT">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_necessidade_producao" DataFormatString="{0:N0}" HeaderText="Vol Necessidade Produ&#231;&#227;o">
                    <itemstyle horizontalalign="Right"  />
                </asp:BoundField>
       
            </Columns>
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        &nbsp;<br />
        &nbsp; &nbsp;

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
