<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_resfriamento.aspx.vb" Inherits="frm_resfriamento" %>

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
    <title>Novo Transit Point</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
	<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        if (idcboestabel == "0")
        {
            alert("Para acessar a lista de transportadores, o estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_transportador.aspx?id_estabelecimento='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
         }
    }            
    </script>
    <script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var idtransportador;
        var retorno="";
   	    var szUrl;
   	    
   	    idtransportador = document.getElementById("hf_id_pessoa").value;
        if (idtransportador == "0")
        {
            alert("Para acessar a lista de veículos, o transportador deve ser informado!");
        }
        else
        {
            szUrl = 'lupa_veiculo.aspx?id='+idtransportador+'';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        }  
    }          
</script>
	<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx?categoria=D';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">

			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Resfriamento</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo Resfriamento</anthem:LinkButton>
                                    &nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" class="texto">
						<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%" class="texto">
												<TABLE id="Table7"  cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Descrição</TD>
													</TR>
													<TR >
														<TD class="texto" align="right" width="23%"><STRONG><span style="color: #ff0000">*</span><strong>Estabelecimento:</strong></STRONG></TD>
														<TD width="77%">&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" AutoCallBack="true">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="False" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator>
                                                            </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span5" class="obrigatorio">*</span><strong>Unidade Transit Point:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_transit_point_unidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_transit_point_unidade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Unidade Transit Point para continuar."
                                                                Font-Bold="False" InitialValue="0" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
													<TR id="TrProdutor" runat="server">
														<TD class="texto" align="right" width="23%" style="height: 13px"><span id="Span3" class="obrigatorio">*</span><STRONG> <strong>Data Referência:</strong></STRONG></TD>
														<TD style="height: 13px" >
    										                &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" DateMask="MonthYear" Width="80px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Referência para continuar."
                                                                Font-Bold="False" ToolTip="Data Referência deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span1" class="obrigatorio">*</span><strong>Valor:</strong></td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor" runat="server" CssClass="texto" MaxCaracteristica="8"
                                                                MaxMantissa="4" Style="text-align: right" Width="80px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_valor"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Valor para continuar." Font-Bold="False"
                                                                ToolTip="Valor deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                             
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Dados do Sistema</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Situação:</strong></td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Modificador:</strong></td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span4" class="obrigatorio"></span><strong>Data Modificação:</strong></td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<table id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
											<TD class="faixafiltro1a" valign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</table>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
			</table>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                	    <div visible="false">
                            &nbsp;<!-- <anthem:HiddenField ID="hf_id_linha" runat="server" AutoUpdateAfterCallBack="true" /> -->
        </div>

                </form>
	</body>
</html>
