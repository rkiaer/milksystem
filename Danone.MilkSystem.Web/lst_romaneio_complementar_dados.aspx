<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_complementar_dados.aspx.vb" Inherits="lst_romaneio_complementar_dados" %>

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Complementar Dados do Romaneio &nbsp;&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
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
								<TD width="20%" style="height: 11px"></TD>
								<TD style="height: 11px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="88px"></cc2:onlynumberstextbox>
                                </td>
                                <td style="width: 50%; height: 23px">
                                    <anthem:CheckBox ID="chk_cooperativa_nota" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Cooperativas Abertas Incompletas Por Nota" /></td>
                            </tr>
							<TR id="TrProdutor" runat="server">
								<TD align="right" style="height: 22px" > CNH Motorista:</TD>
								<TD style="height: 22px" colspan="2" >
					                &nbsp;&nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="texto" Width="88px" MaxLength="14"></anthem:TextBox>
					                &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" CssClass="texto" Width="160px"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                          <anthem:ImageButton ID="btn_lupa_transportador" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Transportadores" Width="15px" AutoUpdateAfterCallBack="true" Visible="False" />
                                          <asp:CustomValidator ID="cv_transportador" runat="server" ErrorMessage="Transportador não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar" ControlToValidate="txt_cd_transportador" ValidateEmptyText="True" Visible="False"></asp:CustomValidator>
                                    
                                </TD>
							</TR>
                            
                            <tr>
                                <TD style="HEIGHT: 26px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio"> </span>Placa Veículo:</td>
                                <TD style="HEIGHT: 26px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
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
                                <td style="height: 26px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Data Transmissão Caderneta:&nbsp;</td>
                                <td style="height: 20px" colspan="2">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_transmissao_ini" runat="server" CssClass="texto" Width="96px"></cc3:OnlyDateTextBox>&nbsp;
                                    à &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_transmissao_fim" runat="server" CssClass="texto" Width="96px"></cc3:OnlyDateTextBox></td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px" colspan="2">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_salvar"></anthem:imagebutton>&nbsp;
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
						&nbsp;&nbsp;Selecione o Romaneio para complementação dos dados:</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 4px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 4px">&nbsp;</TD>
					<TD style="height: 4px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
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
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text="Button" CausesValidation="False" CommandName="selecionar" CommandArgument='<%# bind("id_romaneio") %>' __designer:wfdid="w331"></asp:ImageButton> 
</itemtemplate>
                                                    <itemstyle width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
										</TD>
					<TD >&nbsp;</TD>
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
                ShowSummary="False" ValidationGroup="vg_salvar" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
