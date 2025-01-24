<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pessoa_contrato.aspx.vb" Inherits="frm_pessoa_contrato" %>

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
    <title>Produtor X Modelo de Contrato</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	<script type="text/javascript"> 

    function ShowDialogContrato() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_contrato = document.getElementById("hf_id_contrato");
   	    var idcboestabel
   	    idcboestabel = document.getElementById("cbo_estabelecimento").value;

        szUrl = 'lupa_contrato.aspx?id='+idcboestabel+'';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:700px;edge:raised;dialogHeight:600px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_contrato.value=retorno;
        } 
    }            

</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Produtor - Modelo de Contrato</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar" OnClientClick="if (confirm('Qualquer alteração no Modelo De Contrato será enviado para aprovações em 1o e 2o níveis. Deseja realmente salvar o registro?' )) return true;else return false;">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:Image ID="img_notificacao" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/ico_email.gif" Visible="False" />
                                    <anthem:LinkButton ID="lk_email" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                                        OnClientClick="if (confirm('Uma notificação de que existem contratos para aprovação será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                                        ToolTip="Notificar Aprovadores do Modelo de Contrato" ValidationGroup="vg_pesquisar"
                                        Visible="False">Notificar Aprovadores</anthem:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição Produtor</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%"></TD>
														<TD width="77%"></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Estabelecimento:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList></td>
                                                    </tr>
													<TR id="trContratoRelacionado" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG>Código:</STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" MaxLength="10" Enabled="False"></anthem:TextBox>
                                                            </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Código SAP:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_codigo_SAP" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="10" Width="25%"></anthem:TextBox></td>
                                                    </tr>
													<TR id="tr_contrato" runat="server" width="23%">
														<TD class="texto" style="HEIGHT: 17px" align="right" width="23%"><STRONG>Categoria:</STRONG></TD>
														<TD style="HEIGHT: 17px">&nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True" Enabled="False">
                                                            <asp:ListItem Value="F">F&#237;sica</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="J">Juridica</asp:ListItem>
                                                            </anthem:DropDownList></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="60%" MaxLength="60" Enabled="False"></anthem:TextBox>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nome Abreviado:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_abreviado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="12" Width="25%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Grupo:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_grupo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" valign="top" colspan="2">
                                                            Modelo de Contrato</td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Data de Início Contrato:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Data Fim Contrato:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_fim_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Data Rescisão:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_rescisao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <span style="color: #ff0000"><strong>*</strong><span style="color: #000000"> </span>
                                                                            <strong><span style="color: #000000">Contrato:</span></strong></span>&nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:TextBox ID="txt_cd_contrato" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" MaxLength="4" Width="50px"></anthem:TextBox>
                                                                        <anthem:ImageButton ID="btn_lupa_contrato" runat="server" AutoUpdateAfterCallBack="true"
                                                                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                            ToolTip="Filtrar Contratos" Width="15px" />
                                                                        <anthem:Label ID="lbl_nm_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;<anthem:RequiredFieldValidator
                                                                                ID="rf_contrato" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_contrato"
                                                                                CssClass="texto" ErrorMessage="Preencha o Contrato para continuar." Font-Bold="True"
                                                                                ToolTip="O campo Contrato deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                                                    ID="cv_contrato" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong><span style="color: #ff0000">*</span></strong><span style="color: #000000">
                                                                        </span><strong><span style="color: #000000">Adicional de Volume Cálculo:</span></strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_adicional_volume" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                            <asp:ListItem Selected="True" Value="24">24hrs</asp:ListItem>
                                                                            <asp:ListItem Value="48">48hrs</asp:ListItem>
                                                                        </anthem:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <span class="obrigatorio">*</span> <strong>Modelo de Relacionamento:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_cluster" runat="server"
                                                                CssClass="texto" Enabled="False" AutoUpdateAfterCallBack="True">
                                                                        </anthem:DropDownList>
                                                                        <anthem:RequiredFieldValidator ID="rf_cluster" runat="server" AutoUpdateAfterCallBack="True"
                                                                            ControlToValidate="cbo_cluster" CssClass="texto" ErrorMessage="Selecione um tipo de Cluster para continuar."
                                                                            Font-Bold="True" ToolTip="O campo Cluster deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação Modelo de Contrato:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:Label ID="lbl_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" width="23%">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema - Últimos Modelos de Contrato</TD>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="texto" align="right" width="23%">
                                                                        </td>
                                                                    <TD>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="texto" align="center" colspan="2">
                                                                        <anthem:GridView ID="gridcontratohistorico" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            CellPadding="4" CssClass="texto" DataKeyNames="id_pessoa_contrato" Font-Names="Verdana"
                                                                            Font-Size="XX-Small" Height="24px" PageSize="15" UpdateAfterCallBack="True"
                                                                            Width="90%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="dt_modificacao" HeaderText="Modifica&#231;&#227;o" ReadOnly="True" DataFormatString="{0:G}" />
                                                                                <asp:BoundField DataField="ds_login" HeaderText="Modificador" ReadOnly="True" />
                                                                                <asp:BoundField DataField="cd_contrato" HeaderText="Contrato" ReadOnly="True" />
                                                                                <asp:BoundField DataField="nm_contrato" HeaderText="Descri&#231;&#227;o" ReadOnly="True" />
                                                                                <asp:BoundField DataField="dt_inicio_contrato" HeaderText="In&#237;cio" ReadOnly="True" DataFormatString="{0:d}" />
                                                                                <asp:BoundField DataField="dt_fim_contrato" HeaderText="Fim" ReadOnly="True" DataFormatString="{0:d}" />
                                                                                <asp:BoundField DataField="dt_rescisao" DataFormatString="{0:d}" HeaderText="Rescis&#227;o" />
                                                                                <asp:BoundField DataField="nr_adicional_volume" HeaderText="Adic. Volume" ReadOnly="True" />
                                                                                <asp:BoundField DataField="nm_cluster" HeaderText="Modelo Relac." ReadOnly="True" />
                                                                                <asp:BoundField DataField="nm_situacao_pessoa_contrato" HeaderText="Situa&#231;&#227;o"
                                                                                    ReadOnly="True" />
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                    </td>
                                                                </tr>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" OnClientClick="if (confirm('Qualquer alteração no Modelo De Contrato será enviado para aprovações em 1o e 2o níveis. Deseja realmente salvar o registro?' )) return true;else return false;">Salvar</asp:LinkButton></TD>
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
					<TD style="width: 9px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_contrato" runat="server" AutoUpdateAfterCallBack="True" />
        </form>
	</body>
</HTML>
