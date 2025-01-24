<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_nota_fiscal.aspx.vb" Inherits="lst_nota_fiscal" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Lista Notas Fiscais</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
   	        szUrl = 'lupa_coopertiva.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
    }            
</script>
		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Notas Fiscais&nbsp;Entrada</STRONG></TD>
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
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 21px">
                                    Código Emitente:</td>
								<td style="height: 21px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                            &nbsp;
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                            <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" ValidationGroup="vg_lupa" />
                                    <asp:CustomValidator ID="cv_pessoa" runat="server" ControlToValidate="txt_cd_pessoa"
                                        CssClass="texto" ErrorMessage="Emitente não cadastrado!" Font-Bold="False"
                                        Text="[!]" ToolTip="Emitente não Cadastrado!" ValidationGroup="vg_pesquisar"></asp:CustomValidator></td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Nr. Nota Fiscal:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc3:onlynumberstextbox id="txt_nr_nota_fiscal" runat="server" cssclass="caixaTexto"
                                        maxlength="7" width="72px"></cc3:onlynumberstextbox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="caixaTexto"
                                        MaxLength="10" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Natureza da Operação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_natureza_operacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 3px">
                                    &nbsp;Situação:</td>
                                <td style="height: 3px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
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
                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True"
                                    SortExpression="ds_estabelecimento">
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_pessoa" HeaderText="Emitente" SortExpression="ds_pessoa" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nota Fiscal" ReadOnly="True"
                                    SortExpression="nr_nota_fiscal">
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" ReadOnly="True"
                                    SortExpression="nr_serie" Visible="False">
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_natureza_operacao" HeaderText="Natureza Opera&#231;&#227;o"
                                    SortExpression="cd_natureza_operacao" Visible="False">
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_emissao" HeaderText="Dt Emiss&#227;o" />
                                <asp:BoundField DataField="dt_transacao" HeaderText="Dt Transa&#231;&#227;o" />
                                <asp:BoundField DataField="nr_preco_total" HeaderText="Valor Total" />
                                <asp:TemplateField>
                                    <itemstyle horizontalalign="Center" />
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("id_nota_fiscal") %>' __designer:wfdid="w3"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" CommandName="delete" CommandArgument='<%# Bind("id_nota_fiscal") %>' __designer:wfdid="w4" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
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
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
