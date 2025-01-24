<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_grupo_propriedades.aspx.vb" Inherits="lst_grupo_propriedades" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Grupo de Propriedades</title>
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
<script type="text/javascript"> 

    function ShowDialogTitular() 
    
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Grupo Matriz/Filial</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 22px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px; width: 15%;"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 18%; height: 12px">
                                </td>
                                <td style="width: 35%; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 21px" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 21px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;
                                    </td>
                                <td align="right" style="height: 21px">
                                    &nbsp;Situação:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 21px">Código Produtor:</td>
								<td style="height: 21px" colspan="3">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                            &nbsp;
                                            <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Código Propriedade:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto" Width="72px" MaxLength="10"></asp:TextBox></td>
                                <td align="right" style="height: 21px">
                                    Código Propriedade Matriz:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_id_propriedade_matriz" runat="server" CssClass="caixaTexto"
                                        MaxLength="10" Width="72px"></asp:TextBox></td>
                            </tr>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
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
                            id="lk_novo" runat="server" AutoUpdateAfterCallBack="True">Novo</anthem:linkbutton></TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_grupo_propriedades">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_pessoa_matriz" HeaderText="C&#243;d. Matriz" SortExpression="cd_pessoa_matriz" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa_matriz" HeaderText="Produtor Matriz" SortExpression="nm_pessoa_matriz" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" ReadOnly="True"
                                    SortExpression="id_propriedade_matriz">
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_propriedade" HeaderText="Tipo" />
                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d." ReadOnly="True"
                                    SortExpression="cd_pessoa">
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" SortExpression="nm_pessoa">
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" />
                                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o" SortExpression="ds_situacao" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w23" CommandArgument='<%# Bind("id_propriedade_matriz") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w24" CommandArgument='<%# Bind("id_grupo_propriedades") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao" runat="server" __designer:wfdid="w25" Text='<%# Bind("id_situacao") %>'></asp:Label>
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
