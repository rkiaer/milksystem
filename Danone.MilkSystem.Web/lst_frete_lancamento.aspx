<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_lancamento.aspx.vb" Inherits="lst_frete_lancamento" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.OnlyNumbers" Namespace="RK.TextBox.OnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Lançamento para Cálculo de Frete</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");

        szUrl = 'lupa_transportador_cooperativa.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_transportador.value=retorno;
        } 
    }             
</script>

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
	

<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Lançamento para Cálculo de Frete</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
                        
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
                            <tr>
                                <TD style="HEIGHT: 22px; width: 18%;" align="right"><span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 22px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="gv_estabel" Display="Dynamic">[!]</asp:CompareValidator></td>
                                <td style="height: 22px; width: 18%;" align="right">
                                    Referência:</td>
                                <td style="height: 22px; width: 20%;">
                                    &nbsp;<cc5:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="caixaTexto"
                                        DateMask="MonthYear" Width="80px"></cc5:OnlyDateTextBox></td>
                            </tr>
			                <tr>
			                    <td  align="right" style="height: 23px">
                                    Transportador:</td>
								<td style="height: 23px" colspan="3">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="6" Width="70px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><anthem:CustomValidator
                                            ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_transportador"
                                            CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                            Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_pesquisar"
                                            Visible="False"></anthem:CustomValidator></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 23px" >
                                    Cooperativa:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="6" Width="70px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="False" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:CustomValidator ID="cv_cooperativa"
                                            runat="server" ControlToValidate="txt_cd_cooperativa" CssClass="texto" ErrorMessage="Cooperativa não cadastrada!"
                                            Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_pesquisar"
                                            Visible="False"></asp:CustomValidator></td>
                                <td style="height: 23px">
                                </td>
                                <td style="height: 23px">
                                </td>
                            </tr>
							
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Código Conta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_conta" runat="server" CssClass="caixaTexto" Width="72px"></asp:TextBox></td>
                                <td align="right" style="height: 20px">
                                    Nome Conta:</td>
                                <td style="height: 20px">
                                    &nbsp;<asp:textbox id="txt_nm_conta" runat="server" cssclass="caixaTexto" MaxLength="50"></asp:textbox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 23px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 23px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                                <td style="height: 23px" align="right">
                                    Romaneio:</td>
                                <td style="height: 23px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_romaneio" runat="server" CssClass="caixaTexto" Width="80px"></cc3:OnlyNumbersTextBox></td>
							</TR>
							<tr>
								<TD style="height: 28px">&nbsp;</TD>
								<TD align="right" style="height: 28px">
                                    &nbsp;
                                    &nbsp;&nbsp;</TD>
                                <td align="right" colspan="2" style="height: 28px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp;
                                </td>
							</TR>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_frete_lancamento">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" SortExpression="dt_referencia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_frete_conta" HeaderText="Conta" SortExpression="cd_conta" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_frete_conta" HeaderText="Descri&#231;&#227;o" SortExpression="nm_conta" />
                                <asp:BoundField DataField="nr_valor" HeaderText="Valor/Qtde" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" SortExpression="ds_transportador" ReadOnly="True" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle wrap="False" horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo Frete" SortExpression="ds_tipo_frete">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" ReadOnly="True"
                                    SortExpression="id_romaneio">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w373" CommandName="edit" CommandArgument='<%# Bind("id_frete_lancamento") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" __designer:wfdid="w376" CommandName="delete" CommandArgument='<%# Bind("id_frete_lancamento") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><div visible="false">
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
