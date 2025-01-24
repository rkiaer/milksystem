<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_caderneta.aspx.vb" Inherits="lst_caderneta" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Cadernetas </STRONG>
					</TD>
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
                                    Número:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nr_caderneta" runat="server" CssClass="caixaTexto" Width="64px" MaxLength="10"></anthem:TextBox></td>
                            </tr>
							<TR id="TrProdutor" runat="server">
								<TD align="right" > CNH Motorista:</TD>
								<TD >
					                &nbsp;&nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="texto" Width="150px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="11"></anthem:TextBox>
					                &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" CssClass="texto" Width="160px"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                          <anthem:ImageButton ID="btn_lupa_transportador" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Transportadores" Width="15px" AutoUpdateAfterCallBack="true" Visible="False" />
                                          <asp:CustomValidator ID="cv_transportador" runat="server" ErrorMessage="Transportador não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar" Visible="False"></asp:CustomValidator>
                                    
                                </TD>
							</TR>
                            
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
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Rota:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="caixaTexto" MaxLength="10"
                                        Width="64px"></anthem:TextBox>
                                    </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">
                                    Data Transmissão:&nbsp;</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_transmissao_ini" runat="server" CssClass="texto"
                                        Width="96px"></cc2:OnlyDateTextBox>&nbsp; à&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_transmissao_fim" runat="server" CssClass="texto"
                                        Width="96px"></cc2:OnlyDateTextBox>
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
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif" Visible="False"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server" Visible="False">Novo</anthem:linkbutton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" />
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Data Transmiss&#227;o" />
                                                <asp:BoundField DataField="id_protocolo" HeaderText="N&#250;mero" SortExpression="nr_caderneta" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" ReadOnly="True" SortExpression="nm_linha" />
                                                <asp:BoundField DataField="ds_motorista" HeaderText="Motorista" SortExpression="ds_motorista" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" Visible="False" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_protocolo") %>' CommandName="selecionar" __designer:wfdid="w10"></anthem:ImageButton>&nbsp;<anthem:ImageButton id="img_delete" runat="server" UpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" CommandArgument='<%# Bind("id_protocolo") %>' CommandName="delete" __designer:wfdid="w11" OnClientClick="if (confirm('Esta caderneta será ELIMINADA do sistema e deverá ser re-digitada. Deseja realmente continuar com a exclusão?' )) return true;else return false;"></anthem:ImageButton>
</itemtemplate>
                                                    <headerstyle wrap="True" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio" runat="server" Text='<%# Bind("id_romaneio") %>' __designer:wfdid="w12"></asp:Label>
</itemtemplate>
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
