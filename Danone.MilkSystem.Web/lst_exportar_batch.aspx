<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_batch.aspx.vb" Inherits="lst_exportar_batch" %>

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
		<title>Exportacão Batch Declaration</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<script type="text/javascript"> 
    <!--
    function showaguarde() 
    
    {
        
        document.all.lbl_aguarde.value='aguardenormal';  	     
    }            
    //-->
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportação Batch Declaration - Recibo de Mercadoria</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 133px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 133px">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="20%" style="HEIGHT: 22px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 22px;">
                                    &nbsp;&nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" Width="193px">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 22px; " align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas exportadas:"
                                         Width="160px" Visible="False"></anthem:Label></TD>
								<TD style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False"></anthem:Label></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 22px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Período:</td>
                                <td style="height: 22px; ">&nbsp;&nbsp;&nbsp;<cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto"
                                        DateMask="DayMonthYear" Width="76px"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="76px"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        CssClass="texto" ErrorMessage="A data inicial do período deve ser informada." Font-Bold="False" AutoUpdateAfterCallBack="True" ValidationGroup="A data inicial do período deve ser informada.">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada.">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_fim"
                                                ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date">[!]</anthem:CompareValidator></td>
								<TD style="height: 22px;" align="left" colspan="2">
                                    <anthem:CheckBox ID="chk_romaneios_exportados" runat="server" Text="Romaneios já exportados" />&nbsp;</TD>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px" >
                                    Romaneio:</td>
                                <td style="height: 22px; ">
                                    &nbsp; &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="texto"
                                        Width="76px"></cc3:OnlyNumbersTextBox>
                                    &nbsp; &nbsp;
                                </td>
                                <TD style="height: 22px; width: 156px;" align="right">
                                </td>
                                <TD style="height: 22px">
                                    &nbsp;</td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD style="height: 25px; width: 439px;">
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="100%">Aguarde... Geração do arquivo em andamento...</anthem:Label></TD>
								<TD style="width: 156px; height: 25px;">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    &nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ></anthem:imagebutton>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;<table id="Table3" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td valign="top">
                                    <table id="Table6" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                                        <tr style="height: 16px">
                                            <td class="texto" style="height: 11px">
                                            </td>
                                            <td class="texto" style="font-size: 1px; height: 5px">
                                                <table border="0" cellpadding="0" cellspacing="0" class="texto" style="margin-bottom: 0px;
                                                    padding-bottom: 0px; vertical-align: text-bottom; height: 8px; text-align: left">
                                                    <tr>
                                                        <td id="td_tela1" runat="server" align="left" class="texto" style="font-size: 1px;
                                                            vertical-align: text-bottom; height: 6px">
                                                            <anthem:Panel ID="pnl_tela1" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_ativa.gif"
                                                                CssClass="texto" ForeColor="#0000F5" Height="23px" HorizontalAlign="Center" Width="135px">
                                                                <anthem:LinkButton ID="btn_resultado" runat="server" AutoUpdateAfterCallBack="True"
                                                                    CssClass="texto" ForeColor="#0000F5">Resultado</anthem:LinkButton></anthem:Panel>
                                                            &nbsp; &nbsp; &nbsp;</td>
                                                        <td id="td_tela2" runat="server" align="left" style="font-size: 1px; vertical-align: text-bottom;
                                                            height: 6px">
                                                            <anthem:Panel ID="pnl_tela2" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                                                CssClass="texto" Height="23px" HorizontalAlign="Center" Visible="False" Width="136px">
                                                                <anthem:LinkButton ID="btn_erros" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                    ForeColor="#6767CC">Erros</anthem:LinkButton></anthem:Panel>
                                                            &nbsp; &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                                    <table id="Table7" border="0" cellpadding="0" cellspacing="0" class="texto"
                                                        width="100%">
                                                        <tr></tr>
                                                        <tr>
                                                            <td align="right" style="height: 15px; width: 627px;" valign="top">
                                                                    <table id="Table13" border="0" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                        <tr>
                                                                            <td align="right" style="width: 21%; height: 20px">
                                                                                <strong>
                                                                                    <anthem:Label ID="lbl_nr_execucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False">Nr Execucao:</anthem:Label></strong></td>
                                                                            <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                                &nbsp;<anthem:Label ID="lbl_id_exportacao_batch_execucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                                            </td>
                                                                            <td align="right" style="width: 19%; height: 20px">
                                                                                <strong>
                                                                                    <anthem:Label ID="lbl_status" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                                        UpdateAfterCallBack="True" Visible="False">Status:</anthem:Label></strong></td>
                                                                            <td align="left" class="texto" style="width: 31%;">
                                                                                &nbsp;<anthem:Label ID="lbl_status_execucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="texto" style="height: 5px" valign="top">
                                                                                <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" Visible="False">
                                                                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="id_exportacao_batch_itens" HeaderText="Item Exec." />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="In&#237;cio Descarga" ReadOnly="True"
                                    SortExpression="dt_ini_descarga">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                                                                        <asp:BoundField DataField="nr_volume_estoque" HeaderText="Volume" SortExpression="nr_volume" />
                                                                                        <asp:BoundField DataField="ds_tipo_fornecedor" HeaderText="Tipo" />
                                                                                        <asp:BoundField DataField="ds_tipo_leite" HeaderText="Tipo Leite" />
  <asp:TemplateField HeaderText="Arq. Download">
                                                                                            <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" Text='<%# bind("nm_arquivo") %>' ToolTip="Clique aqui para download do arquivo" __designer:wfdid="w3"></asp:HyperLink>
</itemtemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="st_exportacao_batch_itens" HeaderText="Status"
                                                                                            SortExpression="st_exportacao_batch_itens" />
                                                                                    </Columns>
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                </anthem:GridView>
                                                                &nbsp;<br />
                                                                                <anthem:GridView ID="grderros" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" Visible="False">
                                                                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="id_exportacao_batch_itens" HeaderText="Item Exec." />
                                                                                        <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                                                                        <asp:BoundField DataField="nm_erro" HeaderText="Erro" SortExpression="nm_erro" ReadOnly="True" >
                                                                                            <itemstyle wrap="False" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="id_exportacao_batch_erro" HeaderText="id_exportacao_frete_execucao_erro"
                                                                                            Visible="False" />
                                                                                    </Columns>
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                </anthem:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
                                            </td>
                                            <td style="height: 113px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
                        &nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
		</form>
	</body>
</HTML>
