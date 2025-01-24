<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_gold_preco_leite.aspx.vb" Inherits="lst_gold_preco_leite" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"  TagPrefix="cc3" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Preço Leite GOLD</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
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
        
        // var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
    
        //if (idcboestabel == "0")
        //{
        //    alert("O estabelecimento deve ser informado!");
        //}
        //else
        //{
   	        //szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            szUrl = 'lupa_produtor.aspx';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         //}
    }            
</script>
<script type="text/javascript"> 
    function ShowDialogPropriedade() 
    {
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
   	     
        szUrl = 'lupa_propriedade.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Preço Leite Produtor GOLD</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="2" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span class="obrigatorio">*</span>Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data de Validade:</td>
								<td style="height: 14px">
                                    &nbsp;
                                    <cc3:onlydatetextbox id="txt_dt_referencia_inicial" runat="server" cssclass="caixatexto" datemask="MonthYear"
                                        width="72px"></cc3:onlydatetextbox>&nbsp; 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia_inicial"
                                        ErrorMessage="Informe a Data de Validade Inicial." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>&nbsp;
                                    à &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_final" runat="server" CssClass="caixatexto"
                                        DateMask="MonthYear" Width="72px"></cc3:OnlyDateTextBox>
                                    &nbsp; 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia_final"
                                        ErrorMessage="Informe a Data de Validade final." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    &nbsp; &nbsp;&nbsp;
                               </td>
							</tr>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ico_email.gif" /><anthem:LinkButton
                            ID="lk_email" runat="server" CssClass="texto" OnClientClick="if (confirm('Uma notificação de que existem preços a serem aprovados será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                            ValidationGroup="vg_pesquisar">Notificar Aprovadores</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 10px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_gold_custo_produtor">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" />
                                <asp:TemplateField HeaderText="Custo Efet.">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_custo_operacional_efetivo" runat="server" ForeColor="Blue" __designer:wfdid="w73" Text='<%# Eval("nr_custo_operacional_efetivo") %>' NavigateUrl='<%# Eval("id_gold_custo_produtor", "~/frm_gold_custo_produtor.aspx?id_gold_custo_produtor={0}") %>' Target="_blank"></asp:HyperLink> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M. Coe">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_margem_custo_efetivo" runat="server" ForeColor="Blue" __designer:wfdid="w72" Text='<%# Eval("nr_margem_custo_efetivo") %>' NavigateUrl="~/frm_gold_custo.aspx" Target="_blank"></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_margem_volume" HeaderText="M. Vol" />
                                <asp:BoundField DataField="nr_margem_crescimento" HeaderText="M. Cresc" />
                                <asp:TemplateField HeaderText="Custo Dieta">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_custo_dieta" runat="server" ForeColor="Blue" Target="_blank" NavigateUrl='<%# Eval("id_gold_custo_produtor", "~/frm_gold_custo_produtor_dieta.aspx?id_gold_custo_produtor={0}") %>' Text='<%# Eval("nr_custo_dieta") %>' __designer:wfdid="w21"></asp:HyperLink> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_eficiencia_dieta" HeaderText="Efic. Dieta" />
                                <asp:BoundField DataField="nr_preco_leite" HeaderText="Pre&#231;o Leite" />
                                <asp:TemplateField HeaderText="id_gold_custo" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo" runat="server" __designer:wfdid="w74" Text='<%# Bind("id_gold_custo") %>'></asp:Label>
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
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" Visible="False" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;</div>
		</form>
	</body>
</HTML>
