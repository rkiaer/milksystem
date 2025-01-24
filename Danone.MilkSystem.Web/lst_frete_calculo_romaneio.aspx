<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_calculo_romaneio.aspx.vb" Inherits="lst_frete_calculo_romaneio" %>

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
		<title>Poupança - Cálculo Mensal</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>
<script type="text/javascript"> 

</script>
	<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Cálculo de Frete </STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
                            <tr>
                                <td align="right" style="height: 22px; width: 20%;" width="20%">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
                                <td class="texto" align="right">
                                    &nbsp;<strong><span style="color: #ff0000"></span></strong></td>
                                <td align="left" class="texto" style="width: 50%" >
                                    <strong><span style="color: #ff0000">*</span></strong>Referência:&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="caixaTexto" DateMask="MonthYear"
                                        Width="75px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 28px;">
                                    <strong><span style="color: #ff0000">*</span></strong>Tipo de Frete:</td>
                                <td align="left" style="height: 28px">
                                    &nbsp;<anthem:DropDownList ID="cbo_tipofrete" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">T1</asp:ListItem>
                                        <asp:ListItem Value="2">T2 COOP</asp:ListItem>
                                        <asp:ListItem Value="3">T2 TP e TVASE</asp:ListItem>
                                        <asp:ListItem Value="4" Enabled="False">T2 TVASE</asp:ListItem>
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cbo_tipofrete"
                                        CssClass="texto" ErrorMessage="Preencha o campo Tipo Frete para continuar." Font-Bold="False"
                                        ToolTip="O TipoFrete deve ser informado." ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 28px">
                                    </td>
                                <td align="left" style="height: 28px">
                                    &nbsp;<anthem:CheckBox ID="chk_calculo_definitivo" runat="server" CssClass="texto"
                                        Text="Calculo Definitivo " /></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%">
                                </td>
                                <td align="left" style="height: 22px">
                                </td>
                                <td align="left" style="height: 22px">
                                </td>
                                <td align="center" style="height: 20px">
                                    <anthem:Label ID="Label1" runat="server" CssClass="texto" ForeColor="Red" Width="80%">ATENÇÃO: Se a opção "Cálculo Definitivo" estiver ligada, os dados serão efetivados e não poderão mais ser recalculados.</anthem:Label></td>
                            </tr>
							<tr>
			                    <td align="right" style="width: 20%; height: 28px"></td>
			                    <td align="right" style="height: 28px"></td>
								<TD style="height: 28px">&nbsp;</TD>
								<TD align="right" style="height: 28px" valign="bottom">
                                    &nbsp;&nbsp;<anthem:CustomValidator ID="cv_calculo" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Bold="False" Font-Italic="False" ForeColor="White" Text="[!]"
                                        ValidationGroup="vg_pesquisar"></anthem:CustomValidator>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="~/img/bnt_calcular.gif" ValidationGroup="vg_pesquisar" ToolTip="Calcular Frete"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;" class="texto">
                        &nbsp;<br />
                        Cálculo Frete Execução:
                        <anthem:Label ID="lbl_id_frete_calculo_execucao" runat="server" CssClass="Texto"
                            Height="16px" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True"></anthem:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Preço Médio Leite M-1:
                        <anthem:Label ID="lbl_preco_medio" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                            Height="16px" UpdateAfterCallBack="True"></anthem:Label><br />
                    </td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				<tr>
					<TD style="height: 19px; width: 9px;"></TD>
				    <td vAlign="baseline" style="height: 19px" class="texto">
                            <table border="0" cellpadding="0" cellspacing="0" class="texto" style="margin-bottom: 0px;
                                padding-bottom: 0px; vertical-align: text-bottom; height: 8px; text-align: left">
                                <tr>
                                    <td id="td_resultados" runat="server" align="left" class="texto" style="font-size: 1px;
                                        vertical-align: text-bottom; height: 6px">
                                        <anthem:Panel ID="pnl_resultados" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_ativa.gif"
                                            CssClass="texto" ForeColor="#0000F5" Height="23px" HorizontalAlign="Center" Width="135px">
                                            <anthem:LinkButton ID="btn_resultados" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" ForeColor="#0000F5" ValidationGroup="vg_pesquisar">Resultados</anthem:LinkButton></anthem:Panel>
                                        &nbsp; &nbsp; &nbsp;</td>
                                    <td id="td_romaneios" runat="server" align="left" style="font-size: 1px; vertical-align: text-bottom;
                                        height: 6px">
                                        <anthem:Panel ID="pnl_romaneios" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa_grande.gif"
                                            CssClass="texto" Height="23px" HorizontalAlign="Center" Visible="true" Width="206px">
                                            <anthem:LinkButton ID="btn_romaneios" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" ForeColor="#6767CC" ValidationGroup="vg_pesquisar">Romaneios/Divergências</anthem:LinkButton></anthem:Panel>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
				    
				    </td>					<TD ></TD>
				</tr>				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="13" AllowPaging="True" Visible="False">
                            <Columns>
                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador_abreviado" ReadOnly="True" />
                                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="dt_referencia" ReadOnly="True" DataFormatString="{0:MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_tipo_calculo" HeaderText="Calc." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_volume"  HeaderText="Volume" DataFormatString="{0:N0}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="kmfrete" DataFormatString="{0:N0}" HeaderText="Total KM" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_viagens" DataFormatString="{0:N0}" HeaderText="Nr.Viagens" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_variavel" DataFormatString="{0:N2}" HeaderText="Custo Var." >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_fixo" DataFormatString="{0:N2}" HeaderText="Custo Fixo" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_lancado" DataFormatString="{0:N2}" HeaderText="Custo Extra"
                                    ReadOnly="True" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_desconto_lancado" DataFormatString="{0:N2}" HeaderText="Descontos">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_bruto" DataFormatString="{0:N2}" HeaderText="Total Bruto"
                                    ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>

                                            </Columns>
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridromaneios" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="13" AllowPaging="True" Visible="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador_abreviado" ReadOnly="True" />
                                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="dt_referencia" ReadOnly="True" DataFormatString="{0:MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dscalculo" HeaderText="Calc." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume"  HeaderText="Volume" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" DataFormatString="{0:N0}" HeaderText="KM Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_cd_divergencia" HeaderText="Cod.Erro">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_divergencia" HeaderText="Diverg&#234;ncia">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>

                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView><anthem:GridView ID="gridromaneiot2" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="13" AllowPaging="True" Visible="False">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador_abreviado" ReadOnly="True" />
                                                <asp:BoundField HeaderText="Refer&#234;ncia" DataField="dt_referencia" ReadOnly="True" DataFormatString="{0:MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo Frete" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dscalculo" HeaderText="Calc." >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume"  HeaderText="Volume" DataFormatString="{0:N0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_km_frete" DataFormatString="{0:N0}" HeaderText="KM Frete" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_cd_divergencia" HeaderText="Cod.Erro">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_divergencia" HeaderText="Diverg&#234;ncia">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        </TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;<anthem:HiddenField ID="hf_dt_fim" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_dt_inicio" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_frete_periodo" runat="server" AutoUpdateAfterCallBack="true" />
                            &nbsp;&nbsp;
        </div>
		</form>
	</body>
</HTML>
