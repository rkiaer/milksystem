<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_lancamento.aspx.vb" Inherits="lst_lancamento" %>

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
		<title>lst_lancamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Lançamento</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="gv_estabel" Display="Dynamic">[!]</asp:CompareValidator></td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 20px">Código Produtor:</td>
								<td style="height: 20px">
								    <table cellpadding="0" cellspacing="0" style="height: 20px">
								        <tr>
								            <td style="width: 9px; height: 20px;" >&nbsp;</td>
		                                    <td align="right" style="height: 20px"><anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                            </td>
                                            <td style="height: 20px">&nbsp;
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="true"></anthem:Label>
                                            &nbsp;&nbsp;<anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                            </td>
    	                                </tr>
                                    </table>
                                </td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
							</tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código Propriedade:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px"></asp:TextBox>
                                    <asp:Label ID="lbl_nm_propriedade" runat="server" Width="111px"></asp:Label></td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Data Referência:</td>
                                <td style=" height: 20px">
                                    &nbsp;
                                    <cc5:OnlyDateTextBox ID="txt_ds_referencia" runat="server" CssClass="caixaTexto" DateMask="MonthYear"
                                        Width="72px"></cc5:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px">
                                    Nr. Importação:</td>
                                <td style="height: 20px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_importacao" runat="server" CssClass="caixatexto"
                                        Width="88px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
							
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código Conta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_conta" runat="server" CssClass="caixaTexto" Width="72px"></asp:TextBox></td>
                                <td align="right" style="height: 20px">
                                    Nome Conta:</td>
                                <td style="height: 20px">
                                    &nbsp;<asp:textbox id="txt_nm_conta" runat="server" cssclass="caixaTexto"
                                        width="272px"></asp:textbox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
							</TR>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    &nbsp;
                                    &nbsp;&nbsp;</TD>
                                <td align="right" colspan="2">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton></td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Data Referencia" SortExpression="ds_referencia" />
                                <asp:BoundField DataField="cd_conta" HeaderText="Conta" SortExpression="id_conta" >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_conta" HeaderText="Descri&#231;&#227;o" SortExpression="nm_conta" />
                                <asp:BoundField DataField="nr_valor" HeaderText="Valor/Qtde" />
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True"
                                    SortExpression="ds_propriedade">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_lancamento") %>' CommandName="edit" __designer:wfdid="w10"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandArgument='<%# Bind("id_lancamento") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w11"></anthem:ImageButton> 
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
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
