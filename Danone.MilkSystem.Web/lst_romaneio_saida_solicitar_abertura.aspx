<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_saida_solicitar_abertura.aspx.vb" Inherits="lst_romaneio_saida_solicitar_abertura" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Romaneio Saída - Solicitar Abertura</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");
    	     
            szUrl = 'lupa_transportador_cooperativa.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:600px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_transportador.value=retorno;
            } 
    }            
</script>
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Romaneio Saída - Solicitar/Autorizar Entrada</strong></td>
					<td style="width: 9px;height: 25px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" class="texto" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" topmargin="0" >
							<TR>
								<TD style="width: 20%; height: 12px;" ></TD>
								<TD style="height: 12px" ></TD>
								<TD style="width: 15%; height: 12px;" ></TD>
								<TD style="height: 12px" ></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px;">
                                    &nbsp;<span style="color: #ff0000">*</span>Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="Informe o Estabelecimento para continuar." Font-Bold="False" SetFocusOnError="True"
                                        ValidationGroup="vg_load" CssClass="texto">[!]</asp:RequiredFieldValidator></td>
                                 <td align="right">&nbsp;<span style="color: #ff0000">*</span>Período&nbsp;Solicitação:</td>
                                 <td>
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" Columns="7" CssClass="texto"
                                        DateMask="DayMonthYear" Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        Font-Bold="False" SetFocusOnError="True" ErrorMessage="Informe o Período." ValidationGroup="vg_load" CssClass="texto">[!]</asp:RequiredFieldValidator>&nbsp;
                                    à &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" Columns="7" CssClass="texto" DateMask="DayMonthYear"
                                        Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_fim"
                                        Font-Bold="False" SetFocusOnError="True" ValidationGroup="vg_load" CssClass="texto">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px;">
                                    &nbsp;Transportador:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="6" Width="70px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><anthem:CustomValidator
                                            ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_transportador"
                                            CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                            Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_load"></anthem:CustomValidator></td>
                                <td align="right" colspan="1" style="height: 23px">
                                    Tipo Leite: </td>
                                <td colspan="1" style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_id_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr style="color: #333333">
                                <td align="right" style="height: 20px; " >
                                    Situação:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_situacao" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList>
                                    </td>
                                 <td align="right">
                                     Nr Romaneio Saída:</td>
                                <td>
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
							<TR style="color: #333333">
								<TD style="height: 25px; "></TD>
								<TD align="right" style="height: 25px" colspan="3">
                                    &nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    &nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                    </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server" Font-Size="12px" ToolTip="Incluir Nova Solicitação de Abertura">Nova Solicitação</anthem:LinkButton>
                    </TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD class="texto">
                        <br />
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_saida" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_romaneio_saida" HeaderText="Rom. Sa&#237;da" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_item" HeaderText="Item" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_operacao" HeaderText="Opera&#231;&#227;o" />
                                <asp:BoundField DataField="nm_motivo_saida" HeaderText="Motivo" />
                                <asp:BoundField DataField="dt_entrada_estimada" HeaderText="Dt Solicita&#231;&#227;o" DataFormatString="{0:dd/MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_destino_abreviado" HeaderText="Destino" />
                                <asp:BoundField DataField="ds_transportador_abreviado" HeaderText="Transportador" />
                                <asp:BoundField DataField="nm_frete_nf" HeaderText="Tipo Frete" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Dt Entrada" DataFormatString="{0:dd/MM/yyyy hh:mm}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_romaneio_saida" HeaderText="Situa&#231;&#227;o" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandName="edit" __designer:wfdid="w2" CommandArgument='<%# bind("id_romaneio_saida") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Cancelar Solicitação de Abertura" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandName="delete" __designer:wfdid="w114" CommandArgument='<%# bind("id_romaneio_saida") %>' OnClientClick="if (confirm('Deseja realmente CANCELAR a solicitação de abertura do Romaneio de Saída?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="5%" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_romaneio_saida" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_romaneio_saida" runat="server" Text='<%# Bind("id_situacao_romaneio_saida") %>' __designer:wfdid="w17"></asp:Label>
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
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary
                ID="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"
                ValidationGroup="vg_load" />
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
