<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_curvaabc_overview_qualidade.aspx.vb" Inherits="lst_curvaabc_overview_qualidade" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC - OverView Quality</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Curva ABC - OverView Quality</STRONG></TD>
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
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>


                                         
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
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
				    <TD vAlign="middle" style="height: 19px; ">
                        <anthem:GridView ID="gridCBT" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridCCS" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridProteina" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView><anthem:GridView ID="gridGordura" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="60%" UpdateAfterCallBack="True" PageSize="5" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ShowHeader="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                            <Columns>
                                <asp:TemplateField HeaderText="Categoria">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w4"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_categoria" runat="server" Text='<%# Bind("ds_categoria") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_faixa" HeaderText="Faixa" >
                                    <headerstyle horizontalalign="Center" width="20%" />
                                    <itemstyle horizontalalign="Center" width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Inicial" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_ini" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_ini") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faixa Final" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_faixa_fim" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_faixa_fim") %>'></asp:Label>
</itemtemplate>
                                    <itemstyle width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Mensal">
                                    <itemtemplate>
<asp:Label id="lbl_geral_mensal" runat="server" __designer:wfdid="w8" Text='<%# Bind("nr_volume_faixa") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Trimestral">
                                    <itemtemplate>
<asp:Label id="lbl_geral_trimestral" runat="server" __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Com Educampo">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_educampo" runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Educampo">
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_educampo" runat="server" __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral com Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_com_comquali" runat="server" __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Geral Sem Comquali">
                                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" __designer:wfdid="w5"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_geral_sem_comquali" runat="server" __designer:wfdid="w4"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        
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
                        &nbsp;</TD>
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
