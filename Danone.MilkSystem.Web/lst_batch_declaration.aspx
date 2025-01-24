<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_batch_declaration.aspx.vb" Inherits="lst_batch_declaration" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Consultar Dados Batch Declaration</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialog(pid) 
    
    {
        var retorno="";
   	    var szUrl;

        szUrl = 'frm_batch_erro.aspx?id='+pid+'';

        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
    }            

</script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>Consultar Dados Batch Declaration - Recebimento de Leite</STRONG></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" class="texto">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 80px" onclick="return Table2_onclick()" >
							<TR>
								<TD  style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="height: 12px; width: 40%;">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Período Processamento:&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_ini" runat="server" CssClass="texto"
                                        Width="80px" ></cc3:OnlyDateTextBox>
                                    &nbsp;à &nbsp;&nbsp;<cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server"
                                        CssClass="texto" Width="80px"></cc3:OnlyDateTextBox>&nbsp;
                                </td>
                                <td align="right" style="height: 20px">
                                    Nr. Execução:</td>
                                <td style="height: 20px">
                                    &nbsp;<cc2:OnlyNumbersTextBox ID="txt_nr_execucao" runat="server" CssClass="texto" Width="80px"></cc2:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px"></cc2:onlynumberstextbox>
                                </td>
                                <td style="height: 21px" align="right">
                                Situação:</td>
                                <td style="height: 21px">
                                    &nbsp;<asp:DropDownList ID="cbo_situacao" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="I">Inicializada</asp:ListItem>
                                        <asp:ListItem Value="F">Finalizada</asp:ListItem>
                                        <asp:ListItem Value="E">Erro</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    </td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" />&nbsp;								
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<tr>
				    <td style="height: 19px; width: 9px;"></td>
				    <td vAlign="middle" style="height: 19px">
                            <table border="0" cellpadding="0" cellspacing="0" class="texto" style="margin-bottom: 0px;
                                padding-bottom: 0px; vertical-align: text-bottom; height: 8px; text-align: left">
                                <tr>
                                    <td id="td_resultados" runat="server" align="left" class="texto" style="font-size: 1px;
                                        vertical-align: text-bottom; height: 6px">
                                        <anthem:Panel ID="pnl_resultados" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_ativa.gif"
                                            CssClass="texto" ForeColor="#0000F5" Height="23px" HorizontalAlign="Center" Width="135px">
                                            <anthem:LinkButton ID="btn_resultados" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" ForeColor="#0000F5">Resultados</anthem:LinkButton></anthem:Panel>
                                        &nbsp; &nbsp; &nbsp;</td>
                                    <td id="td_romaneios" runat="server" align="left" style="font-size: 1px; vertical-align: text-bottom;
                                        height: 6px">
                                        <anthem:Panel ID="pnl_romaneios" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                            CssClass="texto" Height="23px" HorizontalAlign="Center" Visible="true" Width="136px">
                                            <anthem:LinkButton ID="btn_romaneios" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" ForeColor="#6767CC">Romaneios</anthem:LinkButton></anthem:Panel>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
				    
				    </td>
				    <TD style="height: 19px"></TD>

				</tr>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_exportacao_batch_itens">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_exportacao_batch_execucao" HeaderText="Exec." SortExpression="id_exportacao_batch_execucao" />
                                                <asp:BoundField DataField="dt_ini_execucao_itens" HeaderText="Processamento" SortExpression="dt_ini_execucao_itens"  >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada" />
                                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="Descarga" SortExpression="dt_ini_descarga" />
                                                <asp:BoundField DataField="nr_peso_balanca" HeaderText="Peso Liq" />
                                                <asp:BoundField DataField="nr_volume_estoque" HeaderText="Litros Reais" />
                                                <asp:BoundField DataField="ds_destino_leite_rejeitado" HeaderText="Ocor." />
                                                <asp:BoundField DataField="nr_po" HeaderText="Nr PO" SortExpression="nr_po" />
                                                <asp:BoundField DataField="cd_estabelecimento_sap" HeaderText="Estabel.SAP" />
                                                <asp:BoundField DataField="cd_item_sap" HeaderText="Item SAP" />
                                                <asp:BoundField DataField="cd_transportador_sap" HeaderText="Transp.SAP" />
                                                <asp:BoundField DataField="ds_tipo_fornecedor" HeaderText="Tipo" />
                                                <asp:BoundField DataField="nm_arquivo" HeaderText="Arquivo" />
                                               
                                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                                    <itemtemplate>
<anthem:LinkButton id="lk_erro" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w34" CommandName="consultar" CommandArgument='<%# bind("id_exportacao_batch_itens") %>'>Erro</anthem:LinkButton> <anthem:Label id="lbl_situacao" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w6" Text='<%# bind("st_exportacao_batch_itens") %>'></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
                                        
                                        <anthem:GridView ID="gridRomaneios" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio" Visible="False">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada" />
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" />
                                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso L&#237;q." />
                                                <asp:BoundField HeaderText="Dens." />
                                                <asp:BoundField HeaderText="Litros Reais" />
                                                <asp:BoundField DataField="nr_peso_liquido_caderneta_nota" HeaderText="Litros Cadern/NF" />
                                                <asp:BoundField HeaderText="Varia&#231;&#227;o" />
                                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="Descarga" SortExpression="dt_ini_descarga" />
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Sit. Romaneio"
                                                    SortExpression="nm_st_romaneio" >
                                                    <headerstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_registro_exportacao_batch" HeaderText="Registro Exporta&#231;&#227;o " SortExpression="nm_registro_exportacao_batch" />
                                                <asp:BoundField DataField="dt_registro_exportacao_batch" HeaderText="Dt Registro" SortExpression="dt_registro_exportacao_batch" />
                                                <asp:BoundField DataField="ds_login_registro" HeaderText="Usu&#225;rio Registro" />
                                                <asp:BoundField DataField="st_exportacao_batch" HeaderText="Exportado" SortExpression="st_exportacao_batch" />
                                                <asp:BoundField DataField="dt_exportacao_batch" HeaderText="Dt Exporta&#231;&#227;o" SortExpression="dt_exportacao_batch" />
                                                <asp:BoundField DataField="ds_login_exportacao" HeaderText="Usu&#225;rio Exporta&#231;&#227;o" />
                                            </Columns>
                                        </anthem:GridView>
                                        
                        <br />
                        <anthem:GridView ID="grderros" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana"
                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" UpdateAfterCallBack="True"
                            Visible="False" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_exportacao_batch_execucao" HeaderText="Execu&#231;&#227;o" />
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" />
                                <asp:BoundField DataField="nm_erro" HeaderText="Erro" ReadOnly="True" SortExpression="nm_erro">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_exportacao_batch_erro" HeaderText="id_exportacao_batch_erro"
                                    Visible="False" />
                                <asp:BoundField DataField="id_exportacao_batch_itens" HeaderText="Item Exec." Visible="False" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
