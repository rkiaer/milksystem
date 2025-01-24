<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_curvaabc_kpi_qualidade.aspx.vb" Inherits="lst_curvaabc_kpi_qualidade" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Curva ABC - KPI Qualidade</STRONG></TD>
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
                                    <strong><span style="color: #ff0000">*</span></strong>Ano:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_ano" runat="server" CssClass="texto" Width="75px" MaxLength="4"></cc4:OnlyNumbersTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano"
                                        CssClass="texto" ErrorMessage="Preencha o campo Ano para continuar."
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
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
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
					<TD vAlign="middle" style="height: 19px; " align="center">&nbsp;<anthem:GridView ID="gridVolumeTotalComplience" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="% Volume total Compliance">
                                <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w39"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w1" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                <headerstyle width="20%" />
                                <itemstyle horizontalalign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JAN">
                                <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w42"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEV">
                                <edititemtemplate>
&nbsp;
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w43"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAR">
                                <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABR">
                                <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAI">
                                <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>'  __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUN">
                                <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUL">
                                <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGO">
                                <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w3"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SET">
                                <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w5"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_set" runat="server" __designer:wfdid="w4" Text='<%# bind("nrset") %>'></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OUT">
                                <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w7"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOV">
                                <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEZ">
                                <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M&#233;dia Anual">
                                <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w9"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <RowStyle ForeColor="#000066" />
                    </anthem:GridView>
                        &nbsp;
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>


				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center">
                        <anthem:GridView ID="gridCCSMensal" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="CCS M&#233;dia ponderada Mensal">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w3"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                                        </anthem:GridView>
                        &nbsp; &nbsp;&nbsp;
                                        
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; " align="center"><anthem:GridView ID="gridCCSTrimestral" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="CCS M&#233;dia ponderada Trimestral">
                                <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w4" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                <headerstyle width="20%" />
                                <itemstyle horizontalalign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JAN">
                                <edititemtemplate>
&nbsp;
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEV">
                                <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAR">
                                <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABR">
                                <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAI">
                                <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUN">
                                <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUL">
                                <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGO">
                                <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SET">
                                <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OUT">
                                <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOV">
                                <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEZ">
                                <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M&#233;dia Anual">
                                <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w6"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <RowStyle ForeColor="#000066" />
                    </anthem:GridView>
                        &nbsp;
                        &nbsp; &nbsp;&nbsp;
                                        
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; " align="center"><anthem:GridView ID="gridCBTMensal" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                        <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="CBT M&#233;dia ponderada Mensal">
                                <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w7" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                <headerstyle width="20%" />
                                <itemstyle horizontalalign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JAN">
                                <edititemtemplate>
&nbsp;
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEV">
                                <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAR">
                                <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ABR">
                                <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAI">
                                <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUN">
                                <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUL">
                                <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGO">
                                <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SET">
                                <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OUT">
                                <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOV">
                                <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEZ">
                                <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M&#233;dia Anual">
                                <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w9"></asp:TextBox>
</edititemtemplate>
                                <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <RowStyle ForeColor="#000066" />
                    </anthem:GridView>
                    </TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center" >
                        <anthem:GridView ID="gridCBTTrimestral" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="CBT M&#233;dia ponderada Trimestral">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w10" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w62"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' __designer:wfdid="w60"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" __designer:wfdid="w65"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server" __designer:wfdid="w68"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' __designer:wfdid="w66"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' __designer:wfdid="w69"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" __designer:wfdid="w74"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server" __designer:wfdid="w77"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server" __designer:wfdid="w80"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server" __designer:wfdid="w83"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' __designer:wfdid="w81"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server" __designer:wfdid="w86"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server" __designer:wfdid="w89"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' __designer:wfdid="w87"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w12"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                    </TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px; height: 177px;">&nbsp;</TD>
					<TD align="center" style="height: 177px" >
                        <anthem:GridView ID="gridProteinaMensal" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Prote&#237;na M&#233;dia ponderada Mensal">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w13" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server"  Text='<%# Bind("nrset") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server"  Text='<%# Bind("nrout") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server"  Text='<%# Bind("nrnov") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server"  Text='<%# Bind("nrdez") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w15"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w14"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                    </TD>
					<TD style="width: 10px; height: 177px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center" >
                        <anthem:GridView ID="gridGorduraMensal" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Gordura M&#233;dia ponderada Mensal">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("nr_ano") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" __designer:wfdid="w16" Text='<%# Bind("nr_ano") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# Bind("nrjan") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# Bind("nrfev") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# Bind("nrmar") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# Bind("nrabr") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <edititemtemplate>
<asp:TextBox id="TextBox6" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# Bind("nrmai") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <edititemtemplate>
<asp:TextBox id="TextBox7" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# Bind("nrjun") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# Bind("nrjul") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <edititemtemplate>
<asp:TextBox id="TextBox9" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# Bind("nrago") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
<asp:TextBox id="TextBox10" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# Bind("nrset") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <edititemtemplate>
<asp:TextBox id="TextBox11" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# Bind("nrout") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <edititemtemplate>
<asp:TextBox id="TextBox12" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# Bind("nrnov") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <edititemtemplate>
<asp:TextBox id="TextBox13" runat="server"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# Bind("nrdez") %>' ></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w18"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# Bind("nrmediaanual") %>' __designer:wfdid="w17"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        &nbsp;
                    </TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px; height: 177px;">&nbsp;</TD>
					<TD align="center" style="height: 177px" >
                        <anthem:GridView ID="gridVolumeRejeitado" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="% Rejei&#231;&#227;o ATB">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w49"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w51"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w53"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# bind("nrmai") %>' __designer:wfdid="w55"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w59"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w61"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# bind("nrset") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# bind("nrout") %>' __designer:wfdid="w65"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w70"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Seq" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w23"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        &nbsp;
                    </TD>
					<TD style="width: 10px; height: 177px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center" >
                        <anthem:GridView ID="gridTracadoControlado" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="90%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Ano">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <headertemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w86"></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_ano" runat="server" Text='<%# Bind("nr_ano") %>' __designer:wfdid="w106"></asp:Label> 
</itemtemplate>
                                    <headerstyle width="20%" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JAN">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jan" runat="server" Text='<%# bind("nrjan") %>' __designer:wfdid="w80"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FEV">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_fev" runat="server" Text='<%# bind("nrfev") %>' __designer:wfdid="w88"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAR">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mar" runat="server" Text='<%# bind("nrmar") %>' __designer:wfdid="w90"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ABR">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_abr" runat="server" Text='<%# bind("nrabr") %>' __designer:wfdid="w92"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAI">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_mai" runat="server" Text='<%# bind("nrmai") %>' __designer:wfdid="w94"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUN">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_jun" runat="server" Text='<%# bind("nrjun") %>' __designer:wfdid="w96"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUL">
                                    <itemtemplate>
<asp:Label id="lbl_jul" runat="server" Text='<%# bind("nrjul") %>' __designer:wfdid="w98"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGO">
                                    <itemtemplate>
<asp:Label id="lbl_ago" runat="server" Text='<%# bind("nrago") %>' __designer:wfdid="w100"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SET">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_set" runat="server" Text='<%# bind("nrset") %>' __designer:wfdid="w102"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OUT">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_out" runat="server" Text='<%# bind("nrout") %>' __designer:wfdid="w104"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOV">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nov" runat="server" Text='<%# bind("nrnov") %>' __designer:wfdid="w107"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEZ">
                                    <itemtemplate>
<asp:Label id="lbl_dez" runat="server" Text='<%# bind("nrdez") %>' __designer:wfdid="w109"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Seq" Visible="False">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w112"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w111"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M&#233;dia Anual">
                                    <itemtemplate>
<asp:Label id="lbl_media_anual" runat="server" Text='<%# bind("nrmediaanual") %>' __designer:wfdid="w26"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        &nbsp;
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
        </div>
		</form>
	</body>
</HTML>
