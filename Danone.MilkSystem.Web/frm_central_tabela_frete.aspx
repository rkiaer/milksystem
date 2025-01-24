<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_tabela_frete.aspx.vb" Inherits="frm_central_tabela_frete" %>

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
    <title>frm_central_tabela_frete</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
	<script type="text/javascript"> 

    function ShowDialogItem() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_item = document.getElementById("hf_id_item");
           	     
        szUrl = 'lupa_item.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_item.value=retorno;
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">

			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Tabela de Fretes</STRONG></TD>
					<TD style="width: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2"  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" />
                                    <anthem:LinkButton ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <anthem:LinkButton ID="lk_concluir" runat="server" style="middle" ValidationGroup="vg_salvar">Salvar</anthem:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
					<TABLE id="Table7"  cellSpacing="0" cellPadding="2" width="100%" border="0">
						<TR>
							<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Dados </TD>
						</TR>
                        
                        <tr>
                            <td align="right" class="texto" width="23%" style="height: 23px">
                                <span id="Span2" class="obrigatorio">*</span><strong>Estabelecimento:</strong></td>
                            <td width="77%" style="height: 23px">
                                &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" AutoPostBack="false">
                                </anthem:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                    CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                        </tr>

						<TR id="tr_transportador" runat="server">
							<TD class="texto" align="right" width="23%" style="height: 13px"><span id="Span1" class="obrigatorio">*</span><STRONG> Transportador Central:</STRONG></TD>
							<TD style="height: 13px" >
				                &nbsp;<anthem:DropDownList ID="cbo_transportador" runat="server"
                                    CssClass="texto" AutoPostBack="false">
                                </anthem:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_transportador"
                                    CssClass="texto" ErrorMessage="Preencha o campo Tranportador Central para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator></TD>
						</TR>
						<tr>
                            <TD class="texto" align="right" width="23%" style="height: 13px">
                                <span id="Span4" class="obrigatorio">*</span><STRONG> Item:</strong></td>
                            <TD style="height: 13px" >
                                &nbsp;<anthem:TextBox ID="txt_cd_item" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                    CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>
                                &nbsp;
                                <anthem:ImageButton ID="btn_lupa_item" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Itens" Width="15px" AutoUpdateAfterCallBack="true" />
                                <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_cd_item"
                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Item para continuar ou selecione-o pela lupa."
                                    Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O campo Código do Item deve ser informado.">[!]</asp:RequiredFieldValidator><asp:CustomValidator ID="cv_item" runat="server" CssClass="texto" ErrorMessage="Item não cadastrado!"
                                    Font-Bold="true" Text="[!]" ToolTip="Item Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="texto" width="23%">
                                <strong>Unidade de Medida :</strong></td>
                            <td align="left">
                                &nbsp;<anthem:Label ID="lbl_unidade_medida" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                        </tr>
                        <tr>
                            <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                <strong>Estado Origem:</strong></td>
                            <TD class="texto" style="HEIGHT: 22px">
                                &nbsp;<anthem:DropDownList ID="cbo_estado_origem" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" AutoCallBack="True">
                                </anthem:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estado_origem"
                                    CssClass="texto" ErrorMessage="Preencha o campo Estado Origem para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                <strong>Cidade Origem:</strong></td>
                            <TD style="HEIGHT: 22px">
                                &nbsp;<anthem:DropDownList ID="cbo_cidade_origem" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Enabled="False">
                                </anthem:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_cidade_origem"
                                    CssClass="texto" ErrorMessage="Preencha o campo Cidade Origem para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                <strong>Estado Destino:</strong></td>
                            <TD class="texto" style="HEIGHT: 22px">
                                &nbsp;<anthem:DropDownList ID="cbo_estado_destino" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" AutoCallBack="True">
                                </anthem:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estado_destino"
                                    CssClass="texto" ErrorMessage="Preencha o campo Estado Destino para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                <strong>Cidade Destino:</strong></td>
                            <TD style="HEIGHT: 22px">
                                &nbsp;<anthem:DropDownList ID="cbo_cidade_destino" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Enabled="False">
                                </anthem:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_cidade_destino"
                                    CssClass="texto" ErrorMessage="Preencha o campo Cidade Destino para continuar."
                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                        </tr>

                        <tr>
                            <td align="right" class="texto" width="23%" style="height: 23px">
                                <strong>Data Cotação: </strong>
                            </td>
                            <td style="height: 23px">
                                &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_cotacao" runat="server" CssClass="texto" Width="84px"></cc4:OnlyDateTextBox></td>
                        </tr>
                        <tr><TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Veículos</td></tr>
                        <tr>
                            <TD class="texto" align=center colspan="2">
                            <br />
                            <anthem:GridView ID="gridVeiculos" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                CellPadding="4" CssClass="texto" DataKeyNames="id_veiculocentralcompras" Font-Names="Verdana"
                                Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True" Width="80%" AddCallBacks="False">
                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                <Columns>
                                    <asp:BoundField DataField="nm_veiculocentralcompras" HeaderText="Ve&#237;culo" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="Valor Frete">
                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_valor_frete" runat="server" CssClass="texto" Width="96px" MaxLength="15" Text='<%# bind("nr_valor_frete") %>' DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="2" __designer:wfdid="w7"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id_veiculocentralcompras" HeaderText="id_veiculocentralcompras" ReadOnly="True" Visible="False" />
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </anthem:GridView>
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<br />
        &nbsp;</TD>
                        </tr>

						<TR id="tr_dados_sitema" runat="server">
							<TD colSpan="2">
								<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">Dados do Sistema</TD>
									</TR>
		                            <tr>
                                        <TD class="texto" align="right" width="23%">
                                            <strong>Situação:</strong></td>
                                        <TD>
                                            &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto">
                                            </anthem:DropDownList></td>
                                    </tr>
                                    <TR>
										<TD class="texto" align="right" width="23%">
                                            <strong>Modificador:</strong></TD>
										<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
									</TR>
									<TR>
										<TD class="texto" align="right">
                                            <strong>Data Modificação:</strong></TD>
										<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                            <anthem:CustomValidator ID="cv_veiculos" runat="server" ForeColor="White" ValidationGroup="vg_salvar">{!}</anthem:CustomValidator></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>

						</TD>
					<TD>&nbsp;</TD>
				</TR>
			
				<TR>
				    <TD ></TD>
				    <TD>
					    <TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD class="faixafiltro1a"  vAlign="middle" align="left" 
								    background="img/faixa_filro.gif">
                                    &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
								    |
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <anthem:LinkButton ID="lk_concluir_footer" runat="server" ValidationGroup="vg_salvar">Salvar</anthem:LinkButton></TD>
							    <TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
								    colSpan="4">&nbsp;</TD>
						    </TR>
					    </TABLE>
				    </TD>
				    <TD ></TD>
			    </TR>

			</TABLE>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:ValidationSummary ID="ValidationSummary2" runat="server" AutoUpdateAfterCallBack="True"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <!-- <anthem:HiddenField ID="hf_id_linha" runat="server" AutoUpdateAfterCallBack="true" /> -->
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
        </div>

                </form>
	</body>
</HTML>
