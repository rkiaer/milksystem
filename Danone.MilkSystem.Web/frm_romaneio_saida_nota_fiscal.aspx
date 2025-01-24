<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_nota_fiscal.aspx.vb" Inherits="frm_romaneio_saida_nota_fiscal" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Romaneio Saída - Nota Fiscal</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialogPreRomaneio() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_romaneio = document.getElementById("hf_id_romaneio");
   	    var idtransitpoint
   	    idtransitpoint = document.getElementById("hf_id_transit_point").value;

        szUrl = 'lupa_transit_point_pre_romaneio.aspx?id='+idtransitpoint+'';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:700px;edge:raised;dialogHeight:600px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_romaneio.value=retorno;
        } 
    }            

</script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 28px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 28px;"><STRONG>Romaneio Saída - Nota Fiscal&nbsp;&nbsp;</STRONG></TD>
					<TD style="width: 10px; height: 28px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD ></TD>
					<TD valign="top" align="center" background="images/faixa_filro.gif" class="texto" >
						<TABLE id="Table20"  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp;&nbsp; &nbsp;<anthem:LinkButton ID="lk_acao" runat="server"
                                        ToolTip="Solicitar Nota Fiscal ao Romaneio de Saída" ValidationGroup="vg_acao" AutoUpdateAfterCallBack="True" Enabled="False" Visible="False">Registrar Início Processo Nota Fiscal</anthem:LinkButton>
                                    &nbsp;&nbsp;&nbsp; | &nbsp;&nbsp;
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/icone_anexar.gif" /><anthem:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio" AutoUpdateAfterCallBack="True" Enabled="False">Anexar Documento</anthem:LinkButton>
                                    &nbsp; &nbsp;&nbsp; &nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD >&nbsp;</TD>
				</TR>
				<tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD  style="font-size: 8px">

                        <TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Romaneio de Saída</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table19" cellSpacing="0" cellPadding="2" width="95%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="height: 21px; border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid;">
                                    Romaneio Saída:</td>
                                <td style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_romaneio_saida" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 21px; border-right: #f0f0f0 1px solid; width: 10%; border-bottom: #f0f0f0 1px solid;">
                                    Abertura:</td>
                                <td style="height: 21px; border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_dt_abertura" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 21px; border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;">
                                    Situação:</td>
                                <td style="height: 21px; width: 17%; border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_romaneio_situacao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    Peso Líquido:</td>
                                <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_peso_liquido_romaneio" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 10%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    Pesagem Ini.:</td>
                                <td style="border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_pesagem_inicial" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    Pesagem Final:</td>
                                <td style="width: 17%; border-bottom: #f0f0f0 1px solid; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_pesagem_final" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    Volume Estimado:</td>
                                <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_volume_estimado" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 10%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                </td>
                                <td style="border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    &nbsp;</td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 13%; border-bottom: #f0f0f0 1px solid;
                                    height: 21px">
                                    Romaneio Entrada:</td>
                                <td style="width: 17%; border-bottom: #f0f0f0 1px solid; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_id_romaneio_entrada" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr runat="server" id="tr_situacaonota" visible="true">
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%; height: 21px">
                                    Situação Nota Fiscal:</td>
                                <td style="border-right: #f0f0f0 1px solid; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_situacao_nf" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 10%; height: 21px">
                                    Últ.Atualização:</td>
                                <td style="border-right: #f0f0f0 1px solid; width: 13%; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_dt_modificacao_nf" runat="server" UpdateAfterCallBack="True"></anthem:Label>
                                </td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 13%; height: 21px">
                                    Usuário:</td>
                                <td style="width: 17%; height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_usuario_nf" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD  style="font-size: 8px">
                        <br />
                        <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Destinatário</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="2" width="95%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr style="HEIGHT: 21px;">
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" >
                                    Nome Destinatário:</td>
                                <td style="border-bottom: #f0f0f0 1px solid;" colspan="5">
                                    &nbsp;<anthem:Label ID="lbl_nm_destino" runat="server"></anthem:Label></td>
                            </tr>
                            <tr style="HEIGHT: 21px;">
                                <TD style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="right">
                                    CNPJ:</td>
                                <TD style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" colspan="3">
                                    &nbsp;<anthem:Label ID="lbl_cnpj_destino" runat="server"></anthem:Label>
                                </td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    Inscrição Estadual:</td>
                                <td style="border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_ie_destino" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr style="HEIGHT: 21px;">
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    Endereço:</td>
                                <td colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_endereco_destino" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    Número:</td>
                                <td style="border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_endereco_numero" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr style="HEIGHT: 21px;">
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%;">
                                    Município:</td>
                                <td style="border-right: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_cidade_destino" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 10%;">
                                    CEP:</td>
                                <td style="border-right: #f0f0f0 1px solid; width: 13%;">
                                    &nbsp;<anthem:Label ID="lbl_cep_destino" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 13%;">
                                    UF:</td>
                                <td style="width: 17%;">
                                    &nbsp;<anthem:Label ID="lbl_uf_destino" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD  style="font-size: 8px" class="texto">
                        <br />
                        <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Emitente (Danone e empresas do Grupo)</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table7" cellSpacing="0" cellPadding="2" width="95%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="HEIGHT: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; width: 17%;" >
                                    CNPJ:</td>
                                <td style="border-bottom: #f0f0f0 1px solid;" colspan="5">
                                    &nbsp;<anthem:Label ID="lbl_emitente" runat="server"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 21px; border-right: #f0f0f0 1px solid;" align="right">
                                    CBU:</td>
                                <TD style="height: 21px;" colspan="5">
                                    &nbsp;<anthem:Label ID="lbl_cbu" runat="server"></anthem:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>

                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD  style="font-size: 8px">
                        <br />
                        <TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados da Transportadora</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table9" cellSpacing="0" cellPadding="2" width="95%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" >
                                    Nome Transportadora:</td>
                                <td style="height: 21px;border-bottom: #f0f0f0 1px solid;" colspan="6">
                                    &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="right">
                                    Município:</td>
                                <TD style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" colspan="4">
                                    &nbsp;<anthem:Label ID="lbl_cidade_transportador" runat="server"></anthem:Label>
                                </td>
                                <td align="right" style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; width: 8%;">
                                    UF:</td>
                                <td style="height: 21px; border-bottom: #f0f0f0 1px solid; width: 15%;">
                                    &nbsp;<anthem:Label ID="lbl_uf_transportador" runat="server"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    CNPJ:</td>
                                <td colspan="6" style="height: 21px;border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:Label ID="lbl_cnpj_transportador" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px;border-right: #f0f0f0 1px solid; width: 17%;" rowspan="2">
                                    <span style="color: #ff0000">*</span>Frete por Conta:</td>
                                <td style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="center">
                                    Danone</td>
                                <td align="center" style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    <anthem:Image ID="img_frete_danone" runat="server" ImageUrl="~/img/ico_chk_false.gif" /></td>
                                <td style="height: 21px; border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" align="center" colspan="2">
                                    Placa do Veículo:</td>
                                <td align="center" style="height: 21px; border-bottom: #f0f0f0 1px solid;" colspan="2">
                                    <anthem:Label ID="lbl_placa" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; width: 16%; ">
                                    Destinatário</td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; width: 4%; ">
                                    <anthem:Image ID="img_frete_destinatario" runat="server" ImageUrl="~/img/ico_chk_false.gif" /></td>
                                <td align="center" colspan="2" style="height: 21px;border-right: #f0f0f0 1px solid; width: 40%;
                                    ">
                                    Valor do Frete Combinado com a Transportadora:</td>
                                <td align="center" colspan="2">
                                    R$
                                    <anthem:Label ID="lbl_valor_frete" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD  style="font-size: 8px" class="texto" align="center">
                        <br />
                        <TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Natureza de Operação</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table11" cellSpacing="0" cellPadding="2" width="95%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="height: 21px;border-right: #f0f0f0 1px solid; width: 25%;">
                                    <anthem:Label ID="lbl_natureza_operacao" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td style="height: 21px;border-right: #f0f0f0 1px solid; width: 3%;" align="center">
                                    <anthem:CheckBox ID="chk_no_1" runat="server" Text=" " /></td>
                                <td style="height: 21px;border-right: #f0f0f0 1px solid; width: 28%;" align="center">
                                    <anthem:Label ID="lbl_ds_outros" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" colspan="1">
                                    <anthem:Label ID="lbl_descricao_natureza" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                        </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD class="texto" align="center"  >
                        <br />
                        <TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Material</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <br />
                        <TABLE  id="Table13" cellSpacing="0" cellPadding="2" width="100%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;" class="texto"   >
                            <tr>
                                <td align="center" style="border-right: #f0f0f0 1px solid; width: 8%; border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    <span style="color: #ff0000">*</span>Qtde</td>
                                <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; width: 4%; font-weight: bold;" align="center">
                                    Un</td>
                                <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; width: 10%; font-weight: bold;" align="center">
                                    Cód.Material SAP</td>
                                <td align="center" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; width: 17%; font-weight: bold;">
                                    Descrição Material SAP</td>
                                <td align="center" colspan="1" style="border-right: #f0f0f0 1px solid; width: 8%; border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    <span style="color: #ff0000">*</span>Peso Líquido</td>
                                <td align="center" colspan="1" style="border-right: #f0f0f0 1px solid; width: 8%;
                                    border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    Peso Bruto</td>
                                <td align="center" colspan="1" style="border-right: #f0f0f0 1px solid; width: 11%;
                                    border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    <span style="color: #ff0000">*</span>Preço Unit. (s/imposto)</td>
                                <td align="center" colspan="1" style="border-right: #f0f0f0 1px solid; width: 13%;
                                    border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    Valor Total</td>
                                <td align="center" colspan="1" style="border-right: #f0f0f0 1px solid; width: 10%;
                                    border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    Nota Fiscal Origem / Aquisição</td>
                                <td align="center" colspan="1" style="border-bottom: #f0f0f0 1px solid; font-weight: bold;">
                                    Nr Contrato</td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    <cc3:OnlyNumbersTextBox ID="txt_qtde" runat="server"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Width="70px" style="text-align: right" AutoPostBack="True"></cc3:OnlyNumbersTextBox></td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <anthem:Label ID="lbl_unidade" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <anthem:Label ID="lbl_cd_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True">Creme Leite 40% MG</anthem:Label></td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <cc3:OnlyNumbersTextBox ID="txt_peso_liquido" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Style="height: 21px;text-align: right" Width="70px"></cc3:OnlyNumbersTextBox></td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <cc3:OnlyNumbersTextBox ID="txt_peso_bruto" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Style="text-align: right" Width="70px"></cc3:OnlyNumbersTextBox></td>
                                <td align="right" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; " class="texto">
                                    R$
                                    <cc4:OnlyDecimalTextBox ID="txt_preco_unitario" runat="server" CssClass="texto"
                                        MaxCaracteristica="5" MaxLength="9" Style="height: 21px;text-align: right" Width="80px" AutoUpdateAfterCallBack="True" AutoPostBack="True"></cc4:OnlyDecimalTextBox></td>
                                <td align="right" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    R$
                                    <anthem:Label ID="lbl_valor_total" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; ">
                                    <cc3:OnlyNumbersTextBox ID="txt_nota_origem" runat="server" AutoCallBack="True" CssClass="texto" Style="text-align: center" Width="80px"></cc3:OnlyNumbersTextBox></td>
                                <td align="center" colspan="1" style="height: 21px;border-bottom: #f0f0f0 1px solid; ">
                                    <cc3:OnlyNumbersTextBox ID="txt_nr_contrato" runat="server" AutoCallBack="True" CssClass="texto"
                                        MaxLength="15" Style="text-align: right" Width="80%"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                    </td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                    </td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" class="texto" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid;
                                    border-bottom: #f0f0f0 1px solid">
                                    </td>
                                <td align="right" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                </td>
                                <td align="center" colspan="1" style="height: 21px;border-bottom: #f0f0f0 1px solid">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="height: 21px;border-right: #f0f0f0 1px solid; font-weight: bold;
                                    border-bottom: #f0f0f0 1px solid">
                                    Espécie</td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid; font-weight: bold; border-bottom: #f0f0f0 1px solid">
                                    Volume</td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="right" class="texto" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid">
                                </td>
                                <td align="center" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; font-weight: bold;
                                    border-bottom: #f0f0f0 1px solid">
                                    Valor Total NF</td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="center" colspan="1">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="height: 21px;border-right: #f0f0f0 1px solid">
                                    <cc3:OnlyNumbersTextBox ID="txt_nr_especie" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Style="height: 21px;text-align: right" Width="128px"></cc3:OnlyNumbersTextBox></td>
                                <td align="center" style="height: 21px;border-right: #f0f0f0 1px solid">
                                    <cc3:OnlyNumbersTextBox ID="txt_volume_material" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" Style="height: 21px;text-align: right" Width="128px"></cc3:OnlyNumbersTextBox></td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="right" class="texto" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid">
                                </td>
                                <td align="right" colspan="1" style="height: 21px;border-right: #f0f0f0 1px solid; font-weight: bold;
                                    color: red">
                                    R$
                                    <anthem:Label ID="lbl_valor_total_nota" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        ForeColor="Red" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" colspan="1">
                                </td>
                                <td align="center" colspan="1">
                                </td>
                            </tr>
                        </table>
                        <anthem:CustomValidator ID="cv_acao" runat="server" AutoUpdateAfterCallBack="True"
                            ForeColor="White" ValidationGroup="vg_acao">[!]</anthem:CustomValidator></td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>

                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD align="center" class="texto" >
                        <TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Observações</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <br />
                        <TABLE class="texto" id="Table15" cellSpacing="0" cellPadding="2" width="100%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid;">
                                    Depósito:</td>
                                <td style="border-bottom: #f0f0f0 1px solid;" align="left">
                                    &nbsp;<anthem:TextBox ID="txt_ds_deposito" runat="server" CssClass="texto" MaxLength="50"
                                        Width="65%"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid">
                                    Batch:</td>
                                <td align="left" style="border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:TextBox ID="txt_ds_batch" runat="server" CssClass="texto" MaxLength="100"
                                        TextMode="MultiLine" Width="65%"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;">
                                    Lacres:</td>
                                <td align="left" style="border-bottom: #f0f0f0 1px solid;">
                                    &nbsp;<anthem:TextBox ID="txt_lacres" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="100" TextMode="MultiLine" Width="65%"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid;">
                                    Outros:</td>
                                <td align="left">
                                    &nbsp;<anthem:TextBox ID="txt_observacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="250" TextMode="MultiLine" Width="95%"></anthem:TextBox></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD align="center" class="texto" >
                        <TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Solicitante</td>
                                <TD style="height: 19px; width: 1px;">
                                </td>
                            </tr>
                        </table>
                        <br />
                        <TABLE class="texto" id="Table16" cellSpacing="0" cellPadding="2" width="100%" style="border-right: #f0f0f0 1px solid; border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;"   >
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; width: 17%; border-bottom: #f0f0f0 1px solid; height: 21px;">
                                    Solicitante:</td>
                                <td style="border-bottom: #f0f0f0 1px solid; height: 21px;" align="left">
                                    &nbsp;<anthem:Label ID="lbl_nm_usuario" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 21px;">
                                    Departamento:</td>
                                <td align="left" style="border-bottom: #f0f0f0 1px solid; height: 21px;">
                                    &nbsp;<anthem:Label ID="lbl_depto" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 21px;">
                                    Centro de Custo:</td>
                                <td align="left" style="border-bottom: #f0f0f0 1px solid; height: 21px;">
                                    &nbsp;<anthem:Label ID="lbl_centro_custo" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-right: #f0f0f0 1px solid; height: 21px;">
                                    Data da Solicitação:</td>
                                <td align="left" style="height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_data_solicitacao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 21px; width: 10px;">
                    </td>
                </tr>

                <TR >
                <td></td>
					<TD colSpan="1" class="texto">
						<TABLE id="Table21" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD class="titmodulo"  style="height: 19px">
                                    Documento Anexado</TD>
							</TR>
                            <tr>
                                <td align="center" class="texto">
                                    
                                    <table id="Table22" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                        <tr>
                                            <td align="center" class="texto" colspan="8">
                                                <br />
                                                <anthem:GridView ID="gridAnexos" runat="server" AutoGenerateColumns="False"
                                                    AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_romaneio_saida_nota_anexo"
                                                    Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                    UseAccessibleHeader="False" Visible="False" Width="98%" PageSize="30">
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                        ForeColor="White" HorizontalAlign="Left" />
                                                    <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                        HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Nome do Documento">
                                                            <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" Text='<%# Bind("nm_documento") %>' CssClass="texto" __designer:wfdid="w530"></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="nm_tipo_anexo" HeaderText="Tipo" >
                                                            <headerstyle horizontalalign="Center" />
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dt_criacao" HeaderText="Inclus&#227;o" DataFormatString="{0:dd/MM/yyyy hh:mm}" >
                                                            <headerstyle horizontalalign="Center" />
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nm_usuario" HeaderText="Usu&#225;rio" />
                                                        <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr.Nota" ReadOnly="True">
                                                            <headerstyle horizontalalign="Center" />
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ds_descricao" HeaderText="Descri&#231;&#227;o" Visible="False" />
                                                        <asp:TemplateField HeaderText="Download">
                                                            <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" __designer:wfdid="w531" Font-Underline="True">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                            <headerstyle horizontalalign="Center" />
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                                            <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w534" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w535" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w536"></asp:ValidationSummary> 
</edititemtemplate>
                                                            <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Visible="False" Text="Edit" __designer:wfdid="w532" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" ToolTip="Excluir Anexo Pedido" UpdateAfterCallBack="True" __designer:wfdid="w533" CommandName="delete" CommandArgument='<%# Bind("id_romaneio_saida_nota_anexo") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro?' )) return true;else return false;" ImageAlign="Baseline"></anthem:ImageButton> 
</itemtemplate>
                                                            <itemstyle horizontalalign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                            <itemtemplate>
<asp:Label id="lbl_id_romaneio_saida" runat="server" Text='<%# Bind("id_romaneio_saida") %>'></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_tipo_anexo" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_tipo_anexo" runat="server" Text='<%# Bind("id_tipo_anexo") %>' __designer:wfdid="w537"></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_origem" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_origem" runat="server" Text='<%# Bind("id_origem") %>'></asp:Label>
</itemtemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                </anthem:GridView>
                                               
                                            </td>
                                        </tr>
                                    </table>
                                   </td>
                            </tr>
						</TABLE>
					</TD>
				<td></td>
				</TR>

                <tr>
                    <TD colspan="3" style="HEIGHT: 20px;">
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 25px; width: 9px;">
                        &nbsp;</td>
                    <TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar_footer" runat="server" CausesValidation="False">voltar</asp:LinkButton></td>
                    <TD style="HEIGHT: 25px; width: 10px;">
                        &nbsp;</td>
                </tr>

                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD>
                        &nbsp;</td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_acao" />
            &nbsp;&nbsp;&nbsp; &nbsp;
            <anthem:HiddenField ID="hf_id_romaneio" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_transit_point" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
