<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_termo_ocorrencia.aspx.vb" Inherits="lst_relatorio_termo_ocorrencia" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_relatorio_motorista</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
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
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Relatório Termo de Ocorrência</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 5px;"></TD>
					<TD align="center" style="height: 5px" >
						</TD>
					<TD style="width: 10px; height: 5px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="95%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 20%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px;"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 19px; " colspan="3">
                                    &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" Display="Dynamic" ValidationGroup="gv_pesquisar">[!]</asp:CompareValidator>
                                    &nbsp;</td>
                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Período:</td>
                                <td style="height: 20px" colspan="3">
                                    &nbsp;<cc3:OnlyDateTextBox ID="txt_dt_ini" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data para continuar." Font-Bold="True" ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right"  >
                                    Transportador:</td>
                                <td class="texto" colspan="3">
                                    &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                    &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                        Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="gv_pesquisar"></anthem:CustomValidator>&nbsp;</td>
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">
                                    Nome Rota:</td>
                                <td style="height: 20px" colspan="3">
                                    &nbsp;<anthem:TextBox ID="txt_rota" runat="server" CssClass="texto" Width="75px"></anthem:TextBox></td>
 							</tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Romaneio:</td>
                                <td style="height: 20px" colspan="3">
                                    &nbsp;<cc5:OnlyNumbersTextBox ID="txt_romaneio" runat="server" CssClass="texto" Width="75px"></cc5:OnlyNumbersTextBox></td>
                            </tr>
 							
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right" >
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio">
                            <Columns>
                                <asp:BoundField HeaderText="Data" DataField="dt_hora_entrada" SortExpression="dt_hora_entrada" />
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" SortExpression="id_romaneio" />
                                <asp:BoundField HeaderText="Rota/Coop." DataField="rota" />
                                <asp:BoundField DataField="caderneta_nota" HeaderText="Nr Cadern/Nota" />
                                <asp:BoundField HeaderText="Transportador" DataField="ds_transportador" SortExpression="ds_transportador" />
                                <asp:BoundField DataField="nr_peso_balanca" HeaderText="Balan&#231;a(lts)" >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_caderneta_nota" HeaderText="Vol. Cadern/Nota" />
                                <asp:BoundField HeaderText="Diferen&#231;a" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="0,2% (lts)" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Desconto (lts)" />
                                <asp:TemplateField HeaderText="Pre&#231;o">
                                    <itemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_preco" runat="server" AutoUpdateAfterCallBack="True" AutoCallBack="True" CssClass="texto" Width="56px" UpdateAfterCallBack="True" __designer:wfdid="w76" OnTextChanged="txt_nr_preco_TextChanged" AutoPostBack="True" DecimalSymbol="," MaxCaracteristica="4" MaxMantissa="2"></cc4:OnlyDecimalTextBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Imprimir">
                                    <itemtemplate>
<anthem:HyperLink style="TEXT-ALIGN: center" id="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" ToolTip="Relatório Termo de Ocorrência:  Versão para Imprimir." ImageUrl="~/img/ic_impressao.gif" Target="_blank" NavigateUrl="~/frm_relatorio_termo_ocorrencia.aspx" __designer:wfdid="w82"></anthem:HyperLink>&nbsp; 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; ">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />

        </div>
		</form>
	</body>
</HTML>
