<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_curvaabc_in76.aspx.vb" Inherits="lst_curvaabc_in76" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC - IN76 Desligamento</title>
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
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        //if (idcboestabel == "0")
        //{
        //   alert("O estabelecimento deve ser informado!");
        //}
        //else
        {
   	        //szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
   	        szUrl = 'lupa_produtor.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogPropriedade() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
        var cd_pessoa=document.getElementById("txt_cd_pessoa").value;
   	     
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        //if (idcboestabel == "0")
        //{
        //    alert("O estabelecimento deve ser informado!");
        //}
        //else
        {
   	        
            //szUrl = 'lupa_propriedade.aspx?id_estabelecimento='+idcboestabel+'&cd_pessoa='+cd_pessoa+'';
            szUrl = 'lupa_propriedade.aspx?&cd_pessoa='+cd_pessoa+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_propriedade.value=retorno;
            } 
        }
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Curva ABC - IN76 77 Desligamento</STRONG></TD>
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
					<TD id="td_pesquisa" runat="server" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_ini" runat="server" CssClass="texto" Width="80px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_coleta_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                       
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">Código Produtor:</td>
								<td style="height: 20px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="texto" Width="80px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
    	                        </td>
								<TD align="right" style="height: 20px;">
                                    Código Propriedade:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="texto" Width="80px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" /><anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
 							</tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Grupo:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_Grupo" runat="server" CssClass="texto">
                                    </asp:DropDownList></td>
                                 <td align="right">
                                     Tipo Propriedade:</td><td>
                                     &nbsp;
                                     <anthem:DropDownList ID="cbo_tipo_propriedade" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                         <asp:ListItem Value="M">Matriz</asp:ListItem>
                                         <asp:ListItem Value="U">&#218;nica</asp:ListItem>
                                         <asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
                                     </anthem:DropDownList></td>
                            </tr>
 							
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Categoria Técnico:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                        <asp:ListItem Value="D">Danone</asp:ListItem>
                                        <asp:ListItem Value="E">Educampo</asp:ListItem>
                                        <asp:ListItem Value="Q">Comquali</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList>
                                    &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                    </td>
 								<TD style="HEIGHT: 20px; " align="right">
                                     Situações Relatório:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <anthem:DropDownList ID="cbo_situacoes" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                        <asp:ListItem Value="C">Cr&#237;tico</asp:ListItem>
                                        <asp:ListItem Value="D">Dispensar</asp:ListItem>
                                        <asp:ListItem Value="SA">Sem An&#225;lise</asp:ListItem>
                                        <asp:ListItem Selected="True">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList></TD>
                           </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 20px">
                                    Técnico Danone:</td>
								<TD align="left" colspan="2" style="height: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="1" style="height: 3px">
                                </td>
                                <td align="left" colspan="2" style="height: 3px">
                                </td>
                                <td align="right" style="height: 3px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
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
					<TD >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" SortExpression="nm_estabelecimento" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="ds_propriedade" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" SortExpression="nm_pessoa" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipopropriedade" HeaderText="Tipo" SortExpression="tipopropriedade" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume" ReadOnly="True" DataField="nr_volume" >
                                    <itemstyle wrap="False" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal2" runat="server" __designer:wfdid="w32"></asp:Label><BR />Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm2" runat="server" __designer:wfdid="w66" Text='<%# Bind("nr_teor_cbt2") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="MistyRose" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl2" >
                                    <itemstyle backcolor="MistyRose" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal1" runat="server"  __designer:wfdid="w22"></asp:Label><BR />Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm1" runat="server" Text='<%# Bind("nr_teor_cbt1") %>' __designer:wfdid="w18"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="PaleTurquoise" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl1" >
                                    <itemstyle backcolor="PaleTurquoise" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_trimestre">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal" runat="server"  __designer:wfdid="w20"></asp:Label><BR />Trim. CBT 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm" runat="server" Text='<%# Bind("nr_teor_cbt") %>' __designer:wfdid="w20"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#CCCCFF" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl" >
                                    <itemstyle backcolor="#CCCCFF" font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Amostra">
                                    <headertemplate>
<asp:Label id="lbl_menor_amostra_mes" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>' __designer:wfdid="w35"></asp:Label><BR />Amostra 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_menoresalq" runat="server" Text='<%# Bind("nr_valor_menor_esalq_cbt") %>' __designer:wfdid="w34"></asp:Label> 
</itemtemplate>
                                    <itemstyle backcolor="LightCyan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Compl" DataField="ds_compl_analise" >
                                    <itemstyle backcolor="LightCyan" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="A&#231;&#227;o" DataField="dsacao" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nrcomplcbt" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt" runat="server" __designer:wfdid="w69" Text='<%# Bind("nrcomplcbt") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nrcomplcbt1" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt1" runat="server" __designer:wfdid="w60" Text='<%# Bind("nrcomplcbt1") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nrcomplcbt2" Visible="False">
                                    <itemtemplate>
<asp:Label id="nrcomplcbt2" runat="server" __designer:wfdid="w67" Text='<%# Bind("nrcomplcbt2") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nranalisecomplcbt" Visible="False">
                                    <itemtemplate>
<asp:Label id="nranalisecomplcbt" runat="server" __designer:wfdid="w70" Text='<%# Bind("nranalisecomplcbt") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" /><HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top"  >&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
