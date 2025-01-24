<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_propriedade.aspx.vb" Inherits="lupa_propriedade" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Produtores</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
	</head>

	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<script type="text/javascript" language="javascript"> 
    function ShowDialogDadosProdutor() 
    
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

		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><StrONG>Seleção de Propriedades&nbsp;</StrONG></td>
					<td style="width: 10px; height: 25px;">&nbsp;</td>
				</tr>
				<TR>
					<TD style="width: 9px; height: 155px;">&nbsp;</TD>
					<TD id="td1" runat="server" style="height: 155px; ">
<br />						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr >
                                <TD style="HEIGHT: 20px" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px"  runat="server">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" CssClass="texto" Font-Bold="True" Display="Dynamic">[!]</asp:CompareValidator>
                                </td>
                            </tr>
			                <tr>
			                    <td width="20%" align="right" style="height: 20px">Código Produtor:</td>
								<td style="height: 20px">
                                        &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" Width="168px"></anthem:Label>
                                    &nbsp;<anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
    	                        </td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Propriedade:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto" Width="72px" MaxLength="10"></asp:TextBox></td>
                            </tr>
							<TR>
								<TD width="20%" align="right" style="height: 20px">&nbsp;Nome Propriedade:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;<asp:textbox id="txt_nm_propriedade" runat="server" cssclass="caixaTexto"
                                        width="272px" MaxLength="60"></asp:textbox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:Label ID="lbl_situacao" runat="server" Text=" Ativo " CssClass="CaixaTexto" ></asp:Label>
                                </TD>
							</TR>
							<tr>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></asp:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px; height: 155px;">&nbsp;</TD>
				</TR>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px; width: 717px;" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px; width: 10px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;"></td>
					<td vAlign="middle" style="height: 19px; width: 717px;">&nbsp;</td>
					<td style="height: 19px; width: 10px;"></td>
				</tr>
				
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" PageSize="5">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" SortExpression="cd_pessoa" FooterText="ttt" >
                                                    <headerstyle width="15%" horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" ReadOnly="True" SortExpression="nm_pessoa">
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade" HeaderText="C&#243;digo" SortExpression="id_propriedade" ReadOnly="True" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_propriedade" HeaderText="Nome" SortExpression="nm_propriedade" >
                                                    <headerstyle width="30%" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <headerstyle width="15%" />
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icon_ok.gif" Text="Button" CommandArgument='<%# Bind("id_propriedade") %>' __designer:wfdid="w1" CommandName="selecionar" CausesValidation="False"></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;">&nbsp;</td>
					<td vAlign="top" style="height: 19px; width: 717px;">&nbsp;
					</td>
					<td style="height: 19px; width: 10px;">&nbsp;</td>
				</tr>
			</table>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="z-index: 100;
                left: 168px; position: absolute; top: 528px" ValidationGroup="vg_pesquisar" ShowMessageBox="True" ShowSummary="False" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" />
		</form>
	</body>
</html>
