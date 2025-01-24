<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_liberacao.aspx.vb" Inherits="lst_poupanca_liberacao" %>

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
		<title>Poupança de Leite - Liberação para Aplicação de Bônus</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
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
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)" colspan="2"><STRONG> Poupança de Leite - Liberação para aplicação de bônus</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px" vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
                        </TD>
					<TD style="HEIGHT: 23px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" colspan="2" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 40%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px" colspan="2"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Referência Poupança:</td>
                                <td style="height: 20px" colspan="2">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_referencia_poupanca" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Enabled="False">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_referencia_poupanca"
                                        ErrorMessage="Informe o Mes/Ano de Referência Poupança." Font-Bold="True" InitialValue="0"
                                        ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">Código Produtor:</td>
								<td style="height: 20px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
    	                        </td>
								<TD align="right" style="height: 20px;">
                                    Participa Fechamento Poupança:</TD>
								<TD style="height: 20px" colspan="">&nbsp;&nbsp;<asp:DropDownList id="cbo_fechamento_poupanca" runat="server" CssClass="caixaTexto">
                                    <asp:ListItem Selected="True" Value="">[Selecione]</asp:ListItem>
                                    <asp:ListItem Value="S">Sim</asp:ListItem>
                                    <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                </asp:DropDownList>&nbsp;
                                </td>
                                 <td align="right" colspan="" style="height: 20px">
                                     <anthem:CheckBox ID="chk_gruporelacionamento" runat="server" Text="Grupo de Relacionamento" />&nbsp;</td>
 							</tr>
 							
                            <tr>
                                <td align="right" style="height: 20px; ">Código Propriedade:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
                                    </td>
 								<TD style="HEIGHT: 3px; " align="right">
                                     Propriedade Titular:&nbsp;</TD>
								<TD style="HEIGHT: 3px" colspan="2">&nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_id_propriedade_titular" runat="server" CssClass="caixaTexto"
                                        Width="80px"></cc4:OnlyNumbersTextBox></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Consistências:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_consistencia" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">Produtor Sem Indica&#231;&#227;o Participa&#231;&#227;o Fechamento</asp:ListItem>
                                        <asp:ListItem Value="2">Propriedades Inativas</asp:ListItem>
                                        <asp:ListItem Value="3">Grupo de Relacionamento - Sem Par&#226;metros Poupan&#231;a</asp:ListItem>
                                        <asp:ListItem Value="4">Grupo de Relacionamento - Prop. Respons&#225;vel Inativa</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; &nbsp; &nbsp;</td>
                                <TD style="HEIGHT: 3px; " align="right">
                                    Situação Adesão:</td>
                                <TD style="HEIGHT: 3px" colspan="2">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao_adesao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right" colspan="2">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
						&nbsp;&nbsp;&nbsp;
                        <asp:Image
                                ID="img_calcular" runat="server" ImageUrl="~/img/icone_calculadora.gif" /><anthem:LinkButton 
                                    ID="lk_liberar" runat="server"
                                    OnClientClick="if (confirm('Esta ação irá liberar TODAS as adesões do período de poupança que participam do fechamento. Após esta ação, as adesões não poderão mais ser alteradas. Deseja prosseguir?' )) return true;else return false;"
                                    ValidationGroup="vg_liberar" CssClass="texto" AutoUpdateAfterCallBack="True">Liberar para Aplicação de Bônus</anthem:LinkButton></TD>
					<TD style="HEIGHT: 25px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="height: 30px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 30px" colspan="">
&nbsp;<anthem:Button ID="btn_participar_fechamento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Participar Fechamento " ToolTip="Participar do Fechamento Poupança" ValidationGroup="vg_fechamento" OnClientClick="if (confirm('Esta ação irá confirmar a participação da propriedade no fechamento da poupança.  Deseja prosseguir?' )) return true;else return false;" />					<anthem:Button ID="btn_nao_participar_fechamento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Não Participar Fechamento" ToolTip="Não Participar do Fechamento Poupança" ValidationGroup="vg_fechamento" OnClientClick="if (confirm('Esta ação irá cancelar a participação da propriedade no fechamento da poupança.  Deseja prosseguir?' )) return true;else return false;" />
                        <anthem:CustomValidator ID="cvliberar" runat="server" CssClass="texto" ErrorMessage="[!]"
                            ForeColor="White" ValidationGroup="vg_liberar"></anthem:CustomValidator>
                        <anthem:CustomValidator ID="cvparticiparfechamento" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" ErrorMessage="[!]" ForeColor="White" ValidationGroup="vg_fechamento"></anthem:CustomValidator></TD>
                    <td align="right" colspan="1" valign="middle" style="height: 30px">
                        &nbsp;
                    </td>
					<TD style="height: 30px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD colspan="2">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_poupanca_adesao" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged" __designer:wfdid="w57"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" AutoPostBack="True" OnCheckedChanged="ck_item_CheckedChanged" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w58"></anthem:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                        <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" ReadOnly="True" />
                                        <asp:BoundField DataField="nr_tempo_adesao" HeaderText="Tempo Ades&#227;o" ReadOnly="True" />
                                <asp:BoundField DataField="ds_situacao_propriedade" HeaderText="Situa&#231;&#227;o Prop"
                                    ReadOnly="True" />
                                <asp:BoundField DataField="nm_participa_fechamento" HeaderText="Participa Fechamento" ReadOnly="True">
                                    <headerstyle wrap="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" />
                                <asp:BoundField DataField="nm_participa_poupanca" HeaderText="Grupo Participa&#231;&#227;o" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_responsavel_bonus" HeaderText="Prop. Resp. Bonus" />
                                <asp:BoundField DataField="ds_produtor_responsavel" HeaderText="Produtor Resp. Bonus" ReadOnly="True" />
                                <asp:BoundField HeaderText="Status Ades&#227;o" DataField="nm_situacao_poupanca" />
                                <asp:TemplateField HeaderText="st_participa_fechamento" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_st_participa_fechamento" runat="server" Text='<%# Bind("st_participa_fechamento") %>' __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_poupanca_adesao" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_poupanca_adesao" runat="server" Text='<%# Bind("id_poupanca_adesao") %>' __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_poupanca" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_poupanca" runat="server" Text='<%# Bind("id_situacao_poupanca") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="id_situacao_propriedade">
                                                <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<anthem:Label id="lbl_id_situacao_propriedade" runat="server" Visible="False" Text='<%# bind("id_situacao") %>' __designer:wfdid="w43"></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_participa_poupanca" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_st_participa_poupanca" runat="server" Text='<%# bind("st_participa_poupanca") %>' __designer:wfdid="w50"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade_titular" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_titular" runat="server" Text='<%# Bind("id_propriedade_titular") %>' __designer:wfdid="w59"></asp:Label>
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
					<TD vAlign="top" style="height: 19px" colspan="2">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
            &nbsp;
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_fechamento"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_liberar"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
