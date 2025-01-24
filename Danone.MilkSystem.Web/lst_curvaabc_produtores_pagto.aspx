<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_curvaabc_produtores_pagto.aspx.vb" Inherits="lst_curvaabc_produtores_pagto" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 Transitional//EN" >
<html>
	<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC Produtores Pagamento</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function table2_onclick() {

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


			<table id="table1" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><StrONG>Relatório Curva ABC Produtores Pagamento</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 4px;"></td>
					<td align="center" style="height: 4px" >
						</td>
					<td style="width: 10px; height: 4px;"></td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td valign="middle" background="img/faixa_filro.gif"></td>
					<td style="width: 10px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td id="td_pesquisa" runat="server" class="texto" ><br/>
						<table class="borda" id="table2" cellspacing="0" cellpadding="0" width="100%" >
							<tr>
								<td style="height: 3px; width: 15%" ></td>
								<td style="height: 3px; width: 35%"></td>
								<td style="height: 3px; width: 15%;"></td>
								<td style="height: 3px; "></td>
							</tr>

                            <tr>
                                <td align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:&nbsp;
                                </td>
                                <td style="HEIGHT: 22px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 22px; ">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:&nbsp;
                                </td>
                                <td style="height: 22px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_ini" runat="server" CssClass="texto" Width="88px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_coleta_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 22px; ">Código Produtor:&nbsp;
                                </td>
								<td style="height: 22px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
    	                        </td>
								<td align="right" style="height: 22px; ">
                                    <strong><span style="color: #ff0000">*</span></strong>Categoria:&nbsp;
                                </td>
								<td style="height: 22px; ">&nbsp;&nbsp;<asp:DropDownList ID="cbo_categoria_qualidade" runat="server" CssClass="Texto"
                                        Width="91px">
                                    </asp:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_categoria_qualidade"
                                        CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar." Font-Bold="True"
                                        ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
 							</tr>
 							
                            <tr>
                                <td align="right" style="height: 22px; ">Código Propriedade:&nbsp;
                                </td>
                                <td style="height: 22px; ">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
                                    </td>
 								<td style="HEIGHT: 22px; " align="right">
                                     Grupo:&nbsp;
                                 </td>
								<td style="HEIGHT: 22px; ">&nbsp;
                                    <asp:DropDownList ID="cbo_grupo" runat="server" CssClass="Texto">
                                    </asp:DropDownList>&nbsp;</td>
                           </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    Código Técnico Danone:&nbsp;</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                <td align="right" style="height: 22px; ">
                                     Tipo Pagamento:&nbsp;
                                </td>
                                <td style=" height: 22px; ">
                                    &nbsp;
                                    <asp:RadioButton ID="rb_st_tipo_pagto_d" runat="server" Checked="True"
                                        CssClass="texto" GroupName="pagto" Text="Definitivo" /><asp:RadioButton ID="rb_st_tipo_pagto_p"
                                            runat="server" CssClass="texto" GroupName="pagto" Text="Provisório" /></td>
                            </tr>
                          
							<tr>
							<td align="right" style="height: 24px">
                                Categoria Técnico:&nbsp;</td>
								<td align="left"  style="height: 24px">&nbsp;
                                    <anthem:DropDownList ID="cbo_categoria" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                        <asp:ListItem Value="D">Danone</asp:ListItem>
                                        <asp:ListItem Value="E">Educampo</asp:ListItem>
                                        <asp:ListItem Value="Q">Comquali</asp:ListItem>
                                        <asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList></td>
								<td align="right" style="height: 24px"  >
                                    &nbsp;<asp:CheckBox ID="chk_exportar_todas" runat="server" Text="Exportar Todas Categorias" /></td>
                                <td align="left" style="height: 24px">
                                    &nbsp;
                                </td>
							</tr>
                            <tr>
                                <td align="right" style="height: 30px">
                                </td>
                                <td align="left" style="height: 30px">
                                </td>
                                <td align="left" colspan="2" style="height: 30px" valign="bottom">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton></td>
                            </tr>
						</table>
					</td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 24px; width: 9px;">&nbsp;</td>
					<td class="faixafiltro1a" style="HEIGHT: 24px; " valign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</td>
					<td style="HEIGHT: 24px; width: 10px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 3px; width: 9px;"></td>
					<td valign="middle" style="height: 3px; ">&nbsp;</td>
					<td style="height: 3px; width: 10px;"></td>
				</tr>
				
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td valign="top"  >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="#000066">
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" Wrap="True" />
                            <Columns >
                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="PropMatriz" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Educampo" DataField="nm_tecnico_educampo" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ComQuali" DataField="nm_tecnico_comquali" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Danone" DataField="nm_tecnico_danone" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vol.">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_volume" __designer:dtid="281483566645284" runat="server"  AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" Text='<%# Bind("nr_volume") %>' __designer:wfdid="w65" ></anthem:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_categoria" HeaderText="Cat." />
                                <asp:TemplateField HeaderText="M1 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta1" runat="server" __designer:wfdid="w59"></asp:Label><br /><asp:Label id="lbl_ds_mes1_coleta1" runat="server" Text="1ª Col." __designer:wfdid="w60"></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nr_valor_esalq_ref2_1") %>' __designer:wfdid="w21" ></anthem:Label><br /><br /><anthem:Label id="lbl_nr_m1_recoleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref2_11") %>' __designer:wfdid="w34" ForeColor="#000066"></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M1 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta2" runat="server" __designer:wfdid="w63"></asp:Label><br /><asp:Label id="lbl_ds_mes1_coleta2" runat="server" Text="2ª Col." __designer:wfdid="w64"></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nr_valor_esalq_ref2_2") %>' __designer:wfdid="w61">---</anthem:Label> <br /><br /><anthem:Label id="lbl_nr_m1_recoleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref2_12") %>' __designer:wfdid="w62">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M1 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes1_coleta3" runat="server" __designer:wfdid="w20"></asp:Label><br /><asp:Label id="lbl_ds_mes1_coleta3" runat="server" __designer:wfdid="w21" Text="3ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nr_valor_esalq_ref2_3") %>' __designer:wfdid="w29">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m1_recoleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref2_13") %>' __designer:wfdid="w32">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>
<asp:TemplateField HeaderText="M1 - 4&#170; Coleta">
    <headertemplate>
<asp:Label id="lbl_mes1_coleta4" runat="server" __designer:wfdid="w22"></asp:Label><br /><asp:Label id="lbl_ds_mes1_coleta4" runat="server" Text="4ª Col." __designer:wfdid="w23"></asp:Label> 
</headertemplate>
<itemtemplate>
<anthem:Label id="lbl_nr_m1_coleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref2_4") %>' __designer:wfdid="w20"></anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m1_recoleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref2_14") %>' __designer:wfdid="w21"></anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Recol.">
                                    <headertemplate>
<asp:Label id="lbl_mes1_recoleta" runat="server" __designer:wfdid="w40"></asp:Label><br /><asp:Label id="lbl_ds_mes1_recoleta" runat="server" Text="Recol." __designer:wfdid="w41"></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m1_st_recoleta_N" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w38">N</anthem:Label><br /><br /><anthem:Label id="lbl_m1_st_recoleta_S" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w39">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta1" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes2_coleta1" runat="server" __designer:wfdid="w25" Text="1ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref1_1") %>' __designer:wfdid="w5">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m2_recoleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref1_11") %>' __designer:wfdid="w34">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta2" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes2_coleta2" runat="server" __designer:wfdid="w25" Text="2ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref1_2") %>' __designer:wfdid="w33">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m2_recoleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref1_12") %>' __designer:wfdid="w36">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M2 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes2_coleta3" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes2_coleta3" runat="server" __designer:wfdid="w25" Text="3ª Col."></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref1_3") %>' __designer:wfdid="w35">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m2_recoleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref1_13") %>' __designer:wfdid="w38">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
<asp:TemplateField HeaderText="M2 - 4&#170; Coleta">
    <headertemplate>
<asp:Label id="lbl_mes2_coleta4" runat="server" __designer:wfdid="w17"></asp:Label><br /><asp:Label id="lbl_ds_mes2_coleta4" runat="server" Text="4ª Col." __designer:wfdid="w18"></asp:Label> 
</headertemplate>
<itemtemplate>
<anthem:Label id="lbl_nr_m2_coleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref1_4") %>' __designer:wfdid="w15"></anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m2_recoleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref2_14") %>' __designer:wfdid="w16"></anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>                                
                                  <asp:TemplateField HeaderText="Recol.">
        <headertemplate>
<asp:Label id="lbl_mes2_recoleta" runat="server" __designer:wfdid="w34"></asp:Label><br /><asp:Label id="lbl_ds_mes2_recoleta" runat="server" __designer:wfdid="w35" Text="Recol."></asp:Label> 
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m2_st_recoleta_N" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w21">N</anthem:Label><br /><br /><anthem:Label id="lbl_m2_st_recoleta_S" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w22">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 1&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta1" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes3_coleta1" runat="server" __designer:wfdid="w25" Text="1ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_1") %>' __designer:wfdid="w37">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m3_recoleta1" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref_11") %>' __designer:wfdid="w40">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 2&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta2" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes3_coleta2" runat="server" __designer:wfdid="w25" Text="2ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"  Text='<%# bind("nr_valor_esalq_ref_2") %>' __designer:wfdid="w39">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m3_recoleta2" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref_12") %>' __designer:wfdid="w42">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M3 - 3&#170; Coleta">
                                    <headertemplate>
<asp:Label id="lbl_mes3_coleta3" runat="server" __designer:wfdid="w24"></asp:Label><br /><asp:Label id="lbl_ds_mes3_coleta3" runat="server" __designer:wfdid="w25" Text="3ª Col."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_esalq_ref_3") %>' __designer:wfdid="w41">---</anthem:Label> <br /><br />
<anthem:Label id="lbl_nr_m3_recoleta3" __designer:dtid="281483566645274" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text='<%# bind("nr_valor_esalq_ref_13") %>' __designer:wfdid="w44">---</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
<asp:TemplateField HeaderText="M3 - 4&#170; Coleta">
    <headertemplate>
<asp:Label id="lbl_mes3_coleta4" runat="server"></asp:Label><br /><asp:Label id="lbl_ds_mes3_coleta4" runat="server" Text="4ª Col."></asp:Label>
</headertemplate>
<itemtemplate>
<anthem:Label id="lbl_nr_m3_coleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"  Text='<%# bind("nr_valor_esalq_ref_4") %>'>---</anthem:Label> <br /><br /><anthem:Label id="lbl_nr_m3_recoleta4" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False"  Text='<%# bind("nr_valor_esalq_ref_14") %>'>---</anthem:Label> 
</itemtemplate>
                                    <headerstyle wrap="False" horizontalalign="Center" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" wrap="True" />
                                </asp:TemplateField>                                
  <asp:TemplateField HeaderText="Recol.">
        <headertemplate>
<asp:Label id="lbl_mes3_recoleta" runat="server"></asp:Label><br /><asp:Label id="lbl_ds_mes3_recoleta" runat="server" Text="Recol."></asp:Label>
</headertemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_m3_st_recoleta_N" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w19">N</anthem:Label><br /><br /><anthem:Label id="lbl_m3_st_recoleta_S" runat="server"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w20">S</anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" wrap="False" verticalalign="Middle" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Teor">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_teor" __designer:dtid="281483566645284" runat="server"  AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" __designer:wfdid="w7" Text='<%# Bind("nr_teor") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B&#244;nus/Desc.">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_bonus" __designer:dtid="281483566645284" runat="server"  AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" Text='<%# Bind("nr_bonus_desconto") %>' __designer:wfdid="w13"></anthem:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_id_propriedade" __designer:dtid="281483566645284" runat="server"  AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" __designer:wfdid="w37" Text='<%# Bind("id_propriedade") %>'></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Compliance">
                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ds_teor_complience") %>' __designer:wfdid="w16"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_complience" runat="server" Text='<%# Bind("ds_teor_complience") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_total_qualidade" HeaderText="Total Qualidade">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_qualidade_volume" HeaderText="Total Qualidade x Volume">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compliance Geral">
                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("nr_total_complience") %>' __designer:wfdid="w19"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_complience_geral" runat="server" Text='<%# Bind("nr_total_complience") %>' __designer:wfdid="w18"></asp:Label>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                                        </anthem:GridView>
										</td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;">&nbsp;</td>
					<td valign="top" style="height: 19px; ">&nbsp;
					</td>
					<td style="height: 19px; width: 10px;">&nbsp;</td>
				</tr>
			</table>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
