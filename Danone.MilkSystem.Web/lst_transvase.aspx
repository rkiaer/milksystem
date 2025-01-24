<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_transvase.aspx.vb" Inherits="lst_transvase" %>

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
		<title>Transvase</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Transvase</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 4px;"></TD>
					<TD align="center" style="height: 4px">
						</TD>
					<TD width="10" style="height: 4px"></TD>
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
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="1" width="100%" style="height: 80px"  >
							<TR>
								<TD width="20%" style="height: 5px"></TD>
								<TD style="height: 5px; width: 30%;"></TD>
                                <td style="height: 5px">
                                </td>
                                <td style="height: 5px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="rf_estabelecimento" runat="server"
                                        AutoUpdateAfterCallBack="True" ControlToValidate="cbo_estabelecimento" ErrorMessage="O Estabelecimento deve ser preenchido."
                                        InitialValue="0" ToolTip="O Estabelecimento deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="width: 20%; height: 5px">
                                    <span style="color: #333333">
                                    Nome
                                    Rota:</span></td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                        Width="64px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    Pré-Romaneio:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px"></cc2:onlynumberstextbox></td>
                                <td align="right" style="height: 26px">
                                    Nr Transvase:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_id_transvase" runat="server" CssClass="texto"
                                        Width="70px"></cc2:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" width="20%">
                                    Placa Veículo:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="texto" MaxLength="7" Width="88px" AutoCallBack="true" AutoUpdateAfterCallBack="true"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton
                                        ID="bt_lupa_veiculo" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom"
                                        ImageUrl="~/img/lupa.gif" Width="15px" ToolTip="Filtrar Veículos" AutoUpdateAfterCallBack="True" />&nbsp;
                                     <anthem:CustomValidator ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Placa não cadastrada." ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ControlToValidate="txt_placa">[!]</anthem:CustomValidator>   
                                </td>
                                <td align="right" style="height: 26px">
                                    <span style="color: #333333">Data de Abertura:</span></td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_hora_entrada" runat="server" CssClass="texto" MaxLength="10"
                                        Width="88px"></cc3:OnlyDateTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 3px">
                                    &nbsp;Situação Transvase:</td>
                                <td style="height: 3px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 3px">
                                    </td>
                                <td style="height: 3px">
                                    &nbsp;
                                    </td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px" colspan="3">
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
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server">Novo</anthem:LinkButton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_transvase">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Estabelecimento" DataField="nm_estabelecimento" />
                                                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" SortExpression="id_transvase" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportadora" SortExpression="ds_transportador" />
                                                <asp:BoundField DataField="dt_abertura" HeaderText="Abertura" SortExpression="dt_abertura"  />
                                                <asp:BoundField DataField="nm_situacao_transvase" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao_transvase" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<anthem:HyperLink style="TEXT-ALIGN: center" id="hl_imprimir_ciq" __designer:dtid="5066575350595681" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" ToolTip="Transvase Fechado:  Versão para Imprimir." ImageUrl="~/img/ic_impressao_desabilitado.gif" UpdateAfterCallBack="True" NavigateUrl="~/frm_transvase_impressa.aspx" Target="_blank" Enabled="False" __designer:wfdid="w34"></anthem:HyperLink> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
&nbsp;<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text CommandArgument='<%# bind("id_transvase") %>' CommandName="selecionar" CausesValidation="False" __designer:wfdid="w28"></asp:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao_transvase" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_transvase" runat="server" Text='<%# Bind("id_situacao_transvase") %>' __designer:wfdid="w60"></asp:Label> 
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
                ShowSummary="False" ValidationGroup="vg_salvar" />
            <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
		</form>
	</body>
</HTML>
