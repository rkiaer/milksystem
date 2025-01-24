<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_controleleite.aspx.vb" Inherits="lst_relatorio_controleleite" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_relatorio_controleleite</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 925px;"><STRONG>Relatório Controle de Recepção de Leite</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 925px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 155px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 155px" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 101px"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 19px; " align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 19px; ">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" Display="Dynamic" ValidationGroup="gv_pesquisar">[!]</asp:CompareValidator></td>

                                <td align="right" style="height: 19px; width: 101px;">&nbsp;</td>
                                <td align="right" style="height: 19px">&nbsp;</td>
                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Entrada:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_data_ini" runat="server" CssClass="texto" Width="80px"></cc3:OnlyDateTextBox>&nbsp; à&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_data_fim" runat="server" CssClass="texto" Width="80px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data para continuar."
                                        Font-Bold="True" ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator></td>
								<TD align="right" style="height: 20px; width: 101px;"></TD>
								<TD align="right" style="height: 20px;"></TD>
 							</tr>
                            <tr>
                                <td align="right" style="height: 19px">
                                    Rota:</td>
                                <td style="height: 19px">
                                    &nbsp; 
                                    <anthem:TextBox ID="txt_cd_rota_ini" runat="server" CssClass="texto" Width="80px"></anthem:TextBox>&nbsp;
                                    à &nbsp;<anthem:TextBox ID="txt_cd_rota_fim" runat="server" CssClass="texto" Width="80px"></anthem:TextBox>
                                    &nbsp;
                                </td>
                                <td align="right" style="width: 101px; height: 19px">
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px" >
                                    &nbsp;<span style="color: #ff0000">*</span>Emitir por:</td>
                                <td style="height: 19px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_emitirpor" runat="server" CssClass="texto" Width="152px">
                                        <asp:ListItem Value="1">Compartimento</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">Romaneio</asp:ListItem>
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_emitirpor"
                                        ErrorMessage='O campo "Emitir por" deve ser informado!' Font-Bold="True" InitialValue="[selecione]"
                                        SetFocusOnError="True" ValidationGroup="gv_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="width: 101px; height: 19px">
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
 							
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="gv_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px; height: 155px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 925px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif"></asp:Image>
                        <anthem:HyperLink ID="hl_imprimir" runat="server" CssClass="texto" NavigateUrl="~/frm_relatorio_motorista.aspx"
                            Target="_blank" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Enabled="False">Versão para Imprimir</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 925px;">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_compartimento">
                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
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
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridResultsRom" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
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
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_variacao_transportador" DataFormatString="{0:n0}" HeaderText="0,2% (lts)" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataFormatString="{0:n0}" HeaderText="Desc (lts)" DataField="valordescontotransportador">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="id_cooperativa" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_cooperativa" runat="server" Text='<%# Bind("id_cooperativa") %>' __designer:wfdid="w1"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; width: 925px;">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
