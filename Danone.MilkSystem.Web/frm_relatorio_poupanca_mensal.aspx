<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_poupanca_mensal.aspx.vb" Inherits="frm_relatorio_poupanca_mensal" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
   <title>Relatório Extrato de Poupança Mensal</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; vertical-align: middle; ">
            <table class="texto" width="98%" style="border-bottom: gray 1px solid">
                <tr>
                    <td width="10%" rowspan="3">
                        <img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" style="font-weight: bold; font-size: small;
                        font-variant: small-caps" colspan="2">
                        </td>
                    <td width="10%" align="center" class="texto" rowspan="3" valign="middle" >
                        <img  src="img/logo_poupanca.gif" height="50"/></td>
                </tr>
                <tr>
                    <td align="center" class="texto" style="font-weight: bold; font-size: small;
                        font-variant: small-caps" colspan="2">
                        EXTRATO POUPANÇA MENSAL DO PRODUTOR</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2">
                        </td>
                </tr>
                <tr>
                    <td align="left" class="texto" colspan="2" style="width: 50%">
                        &nbsp;</td>
                    <td align="right" class="textomenor" colspan="2" style="width: 50%">
                        &nbsp;Programa Poupança do Leite Produtor</td>
                </tr>
                <tr>
                    <td align="left" class="textomenor" colspan="2">
                        <asp:Label ID="lbl_dtatual" runat="server" CssClass="textomenor" Font-Italic="True"></asp:Label></td>
                     <td align="right" class="textomenor" colspan="2" >
                         DAL - Departamento de Aprovisionamento do Leite</td>
                </tr>
               </table>
            <br />
            <table class="texto" width="98%" style="border-bottom: gray 1px solid">
                <tr>
                    <td align="left" class="textosmall" >
                        Sr. Produtor.</td>
                </tr>
                <tr>
                    <td align="left" class="textosmall" >
                        Este é seu extrato de Participação no Programa Poupança do Leite Produtor
                        <asp:Label ID="lbl_ano" runat="server" CssClass="textosmall" Font-Italic="False">2016</asp:Label>
                        - Danone.</td>
                </tr>
                <tr>
                   <td align="left" class="textosmall"  >
                       É um extrato para simples conferência e acompanhamento de seu saldo acumulado.</td>
                </tr>
            </table>
            <br />
               
               <table class="texto" width="98%">
                <tr>
                   <td align="right" class="textomenor"  style="height: 13px; width: 12%; font-size: 8px;" valign="bottom">
                       Cód. Produtor:</td>

                    <td align="left" class="textosmall" style="height: 13px; font-weight: bold;">
                        <asp:Label ID="lbl_cd_produtor" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                   <tr>
                       <td align="right" class="textomenor" style="font-size: 8px; height: 13px" valign="bottom">
                           Cód. Propriedade:</td>
                       <td align="left" class="textosmall" style="font-weight: bold; height: 13px">
                       <asp:Label ID="lbl_dspropriedade" runat="server" ></asp:Label></td>
                   </tr>
                   <tr>
                       <td align="right" class="textomenor" style="font-size: 8px; height: 13px" valign="bottom">
                           &nbsp;Produtor:</td>
                       <td align="left" class="textosmall" style="font-weight: bold; height: 13px">
                           <asp:Label ID="lbl_nm_produtor" runat="server"></asp:Label></td>
                   </tr>
            </table>
            <br />
            <table class="texto" width="98%" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid">
               <tr>
                   <td align="center" class="textosmall"  colspan="3" style="height: 13px; font-weight: bold;">
                       Média dos Resultados</td>
               </tr>
                <tr>
                    <td align="center" class="textosmall" valign="top">
                        <anthem:GridView ID="gridbonus" runat="server" AutoGenerateColumns="False" BackColor="White"
                            CellPadding="4" ForeColor="Black" PageSize="3" UpdateAfterCallBack="True" Width="99%" CaptionAlign="Top">
                            <FooterStyle BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                            <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" BorderStyle="None" />
                            <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_mes_referencia" HeaderText="M&#234;s">
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_leite" HeaderText="Litragem">
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_cbt" HeaderText="CBT">
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_ccs" HeaderText="CCS" />
                                <asp:BoundField DataField="nr_proteina" HeaderText="Prote&#237;na" />
                                <asp:BoundField DataField="nr_mg" HeaderText="MG" />
                                <asp:BoundField HeaderText="Incidentes na Qualidade" DataField="ds_incidente" >
                                    <headerstyle width="5%" wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_bonus" HeaderText="B&#244;nus" />
                                <asp:BoundField DataField="ds_status" HeaderText="Status" />
                            </Columns>
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="White" />
                        </anthem:GridView>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <table class="textosmall" width="98%" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid; font-weight: bold; font-style: italic;">
                <tr>
                    <td align="right"   style="height: 13px; font-weight: bold;">
                        Litragrem:</td>
                       <td align="center">
                           <asp:Label ID="lbl_total_volume" runat="server"></asp:Label></td>
                       <td align="right">
                           Total de Bônus Acumulativo:</td>
                       <td align="right">
                           <asp:Label ID="lbl_total_bonus" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_gastomedio" visible="false">
                    <td align="right" valign="top" style="height: 13px" colspan="3">
                        &nbsp;&nbsp; Gasto médio acumulado na central de compras de Outubro/2015 à Setembro/2016:</td>
                       <td align="right" valign="bottom">
                           <asp:Label ID="lbl_nr_compras_central" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_bonusacumulado" visible="false">
                    <td align="right" colspan="3" style="height: 13px" valign="top">
                        Bônus Acumulativo + 15% SE gasto na Central de Compras médio for maior R$0,25/L:</td>
                    <td align="right" valign="bottom">
                        <asp:Label ID="lbl_bonus_adicional_spend" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
            <table class="texto" width="98%">
                <tr>
                    <td align="center"  colspan="3" style="font-weight: bold; font-size: small; font-variant: small-caps;">
                        ATENÇÃO AOS COMUNICADOS ABAIXO:</td>
                </tr>
            </table>
            <br />
            <table runat="server" id="tb_obs1" class="texto" width="98%" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid" >
                <tr>
                    <td align="center" class="textosmall"  colspan="3" style="height: 13px; font-weight: bold;">
                        As regras, parâmetros e demais informações que regem o programa "Poupança Leite", constam no termo de compromisso do "Poupança Leite" do ano vigente.</td>
                </tr>
            </table>
            <table   runat="server" id="tb_obs2" class="texto" width="98%" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid" visible="false">
                <tr>
                    <td align="center" class="textosmall"  colspan="3" style="height: 13px; font-weight: bold;">
                        Devido a alteração da Instrução Normativa nº 62 (Ministério da Agricultura, Pecuária
                        e Abastecimento), que aumentará o rigor do limite de CBT e CCS em julho 2016 para
                        100.000 UFC/mL e 400.000 cél/mL respectivamente, o programa Poupança Leite cumprirá
                        esta exigencia e a partir de 1º de julho a especificação será: CCS &lt;= 400.000
                        cél/mL. Os demais parâmetros permanenecerão sem alteração: CBT &lt;= 100.000 ufc/mL,
                        Proteína &gt;= 3,12% e isento de qualquer incidente na qualidade do leite (antibiótico,
                        crioscopia, alizarol, etc).</td>
                </tr>
            </table>
            <table runat="server" id="tb_obs3" class="texto" width="98%" style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px solid">
                <tr>
                    <td align="center" class="textosmall"  colspan="3" style="height: 13px; font-weight: bold;">
                        Prezado Produtor, para garantir o recebimento do bônus deste programa o termo de
                        compromisso deve ter sido assinado e entregue à Danone. Dúvidas referentes ao assunto,
                        entrar em contato com Laura Soares (Laura.SOARES@danone.com).</td>
                </tr>
            </table>
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     <!--</div>-->
     </form>
	</body>
</HTML>