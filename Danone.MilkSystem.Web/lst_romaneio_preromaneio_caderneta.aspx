<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_preromaneio_caderneta.aspx.vb" Inherits="lst_romaneio_preromaneio_caderneta" %>

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
		<title>Transit Point - Abertura do Pr�-Romaneio</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>
                        <anthem:Label ID="lbl_titulo" runat="server" AutoUpdateAfterCallBack="True" Text="Abertura do Pr� Romaneio para Transit Point"
                            UpdateAfterCallBack="True"></anthem:Label></STRONG></TD>
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
					<TD id="td_pesquisa" runat="server" class="texto" valign="top">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 80px" onclick="return Table2_onclick()" >
							<TR>
								<TD width="20%" style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px; width: 30%;"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="width: 35%; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <td colspan="3" style="height: 20px">
                                    &nbsp;
                        <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                        </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="rf_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                            ControlToValidate="cbo_estabelecimento" ErrorMessage="O Estabelecimento deve ser preenchido para a abertura do Pr�-Romaneio."
                            InitialValue="0" ToolTip="O Estabelecimento deve ser preenchido para a abertura do Pr�-Romaneio."
                            ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px" width="20%">
                                    N�mero da Caderneta:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nr_caderneta" runat="server" CssClass="texto" Width="64px" MaxLength="10"></anthem:TextBox></td>
                                <td align="right" style="height: 22px">
                                    CNH Motorista:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="texto" Width="88px" MaxLength="14"></anthem:TextBox></td>
                            </tr>
							<TR id="TrProdutor" runat="server">
								<TD align="right" style="height: 22px" > Placa Ve�culo:&nbsp;</TD>
								<TD style="height: 22px" >
					                &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Ve�culos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa n�o cadastrada." ValidationGroup="vg_pesquisar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator></TD>
                                <td align="right" style="height: 22px">
                                    Nome Rota:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox></td>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" align="right">
                                    Data Transmiss�o Caderneta:&nbsp;</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_transmissao_ini" runat="server" CssClass="texto"
                                        Width="80px"></cc3:OnlyDateTextBox>&nbsp; � &nbsp;<cc3:OnlyDateTextBox ID="txt_dt_transmissao_fim"
                                            runat="server" CssClass="texto" Width="80px"></cc3:OnlyDateTextBox></TD>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
							</TR>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px" colspan="3">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar" AutoUpdateAfterCallBack="True"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="bottom" style="height: 19px" class="texto">&nbsp;
                        <anthem:Label ID="lbl_unidade_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Text="Informe a Unidade do Transit Point:" UpdateAfterCallBack="True"></anthem:Label>&nbsp;<anthem:DropDownList ID="cbo_transit_point"
                                runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" AutoCallBack="True" AutoPostBack="True">
                            </anthem:DropDownList>
                        <anthem:RequiredFieldValidator ID="rf_transitpoint" runat="server" AutoUpdateAfterCallBack="True"
                            ControlToValidate="cbo_transit_point" ErrorMessage="A unidade de Transit Point deve ser preenchida para a abertura do Pr�-Romaneio de Transit Point."
                            ToolTip="A unidade de Transit Point deve ser preenchida para a abertura do Pr�-Romaneio de Transit Point."
                            ValidationGroup="vg_abrirpre">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                ID="cv_abrirpreromaneio" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_abrirpre">[!]</anthem:CustomValidator></TD>
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
                                                <asp:BoundField DataField="id_protocolo" HeaderText="N&#250;mero" SortExpression="nr_caderneta" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_motorista" HeaderText="Motorista" SortExpression="transportador" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" ReadOnly="True" SortExpression="nm_linha" />
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Transmiss&#227;o" SortExpression="dt_transmissao">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Abrir Pr&#233;-Romaneio">
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_abrirpre" ToolTip="Abrir Pr�-Romaneio" ImageUrl="~/img/ico_tanktruck_yellow.gif" OnClientClick="if (confirm('Deseja realmente abrir um pr�-romaneio para Transit Point da Caderneta selecionada, e para o Estabelecimento e Unidade de transit point informados?' )) return true;else return false;" CommandName="selecionar" CommandArgument='<%# Bind("id_protocolo") %>' __designer:wfdid="w20"></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                    <headerstyle width="10%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ds_tempo_coleta_now" Visible="False">
                                                    <itemtemplate>
<asp:Label id="ds_tempo_coleta_now" runat="server" Text='<%# bind("ds_tempo_coleta_now") %>' __designer:wfdid="w21"></asp:Label> 
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
                ShowSummary="False" ValidationGroup="vg_pesquisar" /><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_abrirpre" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
		</form>
	</body>
</HTML>
