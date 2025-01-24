<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_recepcao_amostra.aspx.vb" Inherits="lst_romaneio_recepcao_amostra" %>

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
		<title>Recepção das Amostras de Coletas no Romaneio</title>
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
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Recepção das Amostras de Coletas no Romaneio</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px;">&nbsp;</TD>
					<TD vAlign="middle" background="img/faixa_filro.gif" align="right">
                        </TD>
					<TD style="width: 10px;">&nbsp;</TD>
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
					<TD id="td_pesquisa" runat="server" style="width: 100%" class="texto" align="center">
					<table class="borda" cellSpacing="0" cellPadding="0" border="0" style="width: 98%">
					    <tr ><td style="width: 2%; vertical-align: middle; text-align: center; border-right: #999999 1px solid;" align="center" ><anthem:RadioButton ID="optprotocolo" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True" Checked="True" ToolTip="Pesquisa por Protocolo" /></td>
					<td>
							<TABLE id="Table3" class="texto" width="100%" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px;"></TD>
								<TD style="height: 12px; width: 13%"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Protocolo:
                                </td>
                                <td style="height: 20px">
                                    &nbsp;<cc4:OnlyNumbersTextBox ID="txt_cd_protocolo" runat="server" AutoPostBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto12p" MaxLength="20" Width="272px"></cc4:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
						</TABLE>
				
					</td></tr>
					<tr >
					<td style="vertical-align: middle; width: 2%; text-align: center;border-top: #999999 1px solid; border-right: #999999 1px solid; height: 150px;" >
                        <anthem:RadioButton ID="optfiltro" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True" ToolTip="Pesquisa por Filtros" /></td>
					<td style=" vertical-align: middle; text-align: center; border-top: #999999 1px solid; height: 150px;" >
					<TABLE class="texto" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0"  >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px;"></TD>
								<TD style="height: 12px; width: 10%"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 13%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 25px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 25px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 25px">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Entrada:</td>
                                <td style="height: 25px">
                                    &nbsp;&nbsp;<cc3:OnlyDateTextBox id="txt_dt_hora_entrada_ini" runat="server" CssClass="texto"
                                        DateMask="DayMonthYear" Width="80px" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox id="txt_dt_hora_entrada_fim" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="80px" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_hora_entrada_ini" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="False" ValidationGroup="vg_pesquisa" ToolTip="A data inicial do período deve ser informada.">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_hora_entrada_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada." ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_hora_entrada_fim"
                                                ControlToValidate="txt_dt_hora_entrada_ini" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date" ValidationGroup="vg_pesquisa">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 25px">
                                    Rota:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_rota" runat="server" CssClass="caixaTexto" Height="22px"
                                        MaxLength="7" Width="88px" AutoUpdateAfterCallBack="True"></anthem:TextBox></td>


                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px; ">
                                    Romaneio:</td>
                                <td style="height: 25px; ">
                                    &nbsp;
                                    <cc4:onlynumberstextbox id="txt_id_romaneio" runat="server" cssclass="texto" width="64px" AutoUpdateAfterCallBack="True"></cc4:onlynumberstextbox>&nbsp; 
                                </td>
                                <TD align="right" style="height: 25px;">
                                    Transit Point:</td>
                                <TD style="height: 25px">
                                    &nbsp;
                                     <cc4:OnlyNumbersTextBox ID="txt_id_transit_point" runat="server"
                                         AutoUpdateAfterCallBack="True" CssClass="texto" Width="80px"></cc4:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 25px">
                                    Placa Veículo:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_ds_placa" runat="server" CssClass="caixaTexto" Height="22px"
                                        MaxLength="7" Width="88px" AutoUpdateAfterCallBack="True"></anthem:TextBox></td>
                            </tr>
                        <tr>
                                <td align="right" style="height: 25px">
                                    Protocolo:
                                </td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_protocolo" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="20" Width="192px"></cc4:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 25px">
                                    Tipo de Coleta:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo_coleta" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 25px">
                                    Transvase:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_id_transvase" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="80px"></cc4:OnlyNumbersTextBox></td>
                        </tr>
                            <tr>
                                <td align="right" style="height: 8px; ">
                                    </td>
                                <td style="height: 8px; ">
                                    </td>
                                <TD style="HEIGHT: 8px; " align="right">
                                    </td>
                                <TD style="HEIGHT: 8px">
                                    &nbsp;
                                    </td>
                                <td style="height: 8px">
                                </td>
                                <td style="height: 8px">
                                </td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px">&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisa" AutoUpdateAfterCallBack="True" Enabled="False"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif" AutoUpdateAfterCallBack="True" Enabled="False"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
</td></tr>
					</table>
                        <br />
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
					<TD style="height: 5px; width: 10px;"></TD>
					<TD vAlign="middle" style="height: 5px">
                        &nbsp;&nbsp;</TD>
					<TD style="height: 5px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 10px" class="texto">&nbsp;</TD>
					<TD class="texto">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio" PageSize="4" CssClass="texto">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Det.">
                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe" runat="server" ToolTip="Visualizar Coletas do Pré-Romaneio" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ImageUrl="~/img/icon_preview.gif" CommandName="viewdetalheromaneio" CommandArgument='<%# bind("id_romaneio") %>' __designer:wfdid="w7"></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio"/>
                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" />
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Data Entrada" SortExpression="dt_hora_entrada" />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                <asp:BoundField HeaderText="Transit Point" ReadOnly="True" DataField="id_transit_point" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_romaneio_transbordo" HeaderText="Transb." NullDisplayText="&quot;&quot;" />
                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" />
                                <asp:TemplateField HeaderText="nr_caderneta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_caderneta" runat="server" Text='<%# Bind("nr_caderneta") %>' __designer:wfdid="w4"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_romaneio_transbordo" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_st_romaneio_transbordo" runat="server" Text='<%# Bind("st_romaneio_transbordo") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transit_point" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_transit_point" runat="server" Text='<%# Bind("id_transit_point") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transvase" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_transvase" runat="server" Text='<%# Bind("id_transvase") %>' __designer:wfdid="w9"></asp:Label>
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
					<anthem:Panel ID="pnl_amostras" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes do Romaneio" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%">
                                <tr>
                                     <td style="HEIGHT: 2px; width: 100%;" align="left">
                                         &nbsp;
                                        <anthem:Label ID="lbl_romaneio" runat="server" CssClass="texto" Width="46px" Font-Size="X-Small">Romaneio:</anthem:Label>&nbsp;<anthem:Label ID="lbl_id_romaneio" runat="server" CssClass="texto" Font-Size="X-Small"></anthem:Label>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <anthem:Label
                                             ID="lbl_transbordo" runat="server" CssClass="texto" Font-Size="X-Small">Transbordo: SIM</anthem:Label>
                                         &nbsp; &nbsp;
                                         <anthem:Label ID="lbl_transit" runat="server" CssClass="texto" Font-Size="X-Small">Transit Point:</anthem:Label></td>
                                   <td style="HEIGHT: 2px; width: 100%;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>
                                </tr>
                            </table>
                            
                            <anthem:GridView ID="gridAmostras" runat="server"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_coleta_amostra" PageSize="20">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w50" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server" AutoPostBack="True" OnCheckedChanged="ck_item_CheckedChanged" __designer:wfdid="w15"></asp:CheckBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233; Rom." Visible="False" />
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop. UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop Matriz" />
                                <asp:BoundField DataField="frasco1" HeaderText="Frasco Amarelo" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="frasco2" HeaderText="Frasco Azul" ReadOnly="True" />
                                <asp:BoundField DataField="frasco3" HeaderText="Frasco Branco" ReadOnly="True" />
                                <asp:BoundField DataField="frasco4" HeaderText="Frasco Vermelho" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Col.Amostra">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_situacao_coleta_amostra" runat="server" __designer:wfdid="w61"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_situacao_romaneio_amostra" HeaderText="Recep&#231;&#227;o" />
                                <asp:BoundField HeaderText="Motivo Descarte no Rom." DataField="nm_motivo_descarte_romaneio_amostra" />
                                <asp:TemplateField HeaderText="id_tipo_frasco1" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco1" runat="server" Text='<%# Bind("id_tipo_frasco1") %>' __designer:wfdid="w46"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco2" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco2" runat="server" Text='<%# Bind("id_tipo_frasco2") %>' __designer:wfdid="w4"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco3" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco3" runat="server" Text='<%# Bind("id_tipo_frasco3") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco4" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco4" runat="server" Text='<%# Bind("id_tipo_frasco4") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_coleta_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_coleta_amostra" runat="server" Text='<%# Bind("id_situacao_coleta_amostra") %>' __designer:wfdid="w47"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_romaneio_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_romaneio_amostra" runat="server" Text='<%# Bind("id_situacao_romaneio_amostra") %>' __designer:wfdid="w68"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_romaneio_amostra_motivo" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_motivo_descarte_romaneio_amostra" runat="server" Text='<%# Bind("id_motivo_descarte_romaneio_amostra") %>' __designer:wfdid="w14"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_coleta" Visible="False">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("id_coleta") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("id_coleta") %>' id="Label1"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        <br />
                                        
                             <table width="100%">
                                <tr>
                                     <td align="right" valign="bottom">
                                         &nbsp;<anthem:Label ID="lbl_novoprotocolo" runat="server" AutoUpdateAfterCallBack="True"
                                             CssClass="texto" UpdateAfterCallBack="True" Visible="False">Novo Protocolo:</anthem:Label>
                                         <cc4:OnlyNumbersTextBox ID="txt_novo_protocolo" runat="server"
                                             AutoUpdateAfterCallBack="True" CssClass="texto12p" MaxLength="20" Width="192px" Visible="False"></cc4:OnlyNumbersTextBox><anthem:RequiredFieldValidator
                                                 ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_novo_protocolo"
                                                 CssClass="texto" ErrorMessage="Preencha o campo Novo Protocolo para continuar."
                                                 Font-Bold="True" ToolTip="Informe o campo Novo Protocolo para continuar."
                                                 ValidationGroup="vg_protocolo">[!]</anthem:RequiredFieldValidator>&nbsp;
                                         <anthem:Button ID="btn_alterarprotocolo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Alterar Protocolo" ToolTip="Alterar Protocolo selecionado" ValidationGroup="vg_protocolo" Visible="False" /><asp:CustomValidator ID="cv_protocolo" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_protocolo">[!]</asp:CustomValidator></td>
                                     <td align="right">
                                         <asp:CustomValidator ID="cv_descartar" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_descartar">[!]</asp:CustomValidator>
                                         <asp:CustomValidator ID="cv_receber" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_receber">[!]</asp:CustomValidator>
                                         <anthem:Button ID="btn_receber" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Receber Amostras" ToolTip="Receber as Amostras selecionadas" ValidationGroup="vg_receber" Visible="False" />
                                         &nbsp;&nbsp; &nbsp;
                                         <anthem:Label ID="lbl_descarte" runat="server" CssClass="texto" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" >Motivo Descarte:</anthem:Label>&nbsp;<anthem:DropDownList id="cbo_motivo_descarte" runat="server" CssClass="caixaTexto" Width="210px" Visible="False" AutoUpdateAfterCallBack="True">
                                             <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                             <asp:ListItem Value="1">N&#227;o Entregue Transportador</asp:ListItem>
                                             <asp:ListItem Value="2">Frasco Danificado</asp:ListItem>
                                         </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                             ControlToValidate="cbo_motivo_descarte" CssClass="texto" ErrorMessage="Preencha o campo Motivo do Descarte para continuar."
                                             Font-Bold="True" InitialValue="0" ToolTip="Informe o campo Motivo Descarte para continuar."
                                             ValidationGroup="vg_descartar">[!]</anthem:RequiredFieldValidator>&nbsp;
                                     </td>
                                    <td style="width: 15%;" align="left">
                                        &nbsp;<anthem:Button ID="btn_Descartar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Descartar Amostras" ToolTip="Descartar as Amostras selecionadas" ValidationGroup="vg_descartar" Visible="False" /></td>
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
                ShowSummary="False" ValidationGroup="vg_pesquisa"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="vg_protocolo" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_protocolo"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_descartar"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_receber"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
