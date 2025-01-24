<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_tabela_frete_aprovar_2N.aspx.vb" Inherits="lst_frete_tabela_frete_aprovar_2N" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
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
		<title>Aprovar Tabela de Frete 2o Nível</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	


		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Tabela de Frete 2.o Nível</STRONG></TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px; " vAlign="middle" background="img/faixa_filro.gif" align="right" class="faixafiltro1a">
					    &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar </anthem:linkbutton>&nbsp;
                        &nbsp;&nbsp; &nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 10px; width: 5px;"></TD>
					<TD vAlign="middle" style="height: 10px; ">&nbsp;</TD>
					<TD style="height: 10px; width: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="texto" >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_frete_tabela" AddCallBacks="False" AutoUpdateAfterCallBack="True" PageSize="15">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True" __designer:wfdid="w221"></asp:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w82"></asp:CheckBox> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dstipofrete" HeaderText="Tipo Frete">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_validade" HeaderText="V&#225;lido Partir" DataFormatString="{0:MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Custo Km" DataField="nr_custo_km" ReadOnly="True" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_custo_fixo_diaria" DataFormatString="{0:N2}" HeaderText="Custo Fixo Dia">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_custo_fixo_mes" DataFormatString="{0:N2}" HeaderText="Custo Fixo M&#234;s">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dstipocustofixomes" HeaderText="Fixo M&#234;s Por:">
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_custo_fixo_mes_veiculos" DataFormatString="{0:N0}"
                                                    HeaderText="Nr.Ve&#237;culos">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_perc_seguro_carga" DataFormatString="{0:N4}" HeaderText="% Seguro">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="id_frete_tabela" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_frete_tabela" runat="server" Text='<%# Bind("id_frete_tabela") %>' __designer:wfdid="w207"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#78A3E2" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; " class="texto">&nbsp; &nbsp;
					</TD>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;&nbsp;</div>
		</form>
	</body>
</HTML>
