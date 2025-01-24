<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_sif.aspx.vb" Inherits="lst_relatorio_sif" %>

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
		<title>Report SIF</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>REPORT SIF</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 4px;"></TD>
					<TD align="center" style="height: 4px" >
						</TD>
					<TD style="width: 10px; height: 4px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px;"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD  align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:</td>
                                <TD >
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência para continuar."
                                        Font-Bold="True" ValidationGroup="vg_filtro">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" >
                                    Estado:</td>
                                <td >
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                       
                            </tr>
 							
                            <tr >
                                <td align="right" style="height: 20px; ">
                                    Período Dias da Referêcia:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<cc4:OnlyNumbersTextBox ID="txt_nr_dia_ini" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="2" Width="40px"></cc4:OnlyNumbersTextBox>
                                    (dd) à
                                    <cc4:OnlyNumbersTextBox ID="txt_nr_dia_fim" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="2" Width="40px"></cc4:OnlyNumbersTextBox>
                                    (dd)
                                    <asp:RangeValidator ID="rv_dia_ini" runat="server" ControlToValidate="txt_nr_dia_ini"
                                        ErrorMessage="O Dia da Referência inicial deve estar entre 1 e 31." MaximumValue="31"
                                        MinimumValue="1" Type="Integer" ValidationGroup="vg_filtro" Display="Dynamic">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="rv_dia_fim" runat="server" ControlToValidate="txt_nr_dia_fim" ErrorMessage="O Dia da Referência final deve estar entre 1 e 31."
                                            MaximumValue="31" MinimumValue="1" Type="Integer" ValidationGroup="vg_filtro" Display="Dynamic">[!]</asp:RangeValidator><asp:CompareValidator
                                                ID="cpv_dia" runat="server" ControlToCompare="txt_nr_dia_ini" ControlToValidate="txt_nr_dia_fim"
                                                ErrorMessage="O Dia Final da Referêcia informado deve ser maior ou igual ao dia inicio."
                                                Operator="GreaterThanEqual" Type="Integer" ValidationGroup="vg_filtro" Display="Dynamic">[!]</asp:CompareValidator></td>
 								<TD style="HEIGHT: 20px; " align="right">
                                    Cidade:</TD>
								<TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_cidade" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="200" Width="90%"></anthem:TextBox></TD>
                           </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 26px">
                                     Grupo:</td>
								<TD align="left" style="height: 26px">&nbsp;
                                    <anthem:DropDownList ID="cbo_Grupo" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></TD>
								<TD align="right" style="height: 26px">
                                    Tipo Report SIF:</TD>
                                <td align="left" style="height: 26px">
                                    &nbsp;
                                    <anthem:RadioButtonList ID="opt_tipo_relatorio" runat="server" AutoPostBack="True"
                                        CssClass="texto" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <Items>
                                            <asp:ListItem Selected="True" Value="A">Anal&#237;tico</asp:ListItem>
                                            <asp:ListItem Value="S">Sint&#233;tico</asp:ListItem>
                                        </Items>
                                    </anthem:RadioButtonList></td>
							</tr>
                            <tr>
                                <td align="right" colspan="1">
                                </td>
                                <td align="left" colspan="2">
                                </td>
                                <td align="center">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_filtro"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_filtro" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</td>
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
                <tr>
                    <TD style="height: 5px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 5px; ">
                        &nbsp;<anthem:Label ID="lbl_informativo" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Font-Italic="True" Font-Size="XX-Small" ForeColor="Red" UpdateAfterCallBack="True">*Nesta tela serão exibidos apenas os últimos 12 dias do filtro de pesquisa. Ao EXPORTAR, todos os dias da referência ou os dias informados no filtro de pesquisa serão visualizados.</anthem:Label></td>
                    <TD style="height: 5px; width: 10px;">
                    </td>
                </tr>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" >
                        <anthem:GridView ID="gridResults" runat="server" AutoUpdateAfterCallBack="True" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small"
                            PageSize="15" UpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" /> </anthem:GridView><anthem:GridView ID="gridResultsCoop" runat="server" AutoUpdateAfterCallBack="True" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small"
                            PageSize="15" UpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True">
                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <RowStyle ForeColor="#000066" />
                            </anthem:GridView>
                                            <anthem:GridView ID="gridResultsSintetico" runat="server"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small"
                            PageSize="15" UpdateAfterCallBack="True" Width="80%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" HorizontalAlign="Center">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                                <Columns >
                                    <asp:TemplateField HeaderText="Refer&#234;ncia">
                                        <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" __designer:wfdid="w17"></asp:Label> 
</itemtemplate>
                                        <headerstyle horizontalalign="Center" />
                                        <itemstyle horizontalalign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="cd_uf" HeaderText="UF">
                                        <headerstyle horizontalalign="Center" />
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nm_cidade" HeaderText="Cidade">
                                        <headerstyle horizontalalign="Left" />
                                        <itemstyle horizontalalign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_produtores" HeaderText="Total Produtores">
                                        <headerstyle horizontalalign="Center" />
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Total Volume">
                                        <itemtemplate>
<asp:Label id="lbl_nr_volume" runat="server" __designer:wfdid="w18" Text='<%# Bind("nr_volume") %>'></asp:Label> 
</itemtemplate>
                                        <headerstyle horizontalalign="Center" />
                                        <itemstyle font-italic="False" horizontalalign="Center" wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" /> </anthem:GridView>
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
                ShowSummary="False" ValidationGroup="vg_filtro"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
