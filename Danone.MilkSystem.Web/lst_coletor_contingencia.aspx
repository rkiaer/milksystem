<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_coletor_contingencia.aspx.vb" Inherits="lst_coletor_contingencia" %>

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
		<title>lst_coletor_contingencia</title>
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

    function ShowDialogVeiculo() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_veiculo = document.getElementById("hf_id_veiculo");

        szUrl = 'lupa_veiculo.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_veiculo.value=retorno;
        } 
    }            
    </script>

	<script type="text/javascript"> 

    function ShowDialogAlterarPlaca() 
 
      {
  
        var currentidentity;
        var retorno="";
   	    var szUrl;
        var hf_ds_placa_frete = document.getElementById("hf_ds_placa_frete");
           	     
        currentidentity = document.getElementById("hf_currentidentity").value;
        if (currentidentity == "")
        {
            alert("Para acessar a função alterar placa, a caderneta deve estar carregada!");
        }
        else
        {
   	        szUrl = 'frm_coletor_alterarplaca.aspx?currentidentity='+currentidentity+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_ds_placa_frete.value=retorno;
            } 
         }
     }            
   </script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Contingência para o Coletor&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 1014px">
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 1014px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span class="obrigatorio">*</span>Data Coleta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta" runat="server" CssClass="texto" Width="88px"></cc3:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_coleta"
                                        ErrorMessage="Informe a CNH do motorista." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                 <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Placa:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server"
                                        CssClass="caixaTexto" Height="16px" MaxLength="7" Width="88px"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton ID="bt_lupa_veiculo" runat="server"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Veículos" Width="15px" Visible="False" />&nbsp; 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_placa"
                                        ErrorMessage="Informe a placa." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>&nbsp;<anthem:CustomValidator ID="cmv_placa"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_placa" CssClass="texto"
                                            ErrorMessage="Placa não cadastrada." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator>
                                    &nbsp; &nbsp; &nbsp;
                                </td>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span class="obrigatorio">*</span>CNH:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_cnh" runat="server" CssClass="texto" MaxLength="11"></cc2:OnlyNumbersTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cnh"
                                        ErrorMessage="Informe a CNH do motorista." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                 <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000"></span></strong>Placa Julieta:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa_julieta" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" Height="16px" MaxLength="7" Width="88px"></anthem:TextBox>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                           </tr>
                           <!--
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                            -->
                            <tr>                         
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Tipo Rota:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_tipo_rota" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>&nbsp;</td>
                                 <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Nome Rota:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server"
                                        CssClass="caixaTexto" Height="16px" MaxLength="7" Width="88px"></anthem:TextBox>
                                    &nbsp; &nbsp; 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nm_linha"
                                        ErrorMessage="Informe o nome da Rota." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:Label ID="lbl_placa_frete" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    &nbsp;</td>
                                <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000"></span></strong>
                                </td>
                                <td style="height: 14px">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
							<tr>
								<TD colspan="3">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="~/img/bnt_buscardados.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_transmitir" runat="server" ValidationGroup="vg_pesquisar">Transmitir</asp:LinkButton>&nbsp;&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:HyperLink ID="hl_alterarplaca" runat="server" CssClass="texto" NavigateUrl="~/frm_coletor_alterarplaca.aspx"
                            Target="_blank" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Alterar Placa</anthem:HyperLink>&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif"></asp:Image>
                        <anthem:HyperLink ID="hl_imprimir" runat="server" CssClass="texto" NavigateUrl="~/frm_relatorio_caderneta.aspx"
                            Target="_blank" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink>&nbsp;
                        <asp:LinkButton ID="lk_alterarplaca" runat="server" CssClass="texto" Visible="False">LinkButton</asp:LinkButton></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
				<TR >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD style="width: 1014px">&nbsp;
<anthem:Panel ID="pnl_roteiro" runat="server" BackColor="White" Font-Bold="False" GroupingText="Roteiro"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px" HorizontalAlign="Center" AutoUpdateAfterCallBack="True" Visible="False">
    <table class="texto" border="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 25%; height: 22px;">Nova Propriedade/Unidade Produção:</td>
            <td style="width: 20%; height: 22px;"><anthem:TextBox ID="txt_propriedade" runat="server" CssClass="texto" Width="100px" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                -
                <anthem:TextBox ID="txt_unidade_producao" runat="server" AutoUpdateAfterCallBack="True"
                    CssClass="texto" Width="30px"></anthem:TextBox></td>
            <td style="height: 22px" ><anthem:Button ID="btn_adicionar_propriedade" runat="server" Text="Adicionar" CssClass="texto" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Total Litros:"></asp:Label>
                <asp:Label ID="lbl_total_litros" runat="server"></asp:Label></td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td colspan="3">
                   
					<anthem:GridView ID="gridRoteiro" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" AutoUpdateAfterCallBack="True" DataKeyNames="id_coleta" PageSize="5">
                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                        <EditRowStyle BackColor="#78A3E2" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nr_ordem" HeaderText="Seq" ReadOnly="True" />
                            <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" />
                            <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True" />
                            <asp:BoundField DataField="nr_unid_producao" HeaderText="U.Prod." ReadOnly="True" />
                            <asp:BoundField DataField="nm_motivo_nao_coleta" HeaderText="Motivo N&#227;o Coleta" />
                            <asp:BoundField DataField="coleta_efetuada" HeaderText="Status Coleta" />
                            <asp:TemplateField>
                                <itemtemplate>
&nbsp;<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w41" CommandName="edit" CommandArgument='<%# bind("id_coleta") %>'></anthem:ImageButton> 
</itemtemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                    </anthem:GridView>
            </td>
        </tr>
    </table>
    &nbsp;</anthem:Panel>
                    </TD>
					<TD style="height: 19px;"></TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 1014px;">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 1014px">
<anthem:Panel ID="Panel5" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados da Coleta"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px" HorizontalAlign="Center" Visible="False" AutoUpdateAfterCallBack="true">
    <br />
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_coleta" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                                            <Columns>
                                                <asp:BoundField DataField="nr_ordem" HeaderText="Seq" ReadOnly="True" />
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="U.Prod." ReadOnly="True" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                                <asp:BoundField DataField="ds_placa_frete" HeaderText="Placa Frete" />
                                                <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume" HeaderText="Litros" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_temperatura" HeaderText="Temp." ReadOnly="True" />
                                                <asp:BoundField DataField="nm_alizarol" HeaderText="Alizarol" ReadOnly="True" />
                                                <asp:BoundField DataField="nm_motivo_nao_coleta" HeaderText="Motivo N&#227;o Coleta" />
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                           <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                           <EditRowStyle BackColor="#78A3E2" />
                                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                           <AlternatingRowStyle BackColor="White" />
                                        </anthem:GridView>
                                        </anthem:Panel>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; width: 1014px;">&nbsp;
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_currentidentity" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_ds_placa_frete" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
