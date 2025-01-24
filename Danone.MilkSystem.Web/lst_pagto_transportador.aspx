<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_pagto_transportador.aspx.vb" Inherits="lst_pagto_transportador" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Pagamentos de Frete ao Transportador</title>
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

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");

        szUrl = 'lupa_transportador_cooperativa.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_transportador.value=retorno;
        } 
    }             
</script>


		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Pagamentos de Frete ao Transportador</STRONG></TD>
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
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Pagto:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_pagto_ini" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_pagto_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_pagto_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Período Pagto para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    Cód.SAP Transportador:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_sap" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True" MaxLength="10"></anthem:TextBox></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 25px; ">Código Transportador:</td>
								<td style="height: 25px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_transportador" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_transportador" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;<anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                        Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_pesquisar"></anthem:CustomValidator>&nbsp; &nbsp;
    	                        </td>
								<TD align="right" style="height: 25px;">
                                    Situação:</TD>
								<TD style="height: 25px">&nbsp;&nbsp;<asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
 							</tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;&nbsp; &nbsp;</TD>
							</tr>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" SortExpression="ds_transportador" />
                                <asp:BoundField DataField="dt_pagto" HeaderText="Dt Pagto" SortExpression="dt_pagto" />
                                <asp:BoundField DataField="dt_emissao" HeaderText="Dt Emiss&#227;o" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_frete" HeaderText="Valor" />
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="Cd SAP" SortExpression="cd_codigo_sap" />
                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                <asp:TemplateField HeaderText="Exportado">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
&nbsp;<anthem:Image id="img_st_exportacao" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w19"></anthem:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_exportacao" HeaderText="Dt Exporta&#231;&#227;o" />
                                <asp:TemplateField>
                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_pagto_transportador") %>' CommandName="delete" __designer:wfdid="w20"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_exportacao" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_st_exportacao" runat="server" __designer:wfdid="w18" Text='<%# Bind("st_exportacao") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_pagto_transportador" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_pagto_transportador" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_pagto_transportador") %>'></asp:Label> 
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
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
                            &nbsp;
        </div>
		</form>
	</body>
</HTML>
