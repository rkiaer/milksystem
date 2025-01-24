<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_mapa_limite_incentivo.aspx.vb" Inherits="lst_mapa_limite_incentivo" %>

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
		<title>Mapa Incentivo Limite</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Mapa Limite Incentivo</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 4px;"></TD>
					<TD align="center" style="height: 4px" >
						</TD>
					<TD style="width: 10px; height: 4px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="vg_flash">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_ano_referencia" runat="server" CssClass="texto"
                                        Width="72px"></cc4:OnlyNumbersTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano_referencia"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="True" ValidationGroup="vg_flash">[!]</asp:RequiredFieldValidator><asp:RangeValidator
                                            ID="RangeValidator1" runat="server" ControlToValidate="txt_ano_referencia" ErrorMessage="Ano de Referência com formato incorreto."
                                            MaximumValue="2100" MinimumValue="2000" Type="Integer" ValidationGroup="vg_flash">[!]</asp:RangeValidator>
                                    <asp:CustomValidator ID="cv_custo" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                        ValidationGroup="vg_flash">[!] </asp:CustomValidator></td>
                                       
                            </tr>
 							
                            <tr runat="server" id="tr_tecnico" visible="false">
                                <td align="right" style="height: 20px; ">
                                    </td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="72px" visible="False"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" visible="False" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
 								<TD style="HEIGHT: 20px; " align="right">
                                     </TD>
								<TD style="HEIGHT: 20px">
                                    Nr Execução Cálculo <span>Projetado</span>:
                                    <anthem:Label ID="lbl_execucao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                           </tr>
                            <tr runat="server" >
                                <td align="right" style="height: 20px">
                                </td>
                                <td align="center" style="height: 20px">
                                     <asp:CheckBox ID="chk_limite_excedido" runat="server" Checked="True" Text="Apenas Limite Excedido" /></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 26px">
                                    </td>
								<TD align="left" colspan="2" style="height: 26px">&nbsp;
                                    </TD>
								<TD align="right" style="height: 26px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_flash"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_flash" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="1" style="height: 3px">
                                </td>
                                <td align="left" colspan="2" style="height: 3px">
                                </td>
                                <td align="right" style="height: 3px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp; Data Execução do Último Cálculo Projetado:
                        <anthem:Label ID="lbl_calculoprojetado" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px; ">
                        &nbsp;</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
				<TR runat="server" >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" align="center">
                        <anthem:Label ID="lbl_flash" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" BackColor="#006699" Font-Bold="True" ForeColor="White" Visible="False" Width="99%">MAPA LIMITE INCENTIVO 2021</anthem:Label>&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; height: 155px;">&nbsp;</TD>
					<TD style="height: 155px" >
									
                        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
<FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"></FooterStyle>

<HeaderStyle HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"></HeaderStyle>

<PagerStyle HorizontalAlign="Left" BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"></PagerStyle>
<Columns>
<asp:BoundField DataField="id_propriedade_matriz" HeaderText="Matriz"></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_tit" HeaderText="Prod Matriz"></asp:BoundField>
<asp:BoundField DataField="id_propriedade" HeaderText="Prop."></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_prod" HeaderText="Produtor"></asp:BoundField>
<asp:BoundField DataField="ds_abreviado_tecnico" HeaderText="EPL" ShowHeader="False"></asp:BoundField>
<asp:BoundField DataField="nr_valor_1" HeaderText="Janeiro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_2" HeaderText="Fevereiro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_3" HeaderText="Mar&#231;o">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_4" HeaderText="Abril">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_5" HeaderText="Maio" ReadOnly="True">
<ItemStyle HorizontalAlign="Right" Wrap="False" Font-Italic="False"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_6" HeaderText="Junho">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_7" HeaderText="Julho">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_8" HeaderText="Agosto">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_9" HeaderText="Setembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_10" HeaderText="Outubro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_11" HeaderText="Novembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nr_valor_12" HeaderText="Dezembro">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="volumeprojetado" Visible="False"><ItemTemplate>
<asp:Label id="lbl_volumeprojetado" runat="server" Text='<%# bind("nr_volume_projetado") %>' __designer:wfdid="w16"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="propordenacao" Visible="False"><ItemTemplate>
<asp:Label id="lbl_propordenacao" runat="server" Text='<%# Bind("id_propriedade_ordenacao") %>' __designer:wfdid="w3"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="volumetotal" Visible="False"><ItemTemplate>
<asp:Label id="lbl_volumetotal" runat="server" Text='<%# Bind("nr_volume_ano_por_prop") %>' __designer:wfdid="w17"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="nr_saldo_limite" Visible="False"><ItemTemplate>
<asp:Label id="lbl_nr_saldo_limite" runat="server" Text='<%# Bind("nr_saldo_limite_ano_por_prop") %>' __designer:wfdid="w63"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False"><ItemTemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w65"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

<RowStyle ForeColor="#000066"></RowStyle>
</anthem:GridView>
                        <br />
                        <anthem:Label ID="lbl_informativo" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="Texto" Font-Italic="True" ForeColor="Blue" Height="16px" UpdateAfterCallBack="True"
                            Visible="False">*Mês em destaque indicando PAGAMENTO PROVISÓRIO. Sujeito à alterações no fechamento de cálculo.</anthem:Label></TD>
					<TD style="width: 10px; height: 155px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top"  >&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_flash"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
