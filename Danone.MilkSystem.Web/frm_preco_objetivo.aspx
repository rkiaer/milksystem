<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_preco_objetivo.aspx.vb" Inherits="frm_preco_objetivo" %>

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
    <title>Conta Parcelada</title>
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Preço Objetivo</STRONG></TD>
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
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
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
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <span class="obrigatorio">*</span><strong>Ano:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ano" runat="server" CssClass="texto"
                                                                Width="8%" MaxLength="4"></cc3:OnlyNumbersTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Ano para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 18%">
                                                            <span class="obrigatorio">*</span><strong>Técnico:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_tecnico" runat="server" CssClass="texto" MaxLength="10" Width="48px" AutoUpdateAfterCallBack="true" AutoCallBack="true"></anthem:TextBox>
                                                            &nbsp;    <anthem:imagebutton ID="bt_lupa_tecnico" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Técnicos"   AutoUpdateAfterCallBack="true" />
                                                            <anthem:Label ID="lbl_nm_tecnico" runat="server"  CssClass="texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Height="16px"></anthem:Label>
                                                             &nbsp;
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_cd_tecnico"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Técnico para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cmv_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Técnico não cadastrado." SetFocusOnError="True" CssClass="texto" ValidationGroup="vg_salvar" Font-Bold="True">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr visible="false" runat="server">
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Preço Base</TD>
                                                    </tr>
                                                    <tr visible="false" runat="server">
                                                        <td align="right" class="texto" style="height: 5px; width: 18%;" valign="top">
                                                        </td>
                                                        <td align="left" style="height: 5px" width="85%">
                                                            &nbsp;&nbsp; &nbsp;<asp:Label ID="Label13" runat="server" CssClass="textobold" Text="Jan"
                                                                Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label14" runat="server" CssClass="textobold" Text="Fev" Width="28px"></asp:Label>&nbsp;
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label15" runat="server" CssClass="textobold" Text="Mar" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label16" runat="server" CssClass="textobold" Text="Abr" Width="28px"></asp:Label>&nbsp;
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label17" runat="server" CssClass="textobold" Text="Mai" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label18" runat="server" CssClass="textobold" Text="Jun" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label19" runat="server" CssClass="textobold" Text="Jul" Width="28px"></asp:Label>
                                                            &nbsp;&nbsp; &nbsp;
                                                            <asp:Label ID="Label20" runat="server" CssClass="textobold" Text="Ago" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label21" runat="server" CssClass="textobold" Text="Set" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;
                                                            <asp:Label ID="Label22" runat="server" CssClass="textobold" Text="Out" Width="28px"></asp:Label>
                                                            &nbsp; &nbsp; &nbsp;<asp:Label ID="Label23" runat="server" CssClass="textobold" Text="Nov"
                                                                Width="28px"></asp:Label>
                                                            &nbsp; &nbsp;&nbsp;
                                                            <asp:Label ID="Label24" runat="server" CssClass="textobold" Text="Dez" Width="28px"></asp:Label></td>
                                                    </tr>
                                                    <tr  visible="false" runat="server">
                                                        <td align="right" class="texto" valign="top" style="width: 18%">
                                                            <strong>R$ / lt:</strong></td>
                                                        <td width="85%" align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_preco_base_01" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_02" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_03" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_04" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_05" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_06" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_07" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_08" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_09" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_10" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_11" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <cc6:OnlyDecimalTextBox ID="txt_preco_base_12" runat="server" CssClass="texto"
                                                                Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px; width: 18%;">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
                                                                <tr  visible="false" runat="server">
                                                                    <TD class="titmodulo" width="25%" colSpan="2" style="height: 15px">
                                                                        Adicional Região</td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <td align="right" class="texto" style="height: 5px; width: 18%;" valign="top">
                                                                    </td>
                                                                    <td align="left" style="height: 5px" width="85%">
                                                                        &nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" CssClass="textobold" Text="Jan"
                                                                            Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label2" runat="server" CssClass="textobold" Text="Fev" Width="28px"></asp:Label>&nbsp;
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label3" runat="server" CssClass="textobold" Text="Mar" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label4" runat="server" CssClass="textobold" Text="Abr" Width="28px"></asp:Label>&nbsp;
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label5" runat="server" CssClass="textobold" Text="Mai" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label6" runat="server" CssClass="textobold" Text="Jun" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label7" runat="server" CssClass="textobold" Text="Jul" Width="28px"></asp:Label>
                                                                        &nbsp;&nbsp; &nbsp;
                                                                        <asp:Label ID="Label8" runat="server" CssClass="textobold" Text="Ago" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label9" runat="server" CssClass="textobold" Text="Set" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label10" runat="server" CssClass="textobold" Text="Out" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp; &nbsp;<asp:Label ID="Label11" runat="server" CssClass="textobold" Text="Nov"
                                                                            Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;&nbsp;
                                                                        <asp:Label ID="Label12" runat="server" CssClass="textobold" Text="Dez" Width="28px"></asp:Label></td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>R$ / lt:</strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_adic_reg_01" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_02" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_03" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_04" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_05" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_06" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_07" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_08" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_09" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_10" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_11" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_reg_12" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox></td>
                                                                </tr>
                                                                <tr visible="false" runat="server">
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="titmodulo" width="25%" colSpan="2" style="height: 15px">
                                                                        Adicional Mercado</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 5px; width: 18%;" valign="top">
                                                                    </td>
                                                                    <td align="left" style="height: 5px" width="85%">
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label49" runat="server" CssClass="textobold" Text="Jan" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label50" runat="server" CssClass="textobold" Text="Fev" Width="28px"></asp:Label>&nbsp;
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label51" runat="server" CssClass="textobold" Text="Mar" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label52" runat="server" CssClass="textobold" Text="Abr" Width="28px"></asp:Label>&nbsp;
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label53" runat="server" CssClass="textobold" Text="Mai" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label54" runat="server" CssClass="textobold" Text="Jun" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label55" runat="server" CssClass="textobold" Text="Jul" Width="28px"></asp:Label>
                                                                        &nbsp;&nbsp; &nbsp;
                                                                        <asp:Label ID="Label56" runat="server" CssClass="textobold" Text="Ago" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label57" runat="server" CssClass="textobold" Text="Set" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;
                                                                        <asp:Label ID="Label58" runat="server" CssClass="textobold" Text="Out" Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp; &nbsp;<asp:Label ID="Label59" runat="server" CssClass="textobold" Text="Nov"
                                                                            Width="28px"></asp:Label>
                                                                        &nbsp; &nbsp;&nbsp;
                                                                        <asp:Label ID="Label60" runat="server" CssClass="textobold" Text="Dez" Width="28px"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>R$ / lt:</strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_adic_merc_01" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_02" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_03" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_04" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_05" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_06" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_07" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_08" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_09" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_10" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_11" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_adic_merc_12" runat="server" CssClass="texto"
                                                                            Width="40px" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                    </td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <TD class="titmodulo" width="25%" colSpan="2" style="height: 15px">
                                                                        Adicional Volume</td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <td align="right" class="texto" style="height: 5px; width: 18%;" valign="top">
                                                                    </td>
                                                                    <td align="left" class="texto" style="height: 5px" width="85%">
                                                                        &nbsp;&nbsp;<anthem:DropDownList ID="cbo_mes" runat="server" CssClass="texto" Width="138px" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                                                        </anthem:DropDownList>
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Grupo Faixas: &nbsp;&nbsp;<anthem:DropDownList
                                                                            ID="cbo_grupo_faixas" runat="server" CssClass="texto" Width="138px" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                                                        </anthem:DropDownList>
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <td align="right" class="texto" valign="top" style="width: 18%">
                                                                        <strong>
                                                                            </strong></td>
                                                                    <td width="85%" align="left">
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr  visible="false" runat="server">
                                                                    <td align="right" style="height: 14px; width: 18%;">
                                                                    </td>
                                                                    <td style="height: 14px">
                                                                        <anthem:GridView ID="gridResults" runat="server" AddCallBacks="False" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                            DataKeyNames="id_faixa_volume" Font-Names="Verdana" Font-Size="XX-Small" PageSize="5"
                                                                            UpdateAfterCallBack="True" Width="60%">
                                                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                            <HeaderStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="nm_faixa_volume" HeaderText="Faixa" ReadOnly="True" />
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="Adicional (R$)">
                                                                                    <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_adicional_volume" runat="server" Width="75px" CssClass="texto" Text='<%# bind("nr_adic_volume") %>' MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w11" DecimalSymbol=","></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                                                    <itemstyle width="20%" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </anthem:GridView>
                                                                        </td>
                                                                </tr>
																<TR  visible="false" runat="server">
																	<TD class="texto" align=center width="23%" colSpan="2">
                                                                        <anthem:Label ID="lbl_novo" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"
                                                                            Visible="False">Escolha um Grupo de Faixas para o cadastrar os Adicionais de Volume para mes.</anthem:Label>
                                                                    </TD>
																</TR>
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema</TD>
																</TR>
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
														</TD>
													</TR>
													<TR>
														<TD style="width: 18%">&nbsp;</TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
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
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
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
