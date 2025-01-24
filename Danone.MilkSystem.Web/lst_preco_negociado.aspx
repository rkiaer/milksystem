<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_preco_negociado.aspx.vb" Inherits="lst_preco_negociado" %>

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
		<title>lst_preco_negociado</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
	<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Preço Negociado </STRONG>
					</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" >
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">

                            <tr>
                                <TD style="HEIGHT: 23px; width: 18%;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 23px; width: 30%;">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
                                <td align="right" style="width: 15%; height: 23px">
                                    <strong><span style="color: #ff0000">*</span></strong>Mês / Ano:</td>
								<td style="height: 23px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px" >
                                    Código Técnico:</td>
                                <td style="height: 23px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    &nbsp;<anthem:CustomValidator ID="cv_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_tecnico" CssClass="texto" ErrorMessage="Técnico não cadastrado."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_tecnico"
                                        ErrorMessage="Informe o Técnico." Font-Bold="True" ValidationGroup="vg_pesquisar" Visible="False">[!]</asp:RequiredFieldValidator></td>
								<TD style="HEIGHT: 23px"></TD>
                           </tr>
                            <tr>
                                <TD style="HEIGHT: 23px" align="right">
                                    &nbsp;Cluster:</td>
                                <TD style="HEIGHT: 23px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_cluster" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 23px">
                                    &nbsp;Situação Aprovação:</td>
                                <TD style="HEIGHT: 23px">
                                    &nbsp;<asp:DropDownList id="cbo_status" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<tr>
  								<TD style="HEIGHT: 20px" align="right">&nbsp</TD>
								<TD style="HEIGHT: 20px" align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ico_email.gif"></asp:Image><anthem:LinkButton ID="lk_email" runat="server" ValidationGroup="vg_pesquisar" OnClientClick="if (confirm('Uma notificação de que existem preços a serem aprovados será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;" CssClass="texto">Notificar Aprovadores</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; " class="texto">&nbsp;<table class="texto" style="width: 100%">
                            <tr>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_precomediototal" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Total:</anthem:Label></td>
                                <td style="width: 30%">
                                    <anthem:Label ID="lbl_preco_medio_cluster_total" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                <td align="right" style="width: 20%">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_precomedioouro" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio CPM:</anthem:Label>
                                </td>
                                <td style="width: 30%">
                                    <anthem:Label ID="lbl_preco_medio_cluster_ouro" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_precomedioprata" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Negociação Gerencial:</anthem:Label></td>
                                <td>
                                    <anthem:Label ID="lbl_preco_medio_cluster_prata" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_precomediobronze" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Mercado:</anthem:Label></td>
                                <td style="width: 30%">
                                    <anthem:Label ID="lbl_preco_medio_cluster_bronze" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_precomediocoml" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Contrato:</anthem:Label></td>
                                <td>
                                    <anthem:Label ID="lbl_preco_medio_cluster_coml" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
                        </table>
                    </TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" ShowFooter="True" DataKeyNames="id_preco_negociado">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" SortExpression="ds_produtor" ReadOnly="True" />
                                <asp:BoundField HeaderText="Propriedade" DataField="id_propriedade" SortExpression="id_propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" ReadOnly="True" SortExpression="nm_cluster" />
                                <asp:BoundField HeaderText="Volume" DataField="nr_total_volume" SortExpression="nr_total_volume" ReadOnly="True" />
                                <asp:BoundField HeaderText="Pre&#231;o M-1" DataField="nr_preco_mes_anterior" SortExpression="nr_preco_mes_anterior" ReadOnly="True" />
                                <asp:BoundField HeaderText="Adic. Volume" ReadOnly="True" Visible="False" />
                                <asp:BoundField HeaderText="Adic. Regiao" ReadOnly="True" Visible="False" />
                                <asp:BoundField HeaderText="Adic. Mercado" DataField="nr_adicional_mercado" SortExpression="nr_adicional_mercado" ReadOnly="True" />
                                <asp:BoundField HeaderText="Pre&#231;o Obj" DataField="subtotal" SortExpression="subtotal" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Negociado ">
                                    <edititemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_preco_negociado" runat="server" CssClass="texto" Width="70px" MaxLength="15" DecimalSymbol="," MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w29"></cc4:OnlyDecimalTextBox><anthem:RequiredFieldValidator id="rfpreconegociado" runat="server" ValidationGroup="vg_salvar" CssClass="texto" ErrorMessage="Preço Negociado deve ser informado." ControlToValidate="txt_nr_preco_negociado" ToolTip="Preço Negociado deve ser informado." __designer:wfdid="w30">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator id="cpvpreco" runat="server" ValidationGroup="vg_salvar" CssClass="texto" ValueToCompare="0" Type="Double" Operator="GreaterThan" ErrorMessage="Preço Negociado deve ser maior que zero." ControlToValidate="txt_nr_preco_negociado" __designer:wfdid="w31">[!]</anthem:CompareValidator>
</edititemtemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_preco_negociado" runat="server" Text='<%# bind("nr_preco_negociado") %>' __designer:wfdid="w28"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o" DataField="variacao" SortExpression="variacao" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Justificativa">
                                    <edititemtemplate>
<anthem:DropDownList id="cbo_justificativa" runat="server" CssClass="texto" __designer:wfdid="w33"></anthem:DropDownList> <anthem:RequiredFieldValidator id="rf_cbo_justificativa" runat="server" ValidationGroup="vg_salvar" CssClass="texto" ErrorMessage="Justificativa deve ser informada." ControlToValidate="cbo_justificativa" ToolTip="Justificativa deve ser informada." __designer:wfdid="w34">[!]</anthem:RequiredFieldValidator>
</edititemtemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_justificativa" runat="server" CssClass="texto" Text='<%# bind("nm_preco_justificativa") %>' __designer:wfdid="w32"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" />
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_salvar" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#B3CBF0" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; ">&nbsp;
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
