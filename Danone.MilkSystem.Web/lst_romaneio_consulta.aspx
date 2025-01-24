<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_consulta.aspx.vb" Inherits="lst_romaneio_consulta" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Consultar Romaneios</title>
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
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>Consultar Romaneio</STRONG></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 80px"  >
							<TR>
								<TD style="height: 8px; width: 20%;"></TD>
								<TD style="height: 8px"></TD>
                                <td style="height: 8px">
                                </td>
                                <td style="height: 8px; width: 35%;">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    Romaneio:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="88px"></cc2:onlynumberstextbox>
                                </td>
                                <td style="height: 21px" align="right">
                                    Período:</td>
                                <td style="height: 21px">
                                    &nbsp;<cc3:OnlyDateTextBox ID="txt_dt_hora_entrada_ini" runat="server" CssClass="texto"
                                        Width="80px" ></cc3:OnlyDateTextBox>
                                    &nbsp;à &nbsp;&nbsp;<cc3:OnlyDateTextBox ID="txt_dt_hora_entrada_fim" runat="server"
                                        CssClass="texto" Width="80px"></cc3:OnlyDateTextBox></td>
                            </tr>
                            
                            <tr>
                                <TD style="HEIGHT: 21px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD style="HEIGHT: 21px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                    </td>
                                <td style="height: 21px" align="right">
                                Situação:</td>
                                <td style="height: 21px">
                                    &nbsp;<asp:DropDownList ID="cbo_situacao" runat="server" CssClass="texto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px">
                                    Transit Point:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_transit_point" runat="server" CssClass="texto" Width="88px"></cc2:OnlyNumbersTextBox></td>
                                <td style="height: 21px" align="right">
                                    Transvase:</td>
                                <td style="height: 21px">
                                    &nbsp;<cc2:OnlyNumbersTextBox ID="txt_transvase" runat="server" CssClass="texto"
                                        Width="88px"></cc2:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Tipo:&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;&nbsp;<asp:DropDownList ID="cbo_tipo" runat="server" CssClass="texto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">Cooperativa</asp:ListItem>
                                        <asp:ListItem Value="2">Produtor</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
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
					<TD style="height: 3px; width: 9px;" class="texto"></TD>
					<TD vAlign="middle" style="height: 3px" class="texto">&nbsp;</TD>
					<TD style="height: 3px" class="texto"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="texto">
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador" SortExpression="ds_transportador" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Transmiss&#227;o" SortExpression="dt_transmissao"  />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" />
                                                <asp:BoundField DataField="dt_inicio_analise" HeaderText="In&#237;cio An&#225;lise" />
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text="Button" __designer:wfdid="w1" CausesValidation="False" CommandName="selecionar" CommandArgument='<%# bind("id_romaneio") %>'></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField />
                                            </Columns>
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
