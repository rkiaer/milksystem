<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_linha_romaneio_conciliacao.aspx.vb" Inherits="lst_linha_romaneio_conciliacao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Dados Análises Externas Propriedade - Conciliação e Liberação para Cálculo</title>
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
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Conciliação Rotas x Romaneios</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 3px; width: 10px;"></TD>
					<TD align="center" style="height: 3px">
						</TD>
					<TD style="height: 3px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif" align="right">
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 3px; width: 10px;">
                    </td>
                    <TD align="center" style="height: 3px" class="texto">
                    </td>
                    <TD style="height: 3px;">
                    </td>
                </tr>
				<TR>
					<TD style="width: 10px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 100%" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 38%"></TD>
								<TD style="height: 12px; width: 13%"></TD>
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
                                    <strong><span style="color: #ff0000">*</span></strong>Período Entrada:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    &nbsp; <cc3:OnlyDateTextBox id="txt_dt_hora_entrada_ini" runat="server" CssClass="texto"
                                        DateMask="DayMonthYear" Width="76px"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox id="txt_dt_hora_entrada_fim" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="76px"></cc3:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_hora_entrada_ini" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="False" ValidationGroup="gv_estabel" ToolTip="A data inicial do período deve ser informada.">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_hora_entrada_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada." ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_hora_entrada_fim"
                                                ControlToValidate="txt_dt_hora_entrada_ini" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date" ValidationGroup="gv_estabel">[!]</anthem:CompareValidator></td>


                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Romaneio:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <cc4:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px">
                                    </cc4:onlynumberstextbox>&nbsp; 
                                </td>
                                <TD align="right" style="height: 20px;">
                                    Rota:</td>
                                <TD style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_rota" runat="server"
                                        CssClass="caixaTexto" Height="16px" MaxLength="7" Width="88px"></anthem:TextBox></td>
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">
                                     Tipo do Romaneio:</td>
                                 <td style="height: 20px; ">
                                     &nbsp;
                                    <asp:DropDownList id="cbo_tipo_romaneio" runat="server" CssClass="texto" AutoPostBack="True">
                                    <asp:ListItem Value="1" Selected="True">Romaneio</asp:ListItem>
                                        <asp:ListItem Value="2">Romaneio Transbordo</asp:ListItem>
                                    <asp:ListItem Value="3">Pr&#233;-Romaneio Transbordo</asp:ListItem>
                                        <asp:ListItem Value="4">Romaneio Transit Point</asp:ListItem>
                                        <asp:ListItem Value="5">Pr&#233;-Romaneio Transit Point</asp:ListItem>
                                        <asp:ListItem Value="6">Romaneio Transvase</asp:ListItem>
                                        <asp:ListItem Value="7">Pr&#233;-Romaneio Transvase</asp:ListItem>
                                </asp:DropDownList> &nbsp; &nbsp;&nbsp;&nbsp;<anthem:Label ID="lbl_romaneio_tp_transb" runat="server"
                                         AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Romaneio Transit:</anthem:Label>
                                     <cc4:OnlyNumbersTextBox ID="txt_id_romaneio_tp_transb" runat="server" AutoCallBack="True"
                                         AutoUpdateAfterCallBack="True" CssClass="texto" Visible="False" Width="64px"></cc4:OnlyNumbersTextBox>
                                 </td>
                                 <TD align="right" style="height: 20px;">
                                     Divergências KM:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;<asp:DropDownList id="cbo_divergencias" runat="server" CssClass="caixaTexto">
                                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                                    <asp:ListItem Value="1">Sem Diverg&#234;ncias</asp:ListItem>
                                    <asp:ListItem Value="2">Com Diverg&#234;ncias</asp:ListItem>
                                </asp:DropDownList></td>
 							</tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Aprovação:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_aprovacao_km_frete" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    &nbsp; &nbsp;&nbsp;</td>
                                <TD style="HEIGHT: 20px; " align="right">
                                    </td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    </td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif" align="right">
						&nbsp;&nbsp;&nbsp;
                        </TD>
					<TD style="HEIGHT: 24px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 10px;"></TD>
					<TD vAlign="middle" style="height: 30px">
                        &nbsp;&nbsp;<anthem:Button ID="btn_consistir"
                                runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Text="Consistências"
                                ToolTip="Verificar Consistências" ValidationGroup="gv_estabel" OnClientClick="if (confirm('Esta ação irá consistir TODOS os romaneios do Estabelecimento e  Período informado, independente dos romaneios selecionados. Esta ação deve ser realizadas antes da Liberação para o Frete.  Deseja prosseguir?' )) return true;else return false;" />
                        <anthem:Button ID="btn_aprovar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Aprovar" ToolTip="Aprovar Romaneios" ValidationGroup="gv_estabel" OnClientClick="if (confirm('Esta ação irá aprovar todos os romaneios  selecionados do período informado, que estejam Aguardando Aprovação.  Deseja prosseguir?' )) return true;else return false;" />					<anthem:Button ID="btn_nao_aprovar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Reprovar" ToolTip="Não Aprovar Romaneios" ValidationGroup="gv_estabel" OnClientClick="if (confirm('Esta ação irá reprovar os romaneios  selecionados.  Deseja prosseguir?' )) return true;else return false;" />
                        <anthem:Button ID="btn_Cancelar_aprovacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Cancelar Aprovação" ToolTip="Cancelar Aprovação/ Não Aprovação Romaneios" ValidationGroup="gv_estabel" OnClientClick="if (confirm('Esta ação irá cancelar as aprovações e reprovações dos romaneios  selecionados.  Deseja prosseguir?' )) return true;else return false;" /></TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 10px" class="texto">&nbsp;</TD>
					<TD class="texto">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio" PageSize="8" CssClass="texto">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w17" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w96"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio"/>
                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" />
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Data Entrada" SortExpression="dt_hora_entrada" />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                <asp:BoundField HeaderText="Tipo Romaneio" ReadOnly="True" Visible="False" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_coletor" HeaderText="KM Coletor" NullDisplayText="&quot;&quot;" />
                                <asp:BoundField DataField="kmtotal" HeaderText="KM Atual Rota" />
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" />
                                <asp:BoundField DataField="nm_justificativa_km_frete" HeaderText="Justificativa" />
                                <asp:BoundField HeaderText="Rom. Transit" Visible="False" DataField="id_romaneio_transit_point" ReadOnly="True" />
                                <asp:BoundField DataField="id_romaneio_transbordo" HeaderText="Rom. Transb." ReadOnly="True"
                                    Visible="False" />
                                <asp:BoundField DataField="id_romaneio_transvase" HeaderText="Rom. Tvase." ReadOnly="True"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="Diverg&#234;ncias">
                                    <itemtemplate>
<anthem:Label id="lbl_consistencias" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nm_divergencia_km_frete") %>' __designer:wfdid="w93"></anthem:Label> <anthem:Label id="lbl_detalhes" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text="Com Divergências" __designer:wfdid="w98"></anthem:Label>&nbsp;<anthem:ImageButton id="btn_detalhes" runat="server" ToolTip="Visualizar Detalhes do Romaneio" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ImageUrl="~/img/icon_preview.gif" CommandArgument='<%# Bind("id_romaneio") %>' CommandName="consistencias" __designer:wfdid="w99"></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Aprova&#231;&#227;o" DataField="nm_aprovacao_km_frete" SortExpression="nm_aprovacao_km_frete" />
                                <asp:BoundField DataField="dt_aprovacao_km_frete" HeaderText="Data Aprova&#231;&#227;o" />
                                <asp:TemplateField HeaderText="id_aprovacao_km_frete" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_id_aprovacao_km_frete" runat="server" Text='<%# Bind("id_aprovacao_km_frete") %>' __designer:wfdid="w65"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_aprovacao_km_frete" runat="server" Text='<%# Bind("id_aprovacao_km_frete") %>' __designer:wfdid="w64"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_linha" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_id_linha" runat="server" Text='<%# Bind("id_linha") %>' __designer:wfdid="w10"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_linha" runat="server" Text='<%# Bind("id_linha") %>' __designer:wfdid="w9"></asp:Label>
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
					<TD style="width: 10px" class="texto">&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" >
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				
				<TR id="tr_detalhes" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top">
					<anthem:Panel ID="pnl_consistencias" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes do Romaneio" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%">
                                <tr>
                                     <td style="HEIGHT: 2px; width: 100%;" align="left">
                                         &nbsp;
                                        <asp:Label ID="lbl_romaneio" runat="server" CssClass="texto" Width="46px">Romaneio:</asp:Label>&nbsp;<asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label>
                                         &nbsp;&nbsp;
                                         <asp:Label ID="Label1" runat="server" CssClass="texto">KM Atual Rota:</asp:Label>
                                         <asp:Label ID="lbl_km_original" runat="server" CssClass="texto"></asp:Label>
                                         &nbsp;&nbsp;
                                         <asp:Label ID="Label4" runat="server" CssClass="texto">Últ. Importação:</asp:Label>
                                         <asp:Label ID="lbl_dt_importacao" runat="server" CssClass="texto"></asp:Label>
                                         &nbsp;&nbsp;
                                         <asp:Label ID="Label5" runat="server" CssClass="texto">KM Original Coletor:</asp:Label>
                                         <asp:Label ID="lbl_km_coletor" runat="server" CssClass="texto"></asp:Label></td>
                                   <td style="HEIGHT: 2px; width: 100%;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>
                                </tr>
                            </table>
                            
                            <anthem:GridView ID="gridConsistencias" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_linha" PageSize="20">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="nr_ordem" HeaderText="Seq" />
                                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" />
                                <asp:BoundField DataField="nm_propriedade" HeaderText="Propriedade" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Consist&#234;ncias">
                                    <itemtemplate>
<anthem:Label id="lbl_consistencias" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" Text='<%# Bind("nm_consistencia") %>' UpdateAfterCallBack="True" __designer:wfdid="w68"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        <br />
                                        
                             <table width="100%">
                                <tr>
                                     <td style="width: 35%;" align="left" valign="bottom">
                                         &nbsp;</td>
                                     <td align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="texto" >KM Total Frete:</asp:Label>&nbsp;
                                         <cc4:OnlyNumbersTextBox ID="txt_nr_km_frete" runat="server" CssClass="texto"
                                             Width="70px" MaxLength="8"></cc4:OnlyNumbersTextBox><anthem:RequiredFieldValidator
                                                 ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_km_frete"
                                                 CssClass="texto" ErrorMessage="Preencha o campo KM Total Frete para continuar."
                                                 Font-Bold="False" InitialValue="0" ToolTip="Km Total Frete deve ser infromado."
                                                 ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                         &nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Label ID="Label3" runat="server" CssClass="texto" >Justificativa:</asp:Label>&nbsp;<asp:DropDownList id="cbo_justificativa_km_frete" runat="server" CssClass="caixaTexto" Width="210px">
                                             <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                             <asp:ListItem Value="1">Sem Diverg&#234;ncias</asp:ListItem>
                                             <asp:ListItem Value="2">Com Diverg&#234;ncias</asp:ListItem>
                                         </asp:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                             ControlToValidate="cbo_justificativa_km_frete" CssClass="texto" ErrorMessage="Preencha o campo Justificativa para continuar."
                                             Font-Bold="False" InitialValue="0" ToolTip="Justificativa deve ser informada."
                                             ValidationGroup="vg_salvar" Visible="False">[!]</anthem:RequiredFieldValidator>&nbsp;
                                     </td>
                                    <td style="width: 15%;" align="left">
                                        &nbsp;<anthem:Button ID="btn_salvarkm" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Salvar" ToolTip="Aprovar Análises" ValidationGroup="vg_salvar" /></td>
                                </tr>
                            </table>
                                       
					</anthem:Panel>				
					</TD>
					<TD style="width: 10px; height: 195px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
