<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_saida_analise_selecao.aspx.vb" Inherits="lst_romaneio_saida_analise_selecao" %>

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
		<title>lst_romaneio_saida_analise_selecao</title>
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
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Romaneio Saída - Registrar Análises &nbsp;&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
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
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0" style="height: 80px"  >
                            <tr>
                                <td align="right" width="20%">
                                    Romaneio Saída:</td>
                                <td>
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="88px"></cc2:onlynumberstextbox>
                                </td>
                            </tr>
                            
                            <tr>
                                <TD align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD>
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="False" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" width="20%">
                                    Entrada Romaneio:</td>
                                <td>
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_hora_entrada" runat="server" CssClass="texto" MaxLength="10"
                                        Width="88px"></cc3:OnlyDateTextBox></td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_salvar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;Selecione o Romaneio de Saída Carregado para registro das análises:</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 9px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 9px">&nbsp;</TD>
					<TD style="height: 9px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="texto">
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_romaneio_saida">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_romaneio_saida" HeaderText="Romaneio Sa&#237;da" SortExpression="id_romaneio_saida" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_transportador_abreviado" HeaderText="Transportador" />
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada" DataFormatString="{0:dd/MM/yyyy hh:mm}"  />
                                                <asp:BoundField DataField="nm_analista" HeaderText="Analista" />
                                                <asp:BoundField DataField="dt_inicio_analise" HeaderText="In&#237;cio An&#225;lise" DataFormatString="{0:dd/MM/yyyy hh:mm}" />
                                                <asp:BoundField DataField="nm_st_analise_compartimento" HeaderText="An&#225;lise Comp." SortExpression="nm_st_analise_compartimento" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text CausesValidation="False" CommandName="selecionar" __designer:wfdid="w146" CommandArgument='<%# bind("id_romaneio_saida") %>'></asp:ImageButton> 
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
