<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_gold_custo.aspx.vb" Inherits="frm_gold_custo" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo GOLD</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");

        szUrl = 'lupa_tecnico.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_tecnico.value=retorno;
        } 

    }            
</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Custo GOLD</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; | &nbsp;
                                    <asp:Image ID="img_concluir" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <asp:Image ID="img_email" runat="server" ImageUrl="~/img/ico_email.gif" /><anthem:LinkButton
                                        ID="lk_email" runat="server" CssClass="texto" OnClientClick="if (confirm('Uma notificação de que existem Custos a serem aprovados será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                                        ValidationGroup="vg_salvar">Notificar Aprovadores</anthem:LinkButton>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
											    <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="">
											    <TABLE id="Table6" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <span class="obrigatorio">*</span><strong> Estabelecimento:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="false"
                                                                CssClass="texto" AutoUpdateAfterCallBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <span class="obrigatorio">*</span><strong>Data Validade Inicial:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc4:onlydatetextbox id="txt_dt_referencia_inicial" runat="server" cssclass="texto"
                                                                datemask="MonthYear" width="72px" AutoUpdateAfterCallBack="True"></cc4:onlydatetextbox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia_inicial"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Validade Inicial para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cv_data_validade" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_dt_referencia_inicial" CssClass="texto" ErrorMessage="Período de valaidade inválido."
                                                                Font-Bold="True" SetFocusOnError="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <span class="obrigatorio">*</span><strong>Data Validade Final:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia_final" runat="server" CssClass="texto"
                                                                DateMask="MonthYear" Width="72px" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia_final"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Validade Final para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                            <anthem:Button ID="btn_carregar_faixas" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Text="Buscar Dados" ToolTip="Buscar dados do estabelecimento e referência"
                                                                ValidationGroup="vg_salvar" /></td>
                                                    </tr>
											    </TABLE>
											    </asp:Panel>
											    
											    <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Margem Custo Efetivo">
											    <TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>
                                                                            </strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                        <anthem:GridView ID="GridCustoMargem" runat="server" AddCallBacks="False" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            DataKeyNames="id_gold_faixa_custo" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                                                                            UpdateAfterCallBack="True" Width="60%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ds_gold_faixa_custo" HeaderText="Custo Operacional" ReadOnly="True" >
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="Margem (R$)">
                                                                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_margem" runat="server" CssClass="texto" Width="75px" Text='<%# bind("nr_margem") %>' __designer:wfdid="w2" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol=","></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle width="20%" horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_gold_custo_margem" Visible="False">
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo_margem" runat="server" Text='<%# Bind("id_gold_custo_margem") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                        </td>
                                                                </tr>
																<TR>
																	<TD class="texto" align=center width="23%" colSpan="2">
                                                                        &nbsp;</TD>
																</TR>
											    </TABLE>
											    </asp:Panel>
											    
											    <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Precificação por Faixa de Volume">
											    <TABLE id="Table8" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>
                                                                            </strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                        <anthem:GridView ID="gridVolume" runat="server" AddCallBacks="False" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            DataKeyNames="id_gold_faixa_volume" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                                                                            UpdateAfterCallBack="True" Width="60%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ds_gold_faixa_volume" HeaderText="Faixa" ReadOnly="True" >
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="Adicional (R$)">
                                                                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_adicional_volume" runat="server" CssClass="texto" Width="75px" Text='<%# bind("nr_adicional_volume") %>' DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="4" __designer:wfdid="w2"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle width="20%" horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_gold_custo_volume" Visible="False">
                                                                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("id_gold_custo_volume") %>' __designer:wfdid="w14"></asp:TextBox>
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo_volume" runat="server" Text='<%# Bind("id_gold_custo_volume") %>' __designer:wfdid="w13"></asp:Label>
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                        </td>
                                                                </tr>
																<TR>
																	<TD class="texto" align=center width="23%" colSpan="2">
                                                                        &nbsp;</TD>
																</TR>
											    </TABLE>
											    </asp:Panel>
											    
											    
											    <asp:Panel ID="Panel5" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Margem Crescimento">
											    <TABLE id="Table9" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>
                                                                            </strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                        <anthem:GridView ID="GridCrescimento" runat="server" AddCallBacks="False" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            DataKeyNames="id_gold_faixa_crescimento" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                                                                            UpdateAfterCallBack="True" Width="60%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ds_gold_faixa_crescimento" HeaderText="% Crescimento" ReadOnly="True" >
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="B&#244;nus (R$)">
                                                                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_adicional_crescimento" runat="server" CssClass="texto" Width="75px" Text='<%# bind("nr_adicional_crescimento") %>' DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="4" __designer:wfdid="w3"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle width="20%" horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_gold_custo_crescimento" Visible="False">
                                                                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("id_gold_custo_crescimento") %>' __designer:wfdid="w3"></asp:TextBox>
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo_crescimento" runat="server" Text='<%# Bind("id_gold_custo_crescimento") %>' __designer:wfdid="w2"></asp:Label>
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                        </td>
                                                                </tr>
																<TR>
																	<TD class="texto" align=center width="23%" colSpan="2">
                                                                        &nbsp;</TD>
																</TR>
											    </TABLE>
											    </asp:Panel>
											    
											    <asp:Panel ID="Panel6" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Eficiência Dieta">
											    <TABLE id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>
                                                                            </strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                        <anthem:GridView ID="GridEficiencia" runat="server" AddCallBacks="False" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            DataKeyNames="id_gold_faixa_eficiencia" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                                                                            UpdateAfterCallBack="True" Width="60%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ds_gold_faixa_eficiencia" HeaderText="Efici&#234;ncia Dieta" ReadOnly="True" >
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="Margem (R$)">
                                                                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_adicional_eficiencia" runat="server" CssClass="texto" Width="75px" Text='<%# bind("nr_adicional_eficiencia") %>' __designer:wfdid="w6" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol=","></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                                                    <headerstyle horizontalalign="Center" />
                                                                                    <itemstyle width="20%" horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_gold_custo_eficiencia" Visible="False">
                                                                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("id_gold_custo_eficiencia") %>' __designer:wfdid="w8"></asp:TextBox>
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo_eficiencia" runat="server" Text='<%# Bind("id_gold_custo_eficiencia") %>' __designer:wfdid="w7"></asp:Label>
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                        </td>
                                                                </tr>
																<TR>
																	<TD class="texto" align=center width="23%" colSpan="2">
                                                                        &nbsp;</TD>
																</TR>
											    </TABLE>
											    </asp:Panel>
											    
											    <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Dados do Sistema">
											    <TABLE id="Table10" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 18%">
                                                            <strong>Situação:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" style="width: 18%">
                                                            <strong>Modificador:</strong></TD>
														<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" style="width: 18%">
                                                            <strong>Data Modificação:</strong></TD>
														<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
													</TR>
											    </TABLE>
											    </asp:Panel>

											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="img_voltarfooter" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="img_concluirfooter" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
</form>
	</body>
</HTML>
