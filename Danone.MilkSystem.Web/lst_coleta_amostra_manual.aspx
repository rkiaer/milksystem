<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_coleta_amostra_manual.aspx.vb" Inherits="lst_coleta_amostra_manual" %>

<%@ Register Assembly="RK.TextBox.OnlyNumbers" Namespace="RK.TextBox.OnlyNumbers"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc6" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Coleta de Amostra Manual</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Coleta de Amostra Manual</STRONG></TD>
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
                                <TD style="HEIGHT: 21px" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 21px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!"
                                        Font-Bold="True" Operator="NotEqual" Type="Integer" ValidationGroup="vg_pesquisar"
                                        ValueToCompare="0">[!]</asp:CompareValidator></td>
                                <td align="right" style="height: 21px">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Referência:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        ErrorMessage="A Referência deve ser informada." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
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
                                <td align="right" style="height: 21px" width="20%">
                                    Tipo da Coleta:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_tipo_coleta" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="height: 21px">
                                    Situação Coleta Manual:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<tr>
								<TD align="right">&nbsp;Período em Dias:</TD>
                                <td>
                                    &nbsp;&nbsp;<cc6:onlynumberstextbox id="txt_dia_ini" runat="server" cssclass="texto"
                                        maxlength="2" width="30px"></cc6:onlynumberstextbox>
                                    à
                                    <cc6:onlynumberstextbox id="txt_dia_fim" runat="server" cssclass="texto" maxlength="2"
                                        width="30px"></cc6:onlynumberstextbox>
                                    &nbsp;<anthem:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_dia_ini"
                                        ErrorMessage="O Dia Inicial da 1a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                        MinimumValue="1" ToolTip="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                        Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim" ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                            MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                            Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini" ControlToValidate="txt_dia_fim"
                                                ErrorMessage="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
								<TD align="right" colspan="2">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    &nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
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
                            id="lk_novo" runat="server" AutoUpdateAfterCallBack="True">Novo</anthem:linkbutton>
 
                    </TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" DataKeyNames="id_coleta_amostra_manual">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" />
                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d." ReadOnly="True"
                                    SortExpression="cd_pessoa">
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado">
                                    <headerstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" ReadOnly="True"
                                    SortExpression="id_propriedade_matriz">
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta" SortExpression="nm_tipo_coleta_analise_esalq" />
                                <asp:BoundField DataField="ds_periodo_dias" HeaderText="Per&#237;odo" />
                                <asp:BoundField DataField="nm_situacao_coleta_amostra_manual" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao_coleta_amostra_manual" />
                                <asp:BoundField HeaderText="Rota" ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Caderneta" ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w6" CommandArgument='<%# Bind("id_coleta_amostra_manual") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Cancelar Amostra" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" __designer:wfdid="w7" CommandArgument='<%# Bind("id_coleta_amostra_manual") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente CANCELAR a amostra manual?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle horizontalalign="Center" width="5%" />
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_coleta_amostra_manual" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_coleta_amostra_manual" runat="server" Text='<%# Bind("id_situacao_coleta_amostra_manual") %>' __designer:wfdid="w25"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="dt_ini_amostra" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_dt_ini_amostra" runat="server" Text='<%# Bind("dt_ini_amostra") %>' __designer:wfdid="w229"></asp:Label>
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
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
