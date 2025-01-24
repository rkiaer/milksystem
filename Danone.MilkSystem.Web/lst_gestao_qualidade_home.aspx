<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_gestao_qualidade_home.aspx.vb" Inherits="lst_gestao_qualidade_home" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Curva ABC - Produtores Compliance</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>


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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Gestão de Qualidade - Menu</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				
								<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
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
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Coleta para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3">
                                    </TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="3">
                                </td>
                                <td align="right">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>

				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td1" runat="server" >
						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" border="0" style="width: 100%" >
							<TR>
								<TD style="height: 12px; width: 1%" ></TD>
								<TD style="height: 12px; width: 15%;">
                                    &nbsp;</TD>
								<TD style="height: 12px; width: 80%;">
                                    &nbsp;</TD>
								<TD style="height: 12px; width: 1%">
                                    &nbsp;</TD>
							</TR>

                            <tr>
                            <td ></td>
                                <TD  align="center" style="border-bottom: gainsboro 1px groove; ">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/logo_danone_menino1.png" Width="70%" /></td>
                                <TD align="left" style="border-bottom: gainsboro 1px groove; ">
                                    <anthem:LinkButton ID="btn_danone_curvagestao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaamarelo" ValidationGroup="vg_salvar" Height="40px">Curva ABC Gestão</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_danone_grafico_dal" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvamarinho" Height="45px" ValidationGroup="vg_salvar">Gráficos de Gestão DAL </anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_danone_base_epl" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvamarinho" Height="56px" ValidationGroup="vg_salvar">Base Dados EPLs </anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_danone_grafico_epl" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvamarinho" Height="56px" ValidationGroup="vg_salvar">Gráficos Gestão EPLs </anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_danone_in76" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvared" Height="56px" ValidationGroup="vg_salvar">Desligamento IN76/77</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_danone_evolucao_bonus" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvamarinho" Height="56px" Width="20%" ValidationGroup="vg_salvar">Evolução de Bonificação de Qualidade</anthem:LinkButton></td>
                                <td  >
                                    </td>

                            </tr>
                            <tr>
                                <td style="height: 95px" >
                                </td>
                                <td align="center" style="border-bottom: gainsboro 1px groove; height: 95px;">
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/logo_educampo.png" /></td>
                                <td align="left" style="border-bottom: gainsboro 1px groove; height: 95px;">
                                    <anthem:LinkButton ID="btn_educampo_curvagestao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaamarelo" ValidationGroup="vg_salvar" Height="56px">Curva ABC Gestão</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_educampo_base" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaverde" Height="56px" ValidationGroup="vg_salvar">Base Dados Educampo</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_educampo_grafico_consultores" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaverde" Width="17%" ValidationGroup="vg_salvar">Gráficos Gestão Consultores Educampo</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_educampo_grafico_geral" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaverde" Width="15%" Height="56px" ValidationGroup="vg_salvar">Gráficos Gestão Educampo Geral</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_educampo_saving" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaverde" Width="14%" Height="56px" ValidationGroup="vg_salvar"  >Saving Educampo Geral</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_educampo_evolucao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaverde" Height="56px" ValidationGroup="vg_salvar">Evolução Resultados</anthem:LinkButton></td>
                                <td style="height: 95px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 95px" >
                                </td>
                                <td align="center" style="height: 95px" >
                                    <asp:Image ID="Image10" runat="server" ImageUrl="~/img/logo_comquali.png" Width="70%" /></td>
                                <td align="left" style="height: 95px" >
                                    <anthem:LinkButton ID="btn_comquali_curvagestao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaamarelo" ValidationGroup="vg_salvar" Height="56px">Curva ABC Gestão</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_comquali_base" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaazul" Height="56px" ValidationGroup="vg_salvar">Base Dados ComQuali CCS</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_comquali_grafico_consultores" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaazul" Width="20%" Height="56px" ValidationGroup="vg_salvar">Gráficos Gestão Consultores ComQuali CCS</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_comquali_grafico_pocos" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaazul" Width="16%" Height="56px" ValidationGroup="vg_salvar">Gráficos Gestão ComQuali CCS Poços</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="btn_comquali_evolucao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="btncurvagestao btncurvaazul" Height="56px" ValidationGroup="vg_salvar" >Evolução Resultados</anthem:LinkButton></td>
                                <td style="height: 95px" >
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                </td>
                                <td align="left">
                                </td>
                                <td>
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>


				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>

			<tr>
                <td style="width: 9px; height: 19px">
                </td>
                <td style="height: 19px" valign="middle">&nbsp;</td>
                <td style="width: 10px; height: 19px">
                </td>
            </tr>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        &nbsp;
        </div>
		</form>
	</body>
</HTML>
