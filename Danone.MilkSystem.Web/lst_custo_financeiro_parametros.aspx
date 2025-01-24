<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_custo_financeiro_parametros.aspx.vb" Inherits="lst_custo_financeiro_parametros" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Flash Financeiro</title>
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

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Custo Financeiro - Parâmetros</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 28px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 28px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Ano Referência:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;&nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_ano_referencia" runat="server" CssClass="texto"
                                        Width="72px"></cc4:OnlyNumbersTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano_referencia"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="True" ValidationGroup="vg_flash">[!]</asp:RequiredFieldValidator><asp:RangeValidator
                                            ID="RangeValidator1" runat="server" ControlToValidate="txt_ano_referencia" ErrorMessage="Ano de Referência com formato incorreto."
                                            MaximumValue="2100" MinimumValue="2000" Type="Integer" ValidationGroup="vg_flash" ToolTip="Ano de Referência com formato incorreto.">[!]</asp:RangeValidator></td>
                                <td align="right" style="height: 20px">
                                    Tipo Custo Financeiro:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo_custo_financeiro" runat="server" CssClass="texto">
                                    </anthem:DropDownList>&nbsp;
                                </td>
                                       
                            </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 26px">
                                    </td>
								<TD align="left" colspan="2" style="height: 26px">&nbsp;
                                    </TD>
								<TD align="right" style="height: 26px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_flash"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_flash" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
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
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server">Novo</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px; ">
                        &nbsp;</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
				
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD  >
									
                        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"  GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"
                             UpdateAfterCallBack="True" PageSize="100" DataKeyNames="id_custo_financeiro">
                            <Columns>
                                 <asp:BoundField DataField="st_sistema" HeaderText="Obrig." ReadOnly="True"  >
                                     <itemstyle horizontalalign="Center" />
                                 </asp:BoundField>
                               <asp:BoundField DataField="nm_tipo_custo_financeiro" HeaderText="Tipo Custo" />
                                <asp:BoundField DataField="nr_valor_01" HeaderText="Janeiro" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_02" HeaderText="Fevereiro" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_03" HeaderText="Mar&#231;o" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_04" HeaderText="Abril" DataFormatString="{0:N4}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Maio" ReadOnly="True" DataField="nr_valor_05" DataFormatString="{0:N4}" >
                                    <itemstyle wrap="False" horizontalalign="Right"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_06" HeaderText="Junho" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_07" HeaderText="Julho" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_08" HeaderText="Agosto" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_09" HeaderText="Setembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_10" HeaderText="Outubro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_11" HeaderText="Novembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_12" HeaderText="Dezembro" DataFormatString="{0:N4}">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar.gif" Text='<%# Eval("nr_ano") %>' __designer:wfdid="w96" CausesValidation="False" CommandName="edit" CommandArgument='<%# bind("nr_ano") %>'></asp:ImageButton>
</itemtemplate>
                                    <itemstyle horizontalalign="Center" width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_custo_financeiro" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_custo_financeiro" runat="server" Text='<%# Bind("id_tipo_custo_financeiro") %>' __designer:wfdid="w93"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </anthem:GridView>
 </TD>
					<TD style="width: 10px; ">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top"  >&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_flash"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;&nbsp;
        </div>
		</form>
	</body>
</HTML>
