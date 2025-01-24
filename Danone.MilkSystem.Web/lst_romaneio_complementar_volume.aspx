<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_complementar_volume.aspx.vb" Inherits="lst_romaneio_complementar_volume" %>

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
		<title>Romaneio Complemento de Volume</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<script type="text/javascript" > 

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
           	     
        szUrl = 'lupa_propriedade.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:580px;edge:raised;dialogHeight:420px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
    </script>

	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Romaneio &nbsp; &nbsp;- Complemento de Volume para Romaneios Fechados</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 7px;"></TD>
					<TD align="center" style="height: 7px">
						</TD>
					<TD width="10" style="height: 7px"></TD>
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
								<TD width="20%" style="height: 10px"></TD>
								<TD style="height: 10px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Propriedade:</td>
                                <td style="height: 20px" valign="bottom">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_id_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" ValidationGroup="vg_pesquisar" Width="80px" AutoPostBack="True"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:CustomValidator ID="cmv_propriedade" runat="server" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_id_propriedade" CssClass="texto" ErrorMessage="Propriedade deve ser informada para continuar."
                                        ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="caixatexto" width="64px"></cc2:onlynumberstextbox>
                                </td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="right" style="height: 12px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
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
						&nbsp;&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" />
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador" SortExpression="ds_transportador" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada"  />
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text="Button" CommandArgument='<%# bind("id_romaneio") %>' __designer:wfdid="w147" CommandName="selecionar" CausesValidation="False"></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
            &nbsp;&nbsp;
            <asp:HiddenField ID="hf_id_propriedade" runat="server" />
		</form>
	</body>
</HTML>
