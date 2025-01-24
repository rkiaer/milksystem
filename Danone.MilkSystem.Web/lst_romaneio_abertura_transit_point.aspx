<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_abertura_transit_point.aspx.vb" Inherits="lst_romaneio_abertura_transit_point" %>

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
		<title>Abertura de Romaneio de Transit Point</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Abrir Romaneio &nbsp;de Transit Point</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
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
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" style="height: 80px" onclick="return Table2_onclick()" >
							<TR>
								<TD width="20%" style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px; width: 30%;"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="width: 35%; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px" width="20%">
                                    Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 23px">
                                    Unidade Transit Point:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR id="TrProdutor" runat="server">
								<TD align="right" style="height: 23px" > 
                                    Número Transit Point</td>
                                <TD style="height: 23px" >
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_transit_point" runat="server" CssClass="texto"
                                        MaxLength="10" Width="80px"></cc3:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 23px">
                                    Nome
                                    Rota:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="70px"></anthem:TextBox></td>
							</TR>
                            
                            <tr>
                                <TD style="HEIGHT: 23px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD style="HEIGHT: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                    </td><TD align="right" style="height: 23px" >
                                    Data Abertura Transit Point:</td>
                                <TD style="height: 23px" >
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_ini" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Width="96px"></cc2:OnlyDateTextBox>&nbsp;
                                    à&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="96px" AutoCallBack="True"></cc2:OnlyDateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <TD style="height: 10px">
                                    &nbsp;</td>
                                <TD align="right" style="height: 10px">
                                    &nbsp;&nbsp;</td>
                                <td align="right" style="height: 10px">
                                </td>
                                <td align="right" style="height: 10px">
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 24px" align="right">&nbsp;</TD>
								<TD style="HEIGHT: 24px">&nbsp;
                                    </TD>
                                <td style="height: 24px">
                                </td>
                                <td align="right" style="height: 24px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;
                                </td>
							</TR>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px">
                                    &nbsp;&nbsp;</td>
                                <td align="right" style="height: 12px">
                                </td>
                                <td align="right" style="height: 12px">
                                </td>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<strong>Selecione o Transit Point para abrir o Romaneio:</strong></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 15px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_transit_point">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_transit_point_unidade" HeaderText="Unidade TP" />
                                                <asp:BoundField DataField="id_transit_point" HeaderText="Transit Point" SortExpression="id_transit_point" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_abertura" HeaderText="Abertura" SortExpression="dt_abertura">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Abrir Romaneio">
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Abrir Romaneio" ImageUrl="~/img/abrir_romaneio.gif" CommandArgument='<%# Bind("id_transit_point") %>' CommandName="selecionar" __designer:wfdid="w140"></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                    <headerstyle width="8%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="8%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
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
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
