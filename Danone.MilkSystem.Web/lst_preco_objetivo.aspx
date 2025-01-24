<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_preco_objetivo.aspx.vb" Inherits="lst_preco_objetivo" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_preco_objetivo</title>
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
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");

        szUrl = 'lupa_tecnico.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_tecnico.value=retorno;
        } 

    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Preço Objetivo</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="2" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span class="obrigatorio">*</span>Ano:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_ano" runat="server" CssClass="caixaTexto" Width="72px" MaxLength="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano"
                                        ErrorMessage="Informe o Ano de Referência." ValidationGroup="vg_pesquisar" Font-Bold="True">[!]</asp:RequiredFieldValidator></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 20px">Código Técnico:</td>
								<td style="height: 14px">
                                    &nbsp;
		                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                            &nbsp;
                                            <anthem:Label ID="lbl_nm_tecnico" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="200px" Height="16px"></anthem:Label>
                                            &nbsp;<anthem:imagebutton ID="img_lupa_tecnico" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Técnicos"   AutoUpdateAfterCallBack="true" />
                                            &nbsp;<anthem:CustomValidator ID="cv_tecnico" runat="server" 
                                                                ErrorMessage="Técnico não cadastrado." ControlToValidate="txt_cd_tecnico" CssClass="texto" Font-Bold="True" ValidationGroup="vg_pesquisar" AutoUpdateAfterCallBack="True">[!]</anthem:CustomValidator>
                               </td>
							</tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
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
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 10px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nr_ano" HeaderText="Ano" SortExpression="nr_ano" >
                                    <headerstyle width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tecnico" HeaderText="T&#233;cnico" SortExpression="ds_tecnico" ReadOnly="True" >
                                    <headerstyle width="50%" />
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w10" CommandName="edit" CommandArgument='<%# Bind("id_preco_objetivo") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w11" CommandName="delete" CommandArgument='<%# Bind("id_preco_objetivo") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="20%" />
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
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;</div>
		</form>
	</body>
</HTML>
