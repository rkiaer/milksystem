<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_pesagem_final.aspx.vb" Inherits="lst_romaneio_pesagem_final" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_compartimento</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Pesagem Final</STRONG></TD>
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
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 80px" onclick="return Table2_onclick()" >
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px"></cc2:onlynumberstextbox>
                                </td>
                            </tr>
                            
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="caixaTexto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true" Height="16px"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    Nome
                                    Rota:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Data Transmissão Caderneta:&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_transmissao_ini" runat="server" CssClass="texto"
                                        Width="96px"></cc3:OnlyDateTextBox>&nbsp; à &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_transmissao_fim" runat="server" CssClass="texto"
                                        Width="96px"></cc3:OnlyDateTextBox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    </TD>
							</TR>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px">
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
						</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_romaneio">
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
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text="Button" CausesValidation="False" CommandName="selecionar" __designer:wfdid="w147" CommandArgument='<%# bind("id_romaneio") %>'></asp:ImageButton>
</itemtemplate>
                                                </asp:TemplateField>
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
