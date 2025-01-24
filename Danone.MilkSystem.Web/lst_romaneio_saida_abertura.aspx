<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_saida_abertura.aspx.vb" Inherits="lst_romaneio_saida_abertura" %>

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
		<title>Romaneios - Controle de Frete</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {       
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_cooperativa.value=retorno;
        } 
    }            
</script>	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Romaneio Saída - Abertura por Romaneio de Entrada</strong></td>
					<td style="width: 9px;height: 25px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" valign="middle" class="texto" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" topmargin="0" >
							<TR>
								<TD style="width: 17%; height: 3px;" ></TD>
								<TD style="width: 22%;height: 3px" ></TD>
                                <td style="width: 14%; height: 3px">
                                </td>
                                <td style="height: 3px">
                                </td>
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
                                <td align="right" style="height: 23px">
                                    <span style="color: #ff0000">*</span>Período&nbsp;de Entrada:</td>
                                <td align="left" colspan="1" style="height: 23px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" Columns="7" CssClass="texto"
                                        DateMask="DayMonthYear" Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        Font-Bold="False" SetFocusOnError="True" ErrorMessage="Informe o Período." ValidationGroup="vg_load" CssClass="texto">[!]</asp:RequiredFieldValidator>&nbsp;
                                    à &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" Columns="7" CssClass="texto" DateMask="DayMonthYear"
                                        Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_fim"
                                        Font-Bold="False" SetFocusOnError="True" ValidationGroup="vg_load" CssClass="texto">[!]</asp:RequiredFieldValidator>&nbsp;<span style="color: #ff0000"></span></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px;">
                                    &nbsp;Nr. Romaneio Entrada:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox></td>
                                <td align="right">
                                     Nome da Rota:</td>
                                <td align="left">
                                    &nbsp;
                                     <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                         Width="70px" AutoUpdateAfterCallBack="True"></anthem:TextBox></td>
                            </tr>
							<TR style="color: #333333">
								<TD style="height: 25px; "></TD>
								<TD align="right" style="height: 25px" colspan="3">
                                    &nbsp; &nbsp;
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    &nbsp;&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                    </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;Selecione o Romaneio de Entrada para abertura do Romaneio de Saída:</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD class="texto">
                        <br />


                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabel." />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota/Coop" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_transit_point" HeaderText="Transit Point" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_transvase" HeaderText="Transvase">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" DataFormatString="{0:dd/MM/yyyy hh:mm}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_saida" HeaderText="Sa&#237;da" DataFormatString="{0:dd/MM/yyyy hh:mm}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso L&#237;quido" DataFormatString="{0:n0}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_peso_liquido_caderneta" HeaderText="Volume" DataFormatString="{0:n0}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w19" CommandName="selecionar" CommandArgument='<%# bind("id_romaneio") %>' CausesValidation="False" Text="Button"></asp:ImageButton>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="5%" />
                                    <itemstyle horizontalalign="Center" width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nm_cooperativa" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nm_cooperativa" runat="server" __designer:wfdid="w10" Text='<%# Bind("nm_cooperativa") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_peso_liquido_nota" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_peso_liquido_nota" runat="server" __designer:wfdid="w15" Text='<%# Bind("nr_peso_liquido_nota") %>'></asp:Label>
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
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
