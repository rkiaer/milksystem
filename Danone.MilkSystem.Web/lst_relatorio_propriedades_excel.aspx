<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_propriedades_excel.aspx.vb" Inherits="lst_relatorio_propriedades_excel" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_propriedade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
<script type="text/javascript"> 

    function ShowDialog() 
    
    {        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
   	        szUrl = 'lupa_produtor.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
    }            
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Relação de Propriedades</STRONG></TD>
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
							<TR>
								<TD width="20%" style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px; width: 30%;"></TD>
                                <td style="width: 20%; height: 12px">
                                </td>
                                <td style="width: 30%; height: 12px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 22px" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 22px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="vg_pesquisar" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;</td>
                                <td align="right" style="height: 22px">
                                    Código SAP:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_sap" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 22px">Código Produtor:</td>
								<td style="height: 22px" colspan="3">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                            <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                            &nbsp;
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                            </td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 22px" width="20%">
                                    Código Propriedade:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto" Width="72px" MaxLength="10"></asp:TextBox></td>
                                <td align="right" style="height: 22px">
                                    Grupo:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:DropDownList ID="cbo_grupo" runat="server" AutoCallBack="True"
                                        AutoPostBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="vg_load">
                                        <asp:ListItem Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">Produtor</asp:ListItem>
                                        <asp:ListItem Value="4">Cooperativa</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 22px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 22px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px">
                                </td>
							</TR>
							<tr>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        EnableCallBack="False" ImageUrl="~/img/bnt_exportar.gif" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
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
                                <asp:BoundField DataField="Estabelecimento" HeaderText="Estab." SortExpression="estabelecimento" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cod_Produtor" HeaderText="Produtor" SortExpression="cod_produtor" >
                                </asp:BoundField>
                                <asp:BoundField DataField="Produtor" HeaderText="Nome" SortExpression="produtor" >
                                    <itemstyle wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" SortExpression="nm_cluster" />
                                <asp:BoundField DataField="cod_propriedade" HeaderText="Propr."
                                    SortExpression="cod_propriedade">
                                </asp:BoundField>
                                <asp:BoundField DataField="propriedade" HeaderText="Nome"
                                    SortExpression="propriedade">
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="UP" HeaderText="UP" SortExpression="UP" />
                                <asp:BoundField DataField="Tecnico_Danone" HeaderText="T&#233;cnico" />
                                <asp:BoundField DataField="Situacao" HeaderText="Situa&#231;&#227;o" SortExpression="situacao" />
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w1" CommandName="edit" CommandArgument='<%# Bind("Cod_Propriedade") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w2" CommandName="delete" CommandArgument='<%# Bind("Cod_Propriedade") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" />
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
