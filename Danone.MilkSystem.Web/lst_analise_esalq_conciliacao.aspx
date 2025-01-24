<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_analise_esalq_conciliacao.aspx.vb" Inherits="lst_analise_esalq_conciliacao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Dados Análises Externas Propriedade - Conciliação e Liberação para Cálculo</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

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
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)" colspan="2"><STRONG> Análises Externas - Conciliação e Liberação para Cálculo</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" colspan="2">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 159px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" colspan="2">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
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
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Data Coleta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DateMask="DayMonthYear" Width="75px"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px">
                                    Tipo da Coleta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_tipo_coleta" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
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
                                    Código Análise Esalq:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;<asp:DropDownList id="cbo_codigo_esalq" runat="server" CssClass="caixaTexto">
                                </asp:DropDownList></td>
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
 								<TD style="HEIGHT: 3px; " align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Consistências:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_situacao_analise_esalq" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    &nbsp; &nbsp; &nbsp;</td>
                                <TD style="HEIGHT: 3px; " align="right">
                                    &nbsp;Aprovação:</td>
                                <TD style="HEIGHT: 3px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_aprovacao_analise_esalq" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px; height: 159px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
						&nbsp;&nbsp;&nbsp;
                        <asp:Image
                                ID="img_calcular" runat="server" ImageUrl="~/img/icone_calculadora.gif" /><anthem:LinkButton 
                                    ID="lk_liberar_calculo" runat="server" AutoUpdateAfterCallBack="True"
                                    OnClientClick="if (confirm('Esta ação irá liberar TODAS as análises da referência, que estão aprovadas e sem consistências, para o cálculo Mensal. Após esta ação, as análises para a referência não poderão mais ser alteradas. Deseja prosseguir?' )) return true;else return false;"
                                    ValidationGroup="gv_estabel" CssClass="texto">Liberar para Cálculo</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 30px" colspan="">
<anthem:Button ID="btn_ativar" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Text="Ativar" ToolTip="Ativar Análises" OnClientClick="if (confirm('Esta ação irá atualizar a situação das análises selecionadas para ATIVO.  Deseja prosseguir?' )) return true;else return false;" ValidationGroup="vg_filtros" />
                        <anthem:Button ID="btn_desativar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Desativar" ToolTip="Desativar Análises" OnClientClick="if (confirm('Esta ação irá atualizar a situação das análises selecionadas para INATIVO.  Deseja prosseguir?' )) return true;else return false;" ValidationGroup="vg_filtros" />&nbsp;&nbsp;|&nbsp;
                        <anthem:Button ID="btn_aprovar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Aprovar" ToolTip="Aprovar Análises" ValidationGroup="vg_filtros" OnClientClick="if (confirm('Esta ação irá aprovar as análises  selecionadas, exceto se a mesma NÃO foi aprovada pelo sistema.  Deseja prosseguir?' )) return true;else return false;" />					<anthem:Button ID="btn_nao_aprovar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Reprovar" ToolTip="Não Aprovar Análises" ValidationGroup="vg_filtros" OnClientClick="if (confirm('Esta ação irá reprovar as análises  selecionadas.  Deseja prosseguir?' )) return true;else return false;" />
                        <anthem:Button ID="btn_Cancelar_aprovacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Cancelar Aprovação" ToolTip="Cancelar Aprovação/ Não Aprovação Análises" ValidationGroup="vg_filtros" OnClientClick="if (confirm('Esta ação irá cancelar a aprovação ou não aprovação das análises  selecionadas, retornando ao status de 'Aguardando Aprovação'. Deseja prosseguir?' )) return true;else return false;" />
                        <anthem:CustomValidator ID="cv_filtros" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" ForeColor="White" ValidationGroup="vg_filtros">[!]</anthem:CustomValidator>|&nbsp;
                        <anthem:Button ID="btn_consistir"
                                runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Text="Consistências"
                                ToolTip="Verificar Consistências" OnClientClick="if (confirm('Esta ação irá consistir TODAS as análises da referência, mesmo que existam análises selecionadas. Apenas serão utilizados os filtros obrigatórios. Deseja prosseguir?' )) return true;else return false;" /></TD>
                    <td align="right" colspan="1" valign="middle">
                        &nbsp;
                    </td>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD colspan="2">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_analise_esalq" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True" __designer:wfdid="w84"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w1"></anthem:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" SortExpression="ds_propriedade"/>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                <asp:TemplateField HeaderText="Matriz">
                                    <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="dt_processamento" HeaderText="Data Proc." SortExpression="dt_processamento" Visible="False" />
                                <asp:BoundField DataField="dt_analise" HeaderText="Data An&#225;lise" SortExpression="dt_analise" ReadOnly="True" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"
                                    SortExpression="id_tipo_coleta_analise_esalq" />
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" ReadOnly="True"
                                    SortExpression="ds_analise_esalq">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_esalq" HeaderText="Resultado"
                                    SortExpression="nr_valor_esalq" />
                                <asp:BoundField DataField="nm_st_analise" HeaderText="Status" Visible="False" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" Visible="False" />
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w2" CommandArgument='<%# Bind("id_analise_esalq") %>' CommandName="delete"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_media_mg" HeaderText="M&#233;dia MG" SortExpression="nr_media_mg" />
                                <asp:BoundField DataField="nr_variacao_mg" HeaderText="Var MG" SortExpression="nr_variacao_mg" />
                                <asp:BoundField DataField="st_transferencia" HeaderText="Transf." />
                                <asp:TemplateField HeaderText="Consist&#234;ncias">
                                    <itemtemplate>
<anthem:Label id="lbl_consistencias" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nm_situacao_analise_esalq") %>' __designer:wfdid="w52"></anthem:Label> <anthem:Label id="lbl_detalhes" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Text="Erros" __designer:wfdid="w53"></anthem:Label>&nbsp;<anthem:ImageButton id="btn_detalhes" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Detalhes Consistências" ImageUrl="~/img/icon_preview.gif" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w54" CommandName="consistencias" CommandArgument='<%# Bind("id_analise_esalq") %>'></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Aprova&#231;&#227;o" DataField="nm_aprovacao_analise_esalq" SortExpression="nm_aprovacao_analise_esalq" />
                                <asp:TemplateField HeaderText="id_situacao_analise_esalq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_analise_esalq" runat="server" Text='<%# Bind("id_situacao_analise_esalq") %>' __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_analise_esalq" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_id_analise_esalq" runat="server" Text='<%# Bind("id_analise_esalq") %>' __designer:wfdid="w22"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_analise_esalq" runat="server" Text='<%# Bind("id_analise_esalq") %>' __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_aprovacao_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_aprovacao_analise_esalq" runat="server" Text='<%# Bind("id_aprovacao_analise_esalq") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w7"></asp:Label>
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
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" colspan="2" >
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				
				<TR id="tr_detalhes" runat="server">
					<TD style="width: 9px">&nbsp;</TD>
					<TD colspan="2">
					<anthem:Panel ID="pnl_consistencias" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Detalhes Consistências" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table border=0 width="100%">
                                <tr>
                                    <td style="HEIGHT: 2px; width: 100%;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                            CommandArgument='<%# Bind("id_analise_esalq") %>' ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>
                                </tr>
                            </table>
                            
                            <anthem:GridView ID="gridConsistencias" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_analise_esalq" PageSize="20">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" />
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta" />
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="ds_analise_esalq" HeaderText="C&#243;d. An&#225;lise" ReadOnly="True"
                                    SortExpression="ds_analise_esalq">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Consist&#234;ncias">
                                    <itemtemplate>
<anthem:Label id="lbl_consistencias" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# Bind("nm_situacao_analise_esalq") %>'></anthem:Label><anthem:HyperLink id="hl_consistencias" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" Target="_blank">[hl_consistencias]</anthem:HyperLink> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_analise_esalq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_analise_esalq" runat="server" Text='<%# Bind("id_situacao_analise_esalq") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_analise_esalq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_analise_esalq" runat="server" Text='<%# Bind("id_analise_esalq") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
					</anthem:Panel>				
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
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
            &nbsp;
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_filtros"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
