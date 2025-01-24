<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_qualidade_motor.aspx.vb" Inherits="lst_relatorio_qualidade_motor" %>

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
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<meta http-equiv="refresh" content="30; URL=lst_relatorio_qualidade_motor.aspx">

	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
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
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>	
	
		<form id="Form1" method="post" runat="server">
			
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Relatório Extrato Anual do Produtor&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td1" runat="server"><BR>
						<TABLE class="borda" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Mes/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="dt_referencia" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="76px"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dt_referencia"
                                        CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto" ValidationGroup="gv_estabel"
                                        Width="188px">
                                    </anthem:DropDownList>
                                    &nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="O Estabelecimento deve ser informado."
                                        Font-Bold="True" InitialValue="0">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" width="20%">
                                    Código Produtor:</td>
                                <td>
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    &nbsp;
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    <anthem:ImageButton ID="img_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" /></td>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/btn_gerarrelatorio.gif" ></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="destino">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="descricao" HeaderText="Relatorio" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="inicio_rel" HeaderText="Data Inicio Exec" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="final_rel" HeaderText="Data Fim Exec." >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="status" HeaderText="C&#243;digo Status" />
                                                <asp:BoundField DataField="nm_status_relatorio" HeaderText="Descri&#231;&#227;o Status" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Arquivo gerado">
                                                    <itemtemplate>
<anthem:HyperLink id="hl_download" runat="server" __designer:wfdid="w1">Clique aqui para download</anthem:HyperLink>
</itemtemplate>
                                                    <itemstyle wrap="False" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_login" HeaderText="Usu&#225;rio">
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
			
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
		</form>
	</body>
</HTML>
