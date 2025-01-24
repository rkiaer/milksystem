<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_pessoa_contrato_aprovar_2N.aspx.vb" Inherits="lst_pessoa_contrato_aprovar_2N" %>

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
		<title>Aprovar Modelo de Contrato Produtor 2o Nível</title>
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

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Modelo de Contrato&nbsp;Produtor 2.o Nível</STRONG></TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 22px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
                        <table id="Table3" cellpadding="0" cellspacing="0" class="borda" width="100%">
                            <tr>
                                <td align="right" style="height: 10px">
                                </td>
                                <td colspan="2" style="height: 10px">
                                </td>
                                <td align="right" class="texto" colspan="1" style="height: 10px">
                                </td>
                                <td colspan="1" style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 23px">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td colspan="2" style="width: 28%; height: 23px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual" Type="Integer"
                                        ValidationGroup="vg_pesquisar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                <td align="right" class="texto" colspan="1" style="width: 12%; color: #333333; height: 23px">
                                    Código Produtor:</td>
                                <td colspan="1" style="height: 23px">
                                    &nbsp;
                                                <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                    CssClass="caixaTexto" MaxLength="10" Width="72px" Enabled="False"></anthem:TextBox>
                                                &nbsp;<anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                    ToolTip="Filtrar Produtores" Width="15px" Enabled="False" />
                                                <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="true" CssClass="Texto"
                                                    Visible="False"></anthem:Label>
                                                
                                </td>
                            </tr>
                            <tr runat="server" id="tr_codigos" visible="false">
                                <td align="right" style="height: 23px">
                                    Código do Contrato:</td>
                                <td colspan="2" style="height: 23px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" Enabled="False">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 23px">
                                    Mod. Relacionamento:</td>
                                <td align="left" class="texto" style="height: 23px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_cluster" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="5">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
					    &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar </anthem:linkbutton>&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
					</TD>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;"></TD>
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px; width: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="texto" >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_pessoa_contrato" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True" __designer:wfdid="w221"></asp:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w13"></asp:CheckBox> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" SortExpression="nm_estabelecimento" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                                <asp:BoundField HeaderText="&#218;lt. Contrato" DataField="ultimo_cd_contrato" ReadOnly="True" />
                                                <asp:BoundField HeaderText="&#218;lt. Adic. Vol." DataField="ultimo_nr_adicional_volume" ReadOnly="True" />
                                                <asp:BoundField HeaderText="&#218;lt. Modelo Relac." DataField="ultimo_nm_cluster" ReadOnly="True" />
                                                <asp:BoundField DataField="cd_contrato" HeaderText="Contrato" SortExpression="cd_contrato" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_contrato" HeaderText="Nome Contrato" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_adicional_volume" HeaderText="Adic. Vol." ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_cluster" HeaderText="Modelo Relac." ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_situacao_pessoa_contrato" HeaderText="Situa&#231;&#227;o Contrato" />
                                                <asp:TemplateField HeaderText="id_pessoa_contrato" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_pessoa_contrato" runat="server" Text='<%# Bind("id_pessoa_contrato") %>' __designer:wfdid="w209"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_pessoa_contrato" runat="server" Text='<%# Bind("id_pessoa_contrato") %>' __designer:wfdid="w207"></asp:Label> 
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
                            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true"
                                Visible="False" />
                            &nbsp;</div>
		</form>
	</body>
</HTML>
