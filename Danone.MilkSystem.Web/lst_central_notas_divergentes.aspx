<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_notas_divergentes.aspx.vb" Inherits="lst_central_notas_divergentes" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Central de Compras - Gereciamento Notas Divergentes</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>

	<script type="text/javascript" > 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_produtor = document.getElementById("hf_id_produtor");

   	     
        idcboestabel = "1";
        
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
                hf_id_produtor.value=retorno;
            } 

         }
    }    
</script>
    
	<script type="text/javascript" language="javascript">
		function clearDataFornec()
		{
		    If ( document.getElementById("txt_nm_fornecedor").value == "[Filtre Nome]" )
			    {
			    document.getElementById("txt_nm_fornecedor").value = "";
			    }
		}
	</script>
		<script type="text/javascript" language="javascript">
		function clearDataItem()
		{
			    document.getElementById("txt_nm_item").value="";
			
		}
	</script>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Central de Compras - Gerenciamento de Notas Fiscais com Divergência</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" class="texto" >
						<TABLE id="Table6" height="12px" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" >&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
</TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; " class="texto">&nbsp;</TD>
					<TD id="td1" runat="server" align="center" class="texto">
						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD style="height: 2px; width: 12%" ></TD>
								<TD style="height: 2px; width: 10%"></TD>
								<TD style="height: 2px; width: 14%"></TD>
								<TD style="height: 2px"></TD>
                                <td style="width: 12%; height: 2px">
                                </td>
                                <td style="height: 2px">
                                </td>
                                <td style="height: 2px; width: 10%;">
                                </td>
                                <td style="height: 2px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 19px; " align="right" >
                                    Referência Emissão:</td>
                                <TD style="HEIGHT: 19px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px" AutoPostBack="True" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 19px" >
                                    Período em Dias Emissão:</td>
                                <td style="height: 19px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_dia_ini" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px" AutoUpdateAfterCallBack="True" Enabled="False"></cc2:OnlyNumbersTextBox>
                                    à
                                    <cc2:OnlyNumbersTextBox ID="txt_dia_fim" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px" AutoUpdateAfterCallBack="True" Enabled="False"></cc2:OnlyNumbersTextBox>
                                        <anthem:RangeValidator ID="RangeValidator1"
                                            runat="server" ControlToValidate="txt_dia_ini" ErrorMessage="O Dia Inicial do periodo de emissao deve estar entre 1 e 30."
                                            MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial do Periodo de Emissao deve estar entre 1 e 30."
                                            Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim" ErrorMessage="O Dia Final Emissao deve estar entre 1 e 30."
                                                MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da Emissao deve estar entre 1 e 30."
                                                Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                    ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini" ControlToValidate="txt_dia_fim"
                                                    ErrorMessage="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 19px">
                                    Data Importação:</td>
                                <td style="height: 19px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_importacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 19px">
                                    Nr Importação:</td>
                                <td style="height: 19px">
                                    &nbsp;<cc2:OnlyNumbersTextBox ID="txt_nr_importacao" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox>
                                    &nbsp;
                                </td>


                                         
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 19px; " align="right">
                                    Nr. Nota:</td>
                                <TD style="HEIGHT: 19px; ">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_nr_nota" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 19px">
                                     Nome Emitente:</td>
                                <td style="height: 19px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_emitente" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="200" Width="180px"></anthem:TextBox></td>
                                <td align="right" style="height: 19px">
                                    Nome Destinatário:</td>
                                <td style="height: 19px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="200" Width="180px"></anthem:TextBox></td>
                                <td style="height: 19px" align="right">
                                    Nr Pedido Nota:</td>
                                <td style="height: 19px">
                                    &nbsp;<cc2:OnlyNumbersTextBox ID="txt_nr_pedido_nota" runat="server" CssClass="texto"
                                        MaxLength="20" Width="80px" AutoUpdateAfterCallBack="True"></cc2:OnlyNumbersTextBox></td>
                            </tr>
 							
                            <tr>
                                <td align="right" style="height: 19px; ">
                                    <strong><span style="color: #ff0000">*</span></strong>Divergência Nota:</td>
                                <td align="left" colspan="2" style="height: 19px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_divergencia_nota" runat="server" CssClass="caixaTexto" AutoPostBack="True" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Value="1" Enabled="False">Pedidos V&#225;lidos</asp:ListItem>
                                        <asp:ListItem Value="2">Pedidos Existentes Central</asp:ListItem>
                                        <asp:ListItem Value="3">Pedidos Inexistentes Central</asp:ListItem>
                                        <asp:ListItem Value="4" Selected="True">Notas Sem Pedidos</asp:ListItem>
                                        <asp:ListItem Enabled="False" Value="5">Notas J&#225; Inclu&#237;das</asp:ListItem>
                                        <asp:ListItem Enabled="False" Value="6">Notas Bloqueadas</asp:ListItem>
                                    </anthem:DropDownList></td>
								<TD style="HEIGHT: 19px">&nbsp;
                                    </TD>
                                <td style="height: 19px" align="right">
                                    Tipo de Consistência:</td>
                                <td align="left" colspan="3" style="height: 19px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_consistencias" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                        <asp:ListItem Value="2" Enabled="False">Fornecedor: CNPJ inexistente no cadastro</asp:ListItem>
                                        <asp:ListItem Value="3" Enabled="False">Fornecedor: Cadastro inativo</asp:ListItem>
                                        <asp:ListItem Value="4" Enabled="False">Produtor: CPF inexistente no cadastro</asp:ListItem>
                                        <asp:ListItem Value="5" Enabled="False">Produtor: Cadastro inativo</asp:ListItem>
                                        <asp:ListItem Value="6" Enabled="False">Fornecedor da NFe diferente do fornecedor do pedido da Central</asp:ListItem>
                                        <asp:ListItem Value="7" Enabled="False">Produtor da NFe diferente do produtor do pedido da Central</asp:ListItem>
                                        <asp:ListItem Value="9">Situa&#231;&#227;o do Pedido diferente de ABERTO ou FINALIZADO PARCIAL</asp:ListItem>
                                        <asp:ListItem Value="10">Nr Nota j&#225; existe no Pedido</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList></td>
                           </tr>
                          
							<tr>
								<TD align="right" style="height: 19px">&nbsp;</TD>
                                <td align="left" style="height: 19px">
                                    &nbsp;&nbsp;</td>
                                <td align="left" style="height: 19px">
                                </td>
                                <td align="right" colspan="5" style="height: 19px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;&nbsp;&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_pesquisar" Visible="False" />
                                    &nbsp;&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</td>
							</tr>
						</TABLE>
					</TD>
					<TD class="texto" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px; width: 9px;" class="texto">&nbsp;</TD>
					<TD class="texto" style="HEIGHT: 20px; font-size: x-small;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 20px" class="texto">&nbsp;</TD>
				</TR>				
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center" class="texto">
                        <anthem:GridView ID="gridFiles" runat="server" AddCallBacks="False" AllowPaging="True" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            CellPadding="2" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"
                            GridLines="None" PageSize="6" UpdateAfterCallBack="True" Width="99%" DataKeyNames="id_central_notas_importacao" CellSpacing="2">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White" HorizontalAlign="Left" />
                                    <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:TemplateField HeaderText="Det." ShowHeader="False"><itemtemplate >
<anthem:ImageButton id="btn_detalhe" runat="server" ImageUrl="~/img/icon_preview.gif" CausesValidation="False" AutoUpdateAfterCallBack="True" Text="Select" __designer:wfdid="w359" CommandName="Select"></anthem:ImageButton> 
</ItemTemplate>
                                <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />

                                </asp:TemplateField>
                                <asp:BoundField DataField="id_importacao" DataFormatString="{0:N0}" HeaderText="Nr Execu&#231;&#227;o">
                                <headerstyle horizontalalign="Center"></HeaderStyle>
                                <itemstyle horizontalalign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_criacao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Dt Imp">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_emitente" HeaderText="Fornecedor" ReadOnly="True" ></asp:BoundField>
                                <asp:BoundField DataField="cd_CNPJ_emit" HeaderText="CNPJ" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <itemstyle horizontalalign="Center" ></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_destino" HeaderText="Produtor"></asp:BoundField>
                                <asp:BoundField DataField="cpf_cnpj_dest" HeaderText="CPF/CNPJ">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_remetente" HeaderText="Remetente">
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_cnpj_rem" HeaderText="CNPJ">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Nr Nota"><ItemTemplate>
                                <asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Text='<%# bind("nr_nota_fiscal") %>' Font-Underline="True"></asp:HyperLink>
                                
</ItemTemplate>

                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_emissao" DataFormatString="{0:d}" HeaderText="Emiss&#227;o" ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nf" DataFormatString="{0:C2}" HeaderText="Vl Nota">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_pedido" HeaderText="Pedido Inf." ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <itemstyle horizontalalign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_central_notas" HeaderText="Sit. Nota">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <itemstyle horizontalalign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Nr Pedido">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <itemstyle horizontalalign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="id_situacao_nota" ShowHeader="False" Visible="False"><ItemTemplate>
                                <asp:Label id="lbl_id_situacao_nota" runat="server" Text='<%# Bind("id_situacao_central_notas") %>'></asp:Label>
                                
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_central_pedido_sugestao" Visible="False">
                                <ItemTemplate>
                                <asp:Label id="lbl_id_central_pedido_sugestao" runat="server" Text='<%# Bind("id_central_pedido_sugestao") %>'></asp:Label>
                                
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                <ItemTemplate>
                                <asp:Label id="lbl_id_produtor_nota" runat="server" Text='<%# Bind("id_produtor") %>'></asp:Label>
                                
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                <ItemTemplate>
<asp:Label id="lbl_id_fornecedor_nota" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w360"></asp:Label> 
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nm_emitente" Visible="False">
                                <ItemTemplate>
                                <asp:Label id="lbl_nm_emitente" runat="server" Text='<%# Bind("nm_emitente") %>'></asp:Label>
                                
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nm_destino" Visible="False">
                                <ItemTemplate>
                                <asp:Label id="lbl_nm_destino" runat="server" Text='<%# Bind("nm_destino") %>'></asp:Label>
                                
</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_nota_fiscal" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_nota_fiscal" runat="server" Text='<%# Bind("nr_nota_fiscal") %>' __designer:wfdid="w13"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_fornecedor_remetente" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_fornecedor_remetente" runat="server" Text='<%# Bind("id_fornecedor_remetente") %>' __designer:wfdid="w19"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nm_remetente" runat="server" Text='<%# Bind("nm_remetente") %>' __designer:wfdid="w21"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
									                            </Columns>
							<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"/><RowStyle BackColor="#EFF3FB"/>
                        </anthem:GridView>
                        <br />

										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR id="tr_detalhes" runat="server">
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" class="texto">
					<anthem:Panel ID="pnl_romaneio" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes das Divergências" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					      <table width="100%" class="texto"  id="TABLE2"  cellpadding="0" cellspacing="0">
                                <tr>

                                                                       <td style="height: 19px;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>

                                </tr>
                             </table>
                        <anthem:GridView ID="gridDoc" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="2" CssClass="texto"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="20" UpdateAfterCallBack="True"
                            Width="95%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle  Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_cd_divergencia" HeaderText="C&#243;digo" >
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Diverg&#234;ncia" DataField="ds_divergencia" />
</columns>
                        </anthem:GridView>
                                       
					</anthem:Panel>				

					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
 
				<TR id="tr1" runat="server">
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" class="texto">
					<anthem:Panel ID="pnl_pedido" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes do Pedido da Central informado na Nota" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					      <table width="95%" class="borda" style="border-right: 1px ridge; border-bottom: #f0f0f0 1px ridge" id="TABLE4"  cellpadding="0" cellspacing="0" >
                                <tr>
                                     <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px;" align="left">
                                         &nbsp;
                                        <anthem:Label ID="Label1" runat="server" CssClass="texto">Pedido:</anthem:Label>&nbsp;<anthem:Label ID="lbl_pedido" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_dt_pedido" runat="server" CssClass="texto"></anthem:Label>
                                    </td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_item" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;
                                        <anthem:Label ID="lbl_qtde" runat="server" CssClass="texto"></anthem:Label></td>
                                        <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">  &nbsp;<anthem:Label
                                             ID="lbl_total_notas" runat="server" CssClass="texto"></anthem:Label>
                                            &nbsp; &nbsp;
                                            <anthem:Label ID="lbl_total_pedido" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_situacao" runat="server" CssClass="texto"></anthem:Label></td>
                                                                       <td style="height: 25px;" align="right">
                                        <anthem:ImageButton ID="btn_fechar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>

                                </tr>
                                <tr>
                                    <td align="left" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_fornecedor" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px" colspan="2">
                                        &nbsp;<anthem:Label ID="lbl_produtor" runat="server" CssClass="texto"></anthem:Label>&nbsp;</td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_propriedade" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="right" style="height: 25px">
                                    </td>
                                </tr>
                              <tr>
                                  <td align="left" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                      &nbsp;</td>
                                  <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px" colspan="3" align="right">
                                      &nbsp; &nbsp;<anthem:Button ID="btn_manterpedido" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Manter Pedido e Incluir Nota" ToolTip="Manter o Nr Pedido informado na Nota e inlui-la, mesmo com as divergências." Visible="False" />
                                      &nbsp;&nbsp;
                                  </td>
                                  <td align="right" style="height: 25px">
                                  </td>
                              </tr>
                                <tr>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                    <td align="right" style="height: 5px">
                                    </td>
                                </tr>
                            </table>

                                       
					</anthem:Panel>				

					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
				
				<TR id="tr2" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top" class="texto">
					<anthem:Panel ID="pnl_selecao_pedidos" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Seleção de Pedidos" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%" class="borda" style="border-right: 1px ridge; border-bottom: #f0f0f0 1px ridge" id="TABLE5"  cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;FORNECEDOR:&nbsp; 
                                        <anthem:TextBox ID="txt_nm_fornecedor" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="true"
                                            CssClass="texto" MaxLength="100" Width="100px" onfocus="clearDataFornec()" >[Filtre Nome]</anthem:TextBox>&nbsp;
                                        Selecione:
                                        <anthem:DropDownList ID="cbo_fornecedor" runat="server" AutoPostBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="vg_atualizar_resp">
                                        </anthem:DropDownList>&nbsp;
                                        <anthem:Label ID="lbl_cnpj_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" UpdateAfterCallBack="True" Font-Bold="True"></anthem:Label></td>
                                    <td colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_item_filtro" runat="server" CssClass="texto">Item:</anthem:Label>&nbsp;
                                        <anthem:TextBox ID="txt_nm_item" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="true"
                                            CssClass="texto" MaxLength="100" onfocus="clearDataItem()" Width="120px">[Filtre Nome]</anthem:TextBox>&nbsp; 
                                        <anthem:Label ID="lbl_item_selecione" runat="server" CssClass="texto">Selecione:</anthem:Label>
                                        <anthem:DropDownList ID="cbo_item_filtro" runat="server"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" AutoPostBack="True">
                                        </anthem:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px" colspan="">
                                        &nbsp;Nome Fornecedor:
                                        <anthem:TextBox ID="txt_nm_fornecedor_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="20" Width="150px"></anthem:TextBox></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;Nr Pedido:
                                        <cc2:OnlyNumbersTextBox ID="txt_id_central_pedido" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                            MaxLength="20" Width="80px"></cc2:OnlyNumbersTextBox>&nbsp;</td>
                                    <td colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;Situação:
                                        <anthem:DropDownList ID="cbo_situacao_pedido" runat="server"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" >
                                            <asp:ListItem Selected="True" Value="18">Aberto, Aprovado e Finalizado Parcial</asp:ListItem>
                                            <asp:ListItem Value="1">Aberto</asp:ListItem>
                                            <asp:ListItem Value="6">Aprovado</asp:ListItem>
                                            <asp:ListItem Value="8">Finalizado Parcial</asp:ListItem>
                                            <asp:ListItem Value="3" Enabled="False">Finalizado</asp:ListItem>
                                        </anthem:DropDownList></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px" colspan="2">
                                        &nbsp;Valor Pedido:
                                        <anthem:DropDownList ID="cbo_operador" runat="server"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" >
                                            <asp:ListItem Value="&gt;">maior igual</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="&lt;">menor igual</asp:ListItem>
                                        </anthem:DropDownList>
                                        <cc4:OnlyDecimalTextBox ID="txt_nr_valor_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxCaracteristica="10" MaxLength="15" Width="100px"></cc4:OnlyDecimalTextBox></td>
                                </tr>
                                 <tr>
                                    <td align="left" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;PRODUTOR:
                                        <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                            CssClass="texto" MaxLength="10" Width="64px" Enabled="False"></anthem:TextBox>
                                        <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                            ToolTip="Filtrar Produtores" Width="15px" Visible="False" />
                                        <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                            Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label>
                                        &nbsp;
                                        <anthem:Label ID="lbl_cpf_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True" Font-Bold="True"></anthem:Label></td>
                                     <td colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                         height: 25px">
                                        &nbsp;<anthem:TextBox ID="txt_nm_produtor_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="20" Width="150px" Visible="False"></anthem:TextBox>&nbsp;
                                     </td>
                                </tr>
                               <tr>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px" colspan="2">
                                        &nbsp;Propriedade:
                                        <cc2:OnlyNumbersTextBox ID="txt_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="20" Width="80px" AutoPostBack="True"></cc2:OnlyNumbersTextBox><anthem:ImageButton
                                                ID="btn_ver" runat="server" AutoUpdateAfterCallBack="True" Height="25px" ImageAlign="AbsBottom"
                                                ImageUrl="~/img/arrowdown.png" Width="25px" />
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;Propriedade Matriz:
                                        <cc2:OnlyNumbersTextBox ID="txt_propriedade_matriz" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxLength="20" Width="80px"></cc2:OnlyNumbersTextBox>
                                    <td colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;Período Abertura Pedido:
                                        <cc3:OnlyDateTextBox ID="txt_dt_pedido_ini" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc3:OnlyDateTextBox>
                                        à
                                        <cc3:OnlyDateTextBox ID="txt_dt_pedido_fim" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc3:OnlyDateTextBox>
                                        <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_dt_pedido_ini"
                                            ControlToValidate="txt_dt_pedido_fim" ErrorMessage="O campo Data Final do 'Período Abertura do Pedido' deve ser maior ou igual ao Data Inicial."
                                            Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                            Type="Date" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator><br />
                                    </td>
                                </tr>
                               <tr>
                                   <td align="left" colspan="3" style="font-weight: bold; border-bottom: #f0f0f0 1px solid">
                                                                           <anthem:Panel ID="pnl_propriedade" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Propriedades" HorizontalAlign="Center" Width="60%" AutoUpdateAfterCallBack="True" Visible="False">
                                            <anthem:GridView ID="gridPropriedades" runat="server" AutoGenerateColumns="False"
                                                AutoUpdateAfterCallBack="True" CellPadding="2" CssClass="texto" Font-Names="Verdana"
                                                Font-Size="XX-Small" ForeColor="#333333" PageSize="100" UpdateAfterCallBack="True"
                                                Width="98%">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                    ForeColor="White" />
                                                <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <itemtemplate>
<anthem:ImageButton id="imgselecionar" runat="server" ImageUrl="~/img/ico_triangulo_cinza.gif" AutoUpdateAfterCallBack="True" Text="Select" CommandName="Select" CausesValidation="False"></anthem:ImageButton> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Produtor">
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_cidade" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_cidade" runat="server" Text='<%# Bind("id_cidade") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_estado" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_estado" runat="server" Text='<%# Bind("id_estado") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                                        <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                        <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="matriz" Visible="False">
                                                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                        <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" Text='<%# Bind("matriz") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_produtor" runat="server" Text='<%# Bind("id_pessoa") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="row_num" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_row_num" runat="server" Text='<%# Bind("row_num") %>'></asp:Label>
</itemtemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            </anthem:GridView>
                                        
                                        </anthem:Panel>

                                   </td>
                                    <td align="right" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                       ">
                                        </td>
                                </tr>

                                <tr>
                                    <td align="center" style="border-bottom: #f0f0f0 1px solid; height: 25px; font-weight: bold;">
                                        </td>
                                    <td align="left" style="font-weight: bold; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        </td>
                                    <td align="left" style="font-weight: bold; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        </td>
                                    <td align="right" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        <anthem:CustomValidator ID="cv_pedidos" runat="server" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator>
                                        &nbsp;<anthem:Button ID="btn_pesquisar_pedidos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Pesquisar Pedidos" ValidationGroup="vg_pesquisar" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                </tr>
                            </table>
                        &nbsp;<anthem:GridView ID="gridPedidos" runat="server"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_central_pedido" CssClass="texto" CellPadding="1">
                            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                    ForeColor="White" />
                          <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<anthem:ImageButton id="imgselecionarpedido" runat="server" ImageUrl="~/img/ico_triangulo_cinza.gif" CausesValidation="False" AutoUpdateAfterCallBack="True" Text="Select" CommandName="Select" __designer:wfdid="w11"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Nr. Pedido" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pedido" DataFormatString="{0:d}" HeaderText="Data Pedido" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="PropMatriz" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_fornecedor" HeaderText="Fornecedor" />
                                <asp:BoundField DataField="cd_cnpj_fornecedor" HeaderText="CNPJ" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_item" HeaderText="Item" />
                                <asp:BoundField DataField="nr_quantidade" DataFormatString="{0:N4}" HeaderText="Qtde" Visible="False" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:C2}" HeaderText="Total Pedido" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Notas" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Sit. Pedido" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                              <asp:TemplateField HeaderText="id_situacao_pedido" Visible="False">
                                  <itemtemplate>
<asp:Label id="lbl_id_situacao_pedido" runat="server" Text='<%# Bind("id_situacao_pedido") %>' __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                              </asp:TemplateField>
                                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
                        <br />
                        <anthem:CustomValidator ID="cv_novopedido" runat="server" AutoUpdateAfterCallBack="True"
                            ForeColor="White" ValidationGroup="vgpedidos">[!]</anthem:CustomValidator>
                        <anthem:Button ID="btn_incluirnotapedidonovo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Incluir Nota no novo pedido selecionado." ToolTip="Incluir Nota no Pedido Selecionado" ValidationGroup="vgpedidos" /></anthem:Panel>				
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpedidos" /><asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
            <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="true" />
		&nbsp;
		&nbsp;
		</form>
	</body>
</HTML>
