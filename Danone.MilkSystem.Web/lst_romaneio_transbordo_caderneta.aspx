<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_transbordo_caderneta.aspx.vb" Inherits="lst_romaneio_transbordo_caderneta" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Abrir Romaneio com Transbordo - Seleção de Cadernetas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialogVeiculo() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_veiculo = document.getElementById("hf_id_veiculo");

        szUrl = 'lupa_veiculo.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_veiculo.value=retorno;
        } 
    }            

</script>
	<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_transportador.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_pessoa.value=retorno;
        } 
    }            



    </script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Abrir Romaneio com Transbordo&nbsp;&nbsp;</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 4px;"></TD>
					<TD align="center" style="height: 4px">
						</TD>
					<TD style="height: 4px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="font-size: 8px">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="95%" border="0"   >
							<TR>
								<TD  style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
                                <td style="height: 12px" align="right">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 22px; width:20%" >
                                    Número da Caderneta:</td>
                                <td style=" width:30%">
                                    &nbsp;<anthem:TextBox ID="txt_nr_caderneta" runat="server" CssClass="texto" Width="64px" MaxLength="10"></anthem:TextBox></td>
                                <td style="width:15%" align="right">
                                CNH Motorista:</td>
                                <td style=" width:35%">
                                    &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="texto" Width="88px" MaxLength="14"></anthem:TextBox></td>
                            </tr>
                            
                            <tr>
                                <TD style="HEIGHT: 22px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD>
                                    &nbsp;<anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                    </td>
                                <td  align="right">
                                    Nome
                                    Rota:</td>
                                <td >
                                    &nbsp;<anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    Data Transmissão Caderneta:&nbsp;</td>
                                <td style="height: 22px">
                                    &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_transmissao_ini" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Width="96px"></cc2:OnlyDateTextBox>&nbsp;
                                    à&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_transmissao_fim" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="96px" AutoCallBack="True"></cc2:OnlyDateTextBox>
                                </td>
                                <td style="height: 20px" align="right">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD >&nbsp;</TD>
								<TD align="right">
                                    &nbsp; &nbsp;
                                    &nbsp;&nbsp;</TD>
                                <td align="right" >
                                </td>
                                <td align="right" >
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton></td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                           Inclua as Cadernetas do Transbordo para prosseguir com a abertura do Romaneio com
                        Transbordo:</TD>
						<TD style="height: 19px; width: 10px;"></TD>
			</TR>
				<TR>
					<TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3></TD>
				</TR>
				
				<TR>

					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="5" DataKeyNames="id_protocolo">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_protocolo" HeaderText="N&#250;mero" SortExpression="nr_caderneta" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_motorista" HeaderText="Motorista" SortExpression="ds_motorista" >
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
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Transmiss&#227;o" SortExpression="dt_transmissao">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Incluir no Transbordo">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_incluir_caderneta" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Incluir Caderneta no Transbordo" ImageUrl="~/img/mais_red.gif" UpdateAfterCallBack="True" __designer:wfdid="w95" CommandName="incluirNoTransbordo"></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                    <headerstyle width="10%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ds_tempo_coleta_now" Visible="False">
                                                    <itemtemplate>
<asp:Label id="ds_tempo_coleta_now" runat="server" __designer:wfdid="w93" Text='<%# Bind("ds_tempo_coleta_now") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
                <tr>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp;
                        <asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ico_tanktruck_yellow.gif" />&nbsp;
                        <anthem:LinkButton ID="lk_avancar" runat="server" CssClass="texto" OnClientClick="if (confirm('As cadernetas selecionadas serão incluídas no romaneio com transbordo e não poderão ser utilizadas por outros processos de abertura de romaneio. Deseja realmente prosseguir com o  'Abrir Romaneio com Transbordo' com as cadernetas selecionadas?' )) return true;else return false;"
                            ValidationGroup="vg_avancar">Prosseguir Abrir Romaneio com Transbordo</anthem:LinkButton>&nbsp;
                        <anthem:CustomValidator ID="cv_cadernetastransbordo" runat="server" AutoUpdateAfterCallBack="True"
                            ToolTip="Para prosseguir com a abertura do romaneio com transbordo, mais de uma cadernetas devem ser selecionadas!"
                            ValidationGroup="vg_avancar">[!]</anthem:CustomValidator></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Cadernetas Selecionadas que participarão do Transbordo:</td>
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
									
                                        <anthem:GridView ID="gridresultstransbordo" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_protocolo">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_protocolo" HeaderText="N&#250;mero" SortExpression="nr_caderneta" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_motorista" HeaderText="Motorista" SortExpression="ds_motorista" >
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
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Transmiss&#227;o" SortExpression="dt_transmissao">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Retirar do Transbordo">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_retirar_caderneta" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Retirar Caderneta do Transbordo" ImageUrl="~/img/menos_red.gif" UpdateAfterCallBack="True" CommandName="retirardotransbordo" __designer:wfdid="w19"></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                    <headerstyle width="10%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="10%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>

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
                ShowSummary="False" /><asp:ValidationSummary ID="validatorSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_avancar" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
