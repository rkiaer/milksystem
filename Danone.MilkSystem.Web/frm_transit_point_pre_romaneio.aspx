<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transit_point_pre_romaneio.aspx.vb" Inherits="frm_transit_point_pre_romaneio" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Transit Point - Pré Romaneios</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialogPreRomaneio() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_romaneio = document.getElementById("hf_id_romaneio");
   	    var idtransitpoint
   	    idtransitpoint = document.getElementById("hf_id_transit_point").value;

        szUrl = 'lupa_transit_point_pre_romaneio.aspx?id='+idtransitpoint+'';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:700px;edge:raised;dialogHeight:600px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_romaneio.value=retorno;
        } 
    }            

</script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 28px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 28px;"><STRONG>Transit Point - Transit Point X Pré-Romaneios&nbsp;&nbsp;</STRONG></TD>
					<TD style="width: 10px; height: 28px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</TD>
					<TD style="HEIGHT: 25px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD id="Td1" runat="server" style="font-size: 8px">
                        <br /><TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 9px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Transit Point</td>
                                <TD style="height: 19px; width: 10px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="95%" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"   >
                            <TR>
                                <TD  style="height: 12px; ">
                                </td>
                                <TD style="height: 12px">
                                </td>
                                <td style="height: 12px" align="right">
                                </td>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
                                <td style=" height: 12px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px; width: 17%;" >
                                    Número do Transit Point:</td>
                                <td style=" width:15%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_id_transit_point" runat="server"></anthem:Label></td>
                                <td style="width:13%; height: 22px;" align="right">
                                    Unidade Transit Point:</td>
                                <td style=" width:20%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_ds_unidade_transit_point" runat="server"></anthem:Label></td>
                                <td style="width: 15%; height: 22px;" align="right">
                                    Situação Transit Point:
                                </td>
                                <td style=" width:20%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_nm_situacao_transit_point" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 22px;" align="right">
                                    &nbsp;<span id="Span2" class="obrigatorio"> </span>Placa Veículo Principal:</td>
                                <TD style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_ds_placa" runat="server"></anthem:Label>
                                </td>
                                <td  align="right" style="height: 22px">
                                    Nome Rota:</td>
                                <td style="height: 22px" >
                                    &nbsp;<anthem:Label ID="lbl_nm_linha" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 22px">
                                    Total Volume Transit Point:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_nr_total_litros_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Informe Pré-Romaneio e inclua no Transit Point:</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
				<TR>
					<TD style="width: 9px; height: 54px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="font-size: 8px; height: 54px;">
                        <br /><TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="95%" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"   >
                            <TR>
                                <TD  style="height: 12px; ">
                                </td>
                                <TD style="height: 12px">
                                </td>
                                <td style="height: 12px" align="right">
                                </td>
                                <td style="height: 12px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px; width: 17%;" >
                                    Pré-Romaneio:</td>
                                <td style=" width:32%; height: 22px;">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_pre_romaneio" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox>&nbsp;<anthem:ImageButton
                                            ID="btn_lupa_pre_romaneio" runat="server" AutoUpdateAfterCallBack="true" BorderStyle="None"
                                            Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Pré-Romaneios"
                                            Width="15px" />
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_id_pre_romaneio"
                                        CssClass="texto" ErrorMessage="Preencha o campo Pré-Romaneio para continuar ou selecione-o pela lupa."
                                        Font-Bold="True" ValidationGroup="vg_incluirpreromaneio">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                            ID="cv_pre_romaneio" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_pre_romaneio"
                                            CssClass="texto" Display="Dynamic" ErrorMessage="Pré-Romaneio não pode ser selecionado ou não existe."
                                            Font-Bold="true" Text="[!]" ToolTip="Pré-Romaneio não pode  ser selecionado ou não existente." ValidationGroup="vg_incluirpreromaneio"></anthem:CustomValidator>&nbsp;<anthem:Button
                                                ID="btn_incluir_pre_romaneio" runat="server" CssClass="texto" Text="Incluir"
                                                ToolTip="Incluir Pré-Romaneio no Transit Point" ValidationGroup="vg_incluirpreromaneio" AutoUpdateAfterCallBack="True" /></td>
                                <td style="width:25%; height: 22px;" align="right">
                                </td>
                                <td style=" width:25%; height: 22px;">
                                </td>
                            </tr>
                        </table>
					</TD>
					<TD style="width: 10px; height: 54px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>

				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Pré-Romaneios Selecionados para o &nbsp;Transit Point
                        <anthem:Label ID="lbl_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label></TD>
						<TD style="height: 19px; width: 10px;"></TD>
			</TR>
				<TR>
					<TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3></TD>
				</TR>
				
				<TR>

					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center">
									
                                        <anthem:GridView ID="gridPreRomaneio" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="99%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_romaneio" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#333333" HorizontalAlign="Center">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small"  />
                                            <HeaderStyle  Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center"  />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle  Font-Names="Verdana" Font-Size="XX-Small" Font-Italic="False" Font-Overline="False" ForeColor="White" HorizontalAlign="Center" Wrap="True"
                                                 />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Det.">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe" runat="server" ImageUrl="~/img/icon_preview.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Coletas do Pré-Romaneio" __designer:wfdid="w123" CommandArgument='<%# bind("id_romaneio") %>' CommandName="viewdetalhepreromaneio"></anthem:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Pr&#233;-Romaneio" SortExpression="id_romaneio" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Abertura" SortExpression="dt_hora_entrada">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_peso_liquido_caderneta" HeaderText="Volume">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Vol. Disp." DataField="nr_total_litros_tp_disponivel" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Vol. Transferido" DataField="nr_total_litros_tp_transferidos" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_litros_utilizados" HeaderText="Utilizado TP"
                                                    ReadOnly="True">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_saldo" HeaderText="Vol. Saldo">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Retirar">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_retirar_pre_romaneio" runat="server" ImageUrl="~/img/menos_red.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Retirar Pré-Romaneio do Transit Point." CommandName="retirar" CommandArgument='<%# bind("id_romaneio") %>' OnClientClick="if (confirm('Ao retirar  o pré-romaneio deste Transit Point, todos os volumes já incluídos referentes à ele serão excluídos do Transit Point. Deseja realmente retirar este Pré-Romaneio?' )) return true;else return false;" __designer:wfdid="w104"></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                    <headerstyle width="3%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Detalhe do Pré-Romaneio
                        <anthem:Label ID="lbl_pre_romaneio" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label>. Selecione os produtores, informe
                        os volumes e inclua as propriedades/coletas no Transit Point.</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                				<TR>

					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridDetalhePreRomaneio" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_uproducao" CssClass="texto" PageSize="100">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" CssClass="texto" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<anthem:CheckBox id="chk_selecionar_todos" runat="server" AutoUpdateAfterCallBack="True" AutoPostBack="True" __designer:wfdid="w9" OnCheckedChanged="chk_selecionar_todos_CheckedChanged"></anthem:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<anthem:CheckBox id="chk_selecionar" runat="server" AutoUpdateAfterCallBack="True" __designer:wfdid="w11"></anthem:CheckBox> 
</itemtemplate>
                                                    <headerstyle width="3%" />
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa"  ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp." ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor"  ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP"  ReadOnly="True">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_litros" HeaderText="Volume" ReadOnly="True">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Vol. Transf." DataField="nr_litros_pre_romaneio_transit_point" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Vol. Transf TP" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Vol. Saldo" DataField="nr_litros_pre_romaneio_saldo" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Volume TP">
                                                    <itemtemplate>
<cc3:OnlyNumbersTextBox id="txt_nr_volume_tp" runat="server" AutoUpdateAfterCallBack="True" Width="55px" CssClass="texto" __designer:wfdid="w6" MaxLength="6"></cc3:OnlyNumbersTextBox> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/menos_red.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Remover Volume Transferido deste item do Transit Point." CommandName="retirarup" OnClientClick="if (confirm('Deseja realmente retirar o volume desta propriedade/compartimento do Transit Point?' )) return true;else return false;" __designer:wfdid="w106"></anthem:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio_uproducao" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio_uproducao" runat="server" Text='<%# Bind("id_romaneio_uproducao") %>' __designer:wfdid="w108"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio" runat="server" Text='<%# Bind("id_romaneio") %>' __designer:wfdid="w110"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w112"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_unid_producao" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_unid_producao" runat="server" Text='<%# Bind("id_unid_producao") %>' __designer:wfdid="w115"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="width: 9px; height: 54px;">
                        &nbsp;</td>
                    <TD id="Td2" runat="server" style="font-size: 8px; height: 54px;">
                        <br />
                        <TABLE class="borda" id="Table5" cellSpacing="0" cellPadding="0" width="100%" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"   >
                            <tr>
                                <td align="right" style="height: 22px; width: 20%;" >
                                    Placa Transit Point:
                                    <anthem:DropDownList ID="cbo_placa_tp" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" AutoCallBack="True">
                                    </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="cbo_placa_tp" CssClass="texto" ErrorMessage="Preencha o campo Placa do Transit Point para Incluir os Volumes no Transit Point."
                                        Font-Bold="True" ValidationGroup="vg_incluir">[!]</asp:RequiredFieldValidator></td>
                                <td style="height: 22px;" align="left">
                                    &nbsp; &nbsp;Compartimento Transit Point:
                                    <anthem:DropDownList ID="cbo_compartimento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False" AutoCallBack="True">
                                    </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_compartimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Compartimento do Transit Point para Incluir os Volumes no Transit Point."
                                        Font-Bold="True" ValidationGroup="vg_incluir">[!]</asp:RequiredFieldValidator>&nbsp;Volume Máx. Comp.:
                                    <anthem:Label ID="lbl_volume_maximo" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
                                <td style="height: 22px">
                                    Volume Selecionado:
                                    <anthem:Label ID="lbl_volume_selecionado" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
                                <td style=" width:17%; height: 22px;" align="center">
                                    <anthem:Button
                                                ID="btn_adicionar_volume" runat="server" CssClass="texto" Text="Adicionar Volume"
                                                ToolTip="Adicionar volume do Pré-Romaneio no Transit Point" ValidationGroup="vg_incluir" AutoUpdateAfterCallBack="True" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 12px">
                                </td>
                                <td align="right">
                                </td>
                                <td>
                                </td>
                                <td>
                                    <anthem:CustomValidator ID="CustomValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_incluir">[!]</anthem:CustomValidator>
                                    <anthem:CustomValidator ID="cv_volume" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_incluir">[!]</anthem:CustomValidator></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px; height: 54px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        TRANSIT POINT X PRODUTORES:</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD align="center">
                        <anthem:GridView ID="gridTransitPoint" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_transit_point_up" CssClass="texto" PageSize="100">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" CssClass="texto" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa TP"  ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp. TP" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_maximo_comp" HeaderText="Capacidade Comp.">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume Total Comp" DataField="nr_total_litros" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_produtor_abreviado" HeaderText="Produtor"  ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP"  ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_litros" HeaderText="Volume" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Pr&#233;-Romaneio" DataField="id_pre_romaneio" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_transit_point" HeaderText="Situa&#231;&#227;o TP" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 25px; width: 9px;">
                        &nbsp;</td>
                    <TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar_footer" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</td>
                    <TD style="HEIGHT: 25px; width: 10px;">
                        &nbsp;</td>
                </tr>

                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD>
                        &nbsp;</td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir" /><asp:ValidationSummary ID="validatorSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluirpreromaneio" />
            &nbsp;
            <anthem:HiddenField ID="hf_id_romaneio" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_transit_point" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
