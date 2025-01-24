<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_cooperativa_sl0013.aspx.vb" Inherits="lst_cooperativa_sl0013" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_cooperativa_sl0013</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {       
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_cooperativa.value=retorno;
        } 
    }            
</script>
		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Ajuste SL0013</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 23px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"  class="texto" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 20px; width: 13%" ></TD>
								<TD style="height: 12px;"></TD>
								<TD style="height: 19px; width: 13%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; width: 13%;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" Display="Dynamic" ValidationGroup="gv_pesquisar">[!]</asp:CompareValidator></td>

                                <td align="right" style="height: 20px; width: 13%;">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Entrada:&nbsp;</td>
                                <td align="left" style="height: 20px">&nbsp;<cc3:OnlyDateTextBox ID="txt_data_ini" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data para continuar."
                                        Font-Bold="False" ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; à&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_data_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    <asp:CustomValidator ID="cv_periodo" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                        ValidationGroup="gv_pesquisar">[!] </asp:CustomValidator></td>
                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px; width: 13%;">
                                    Cooperativa:</td>
                                <td colspan="3" style="height: 25px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:CustomValidator ID="cv_cooperativa"
                                            runat="server" ControlToValidate="txt_cd_cooperativa" CssClass="texto" ErrorMessage="Cooperativa não cadastrada!"
                                            Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="gv_pesquisar"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style=" width: 13%;" class="texto" >
                                    Tipo:&nbsp;</td>
                                <td style="vertical-align: text-bottom;" colspan="2" valign="bottom" class="texto">
                                    <anthem:RadioButtonList ID="opt_tipo_visao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" RepeatDirection="Horizontal" style="vertical-align: text-bottom" >
                                        <Items>
                                            <asp:ListItem Value="A">Anal&#237;tico</asp:ListItem>
                                            <asp:ListItem Value="S" Selected="True">Sint&#233;tico / Agrupado</asp:ListItem>
                                        </Items>
                                    </anthem:RadioButtonList></td>
                                <td class="texto" >
                                    &nbsp;</td>
                            </tr>
 							
                          
							<tr>
								<TD align="right" colspan="3" style="height: 20px; width: 13%;">&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="gv_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px; ">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;
                    </TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio" PageSize="30">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="C&#243;d.SAP" DataField="cd_codigo_sap" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Cooperativa" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Dt.Entrada" DataFormatString="{0:dd/MM/yyyy}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Romaneio" DataField="id_romaneio" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso Balan&#231;a" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Dens (g/ml)" DataFormatString="{0:n4}" DataField="nr_valor_dens" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pesoemlitros" DataFormatString="{0:n0}" HeaderText="Volume (lts)" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_saida_nota" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nr.NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Volume NF" DataField="nr_peso_liquido_nota" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:n2}" HeaderText="Valor NF" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataFormatString="{0:n4}" HeaderText="R$/L" DataField="nr_valor_por_litro" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-NF (lts)" DataField="nr_variacao_volume" DataFormatString="{0:n0}" >
                                    <headerstyle width="5%" wrap="True" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_exportacao_batch" HeaderText="Export. Batch">
                                    <headerstyle horizontalalign="Center" width="5%" wrap="True" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_po" HeaderText="PO-Batch" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="volumerejeitado" DataFormatString="{0:n0}" HeaderText="Volume Rejeitado" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_destino_leite_rejeitado" HeaderText="Destino Rejeitado"
                                    Visible="False" />
                                            </Columns><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridResultsSintetico" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="30">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="C&#243;d.SAP" DataField="cd_codigo_sap" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Cooperativa" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Resumido">
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="somapesoemlitros" DataFormatString="{0:n0}" HeaderText="Soma Volume (lts)" >
                                    <headerstyle horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Soma Volume NF" DataField="somapesonota" DataFormatString="{0:n0}" >
                                    <headerstyle horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o vol Real-NF (lts)" DataField="somavariacao" DataFormatString="{0:n0}" >
                                    <headerstyle wrap="True" horizontalalign="Right" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_po" HeaderText="PO-Batch" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_nf_complemento" HeaderText="NF Compl.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_carta_credito" HeaderText="Carta Cr&#233;dito">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; ">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
                            &nbsp;
        </div>
		</form>
	</body>
</HTML>
