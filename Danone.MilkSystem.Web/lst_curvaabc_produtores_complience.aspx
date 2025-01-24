<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_curvaabc_produtores_complience.aspx.vb" Inherits="lst_curvaabc_produtores_complience" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC - Produtores Compliance</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Curva ABC - Pagamento Compliance</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" >
						</TD>
					<TD style="width: 10px"></TD>
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
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_ini" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_coleta_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">Código Produtor:</td>
								<td style="height: 20px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
    	                        </td>
								<TD align="right" style="height: 20px;">
                                    Código Propriedade:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" /><anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
 							</tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Grupo:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_Grupo" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
 							
                            <tr>
                                <td align="right" style="height: 6px; "></td>
                                <td style="height: 6px; ">
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                    </td>
 								<TD style="HEIGHT: 6px; " align="right"></TD>
								<TD style="HEIGHT: 6px">&nbsp;
                                    </TD>
                           </tr>
                          
							<tr>
								<TD align="right" colspan="3">
                                    </TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="3">
                                </td>
                                <td align="right">
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
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; ">
                        <anthem:GridView ID="gridComplienceSintetico" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("ds_categoria") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" __designer:wfdid="w51" Text='<%# Bind("ds_categoria") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume COMPL" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_complience" runat="server" __designer:wfdid="w48" Text='<%# Bind("nr_volume_complience") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume COMPL %">
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_complience_perc" runat="server" __designer:wfdid="w28"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume NCOMPL" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_ncompl" runat="server" __designer:wfdid="w38"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume NCOMPL %">
                                    <itemtemplate>
<asp:Label id="lbl_nr_volume_ncompl_perc" runat="server" __designer:wfdid="w41"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="N.o Prod. COMPL">
                                    <itemtemplate>
<asp:Label id="lbl_nr_produtores_complience" runat="server" __designer:wfdid="w29" Text='<%# Bind("nr_produtores_complience") %>'></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="N.o Prod. COMPL %" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_produtores_complience_perc" runat="server" __designer:wfdid="w30"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="N. Prod. NCOMPL">
                                    <itemtemplate>
<asp:Label id="lbl_nr_produtores_ncompl" runat="server" __designer:wfdid="w35"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="N.o Pord. NCOMPL %" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_produtores_ncompl_perc" runat="server" __designer:wfdid="w31"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M. Ponderada Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_nr_media_geo_mensal" runat="server" __designer:wfdid="w44"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M. Ponderada Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_nr_media_geo_trimestral" runat="server" __designer:wfdid="w46"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                                        </anthem:GridView>
                         <anthem:Label ID="lbl_media_geometrica" runat="server" CssClass="texto" Font-Italic="True" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">CCS¹ e CBT¹- Média geométrica</anthem:Label>&nbsp;&nbsp;&nbsp;<anthem:Label ID="lbl_media_linear" runat="server" CssClass="texto" Font-Italic="True" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">MG² e Prot²- Média linear</anthem:Label>
                                        
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
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
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" SortExpression="nm_estabelecimento" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" SortExpression="ds_propriedade" />
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" SortExpression="nm_pessoa" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="PropMatriz" SortExpression="id_propriedade_matriz" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" />
                                <asp:BoundField HeaderText="Volume" ReadOnly="True" DataField="nr_volume" >
                                    <itemstyle wrap="False" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>' __designer:wfdid="w29"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal2" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_teor_ctm_mensal2") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal1" runat="server" Text='<%# Bind("nr_teor_ctm_mensal1") %>' __designer:wfdid="w17"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal1" runat="server" Text='<%# Bind("nr_teor_ctm_mensal1") %>' __designer:wfdid="w16"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ctm_mensal">
                                    <headertemplate>
<asp:Label id="lbl_teor_ctm_mensal" runat="server" Text='<%# Bind("nr_teor_ctm_mensal") %>' __designer:wfdid="w34"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ctm_mensal" runat="server" Text='<%# Bind("nr_teor_ctm_mensal") %>' __designer:wfdid="w33"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_teor_ctm" HeaderText="Teor CBT Trim." >
                                    <itemstyle backcolor="Tan" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_ctm_complience" HeaderText="Compliance CBT" >
                                    <itemstyle backcolor="Tan" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal2">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal2") %>' __designer:wfdid="w45"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal2" runat="server" Text='<%# Bind("nr_teor_ccs_mensal2") %>' __designer:wfdid="w44"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal1">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal1" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>' __designer:wfdid="w47"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal1" runat="server" Text='<%# Bind("nr_teor_ccs_mensal1") %>' __designer:wfdid="w46"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_teor_ccs_mensal">
                                    <headertemplate>
<asp:Label id="lbl_teor_ccs_mensal" runat="server" Text='<%# Bind("nr_teor_ccs_mensal") %>' __designer:wfdid="w49"></asp:Label>
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_teor_ccs_mensal" runat="server" Text='<%# Bind("nr_teor_ccs_mensal") %>' __designer:wfdid="w48"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_teor_ccs" HeaderText="Teor CCS Trim." >
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_ccs_complience" HeaderText="Compliance CCS" >
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_proteina" HeaderText="Teor Prot." >
                                    <itemstyle backcolor="#C0C0FF" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_proteina_complience" HeaderText="Compliance Prot " >
                                    <itemstyle backcolor="#C0C0FF" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_gordura" HeaderText="Teor Gordura" >
                                    <itemstyle backcolor="#FFE0C0" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_teor_gordura_complience" HeaderText="Compliance Gord." >
                                    <itemstyle backcolor="#FFE0C0" horizontalalign="Center" />
                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
