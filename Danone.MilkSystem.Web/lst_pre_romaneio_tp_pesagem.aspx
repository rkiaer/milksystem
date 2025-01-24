<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_pre_romaneio_tp_pesagem.aspx.vb" Inherits="lst_pre_romaneio_tp_pesagem" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Atualizar Pesagem Pré-Romaneios para Transit Point</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>
                        <anthem:Label ID="lbl_titulo" runat="server">Atualizar Pesagem Pré-Romaneio para Transit Point</anthem:Label></STRONG></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 10px;"></TD>
					<TD align="center" class="texto" style="height: 10px">
						</TD>
					<TD width="10" style="height: 10px"></TD>
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
                        <table id="Table3" cellpadding="1" cellspacing="0" class="borda" style="height: 80px"
                            width="100%">
                            <tr>
                                <td style="height: 5px" width="20%">
                                </td>
                                <td style="width: 30%; height: 5px">
                                </td>
                                <td style="height: 5px">
                                </td>
                                <td style="height: 5px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="rf_estabelecimento" runat="server"
                                        AutoUpdateAfterCallBack="True" ControlToValidate="cbo_estabelecimento" ErrorMessage="O Estabelecimento deve ser preenchido."
                                        InitialValue="0" ToolTip="O Estabelecimento deve ser preenchido." ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="width: 20%; color: #333333; height: 5px">
                                    <span style="color: #333333"></span>
                                    <anthem:Label ID="lbl_unidade" runat="server">*Unidade Transit Point:</anthem:Label></td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="rf_transitpoint" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_transit_point" ErrorMessage="A unidade de Transit Point deve ser preenchida."
                                        InitialValue="0" ToolTip="A unidade de Transit Point deve ser preenchida." ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr style="color: #333333">
                                <td align="right" style="height: 26px" width="20%">
                                    Pré-Romaneio:</td>
                                <td style="height: 26px">
                                    &nbsp; 
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px"></cc2:onlynumberstextbox></td>
                                <td align="right" style="height: 26px">
                                    Caderneta:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_nr_caderneta" runat="server" CssClass="texto" Width="64px"></cc2:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    Nome Rota:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox>
                                </td>
                                <td align="right" style="height: 26px">
                                    <strong><span style="color: #ff0000"></span></strong>Placa Veículo:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="caixaTexto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true" Height="16px" ValidationGroup="vg_pesquisar"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" width="20%">
                                    Entrada Pré-Romaneio:</td>
                                <td>
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_hora_entrada_ini" runat="server" CssClass="texto"
                                        Width="80px" ></cc3:OnlyDateTextBox>
                                    &nbsp;à &nbsp;&nbsp;<cc3:OnlyDateTextBox ID="txt_dt_hora_entrada_fim" runat="server"
                                        CssClass="texto" Width="80px"></cc3:OnlyDateTextBox></td>
                                <td align="right">
                                Situação:</td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 12px">
                                    &nbsp;</td>
                                <td align="right" colspan="3" style="height: 12px">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</td>
                            </tr>
                        </table>
                        <br />
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
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Pr&#233;-Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" />
                                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador" SortExpression="ds_transportador" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" />
                                                <asp:BoundField DataField="dt_transmissao" HeaderText="Transmiss&#227;o" SortExpression="dt_transmissao"  />
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
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
