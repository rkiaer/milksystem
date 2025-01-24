<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_grupo_propriedades.aspx.vb" Inherits="frm_grupo_propriedades" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Grupo Propriedades</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	<script type="text/javascript" > 

    function ShowDialogProdutor() 
    
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

    function ShowDialogProdutorFilial() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa_filial = document.getElementById("hf_id_pessoa_filial");

        szUrl = 'lupa_produtor.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_pessoa_filial.value=retorno;
        } 

    }
    
    </script>
		<form id="Form1" method="post" runat="server">
            <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif);">
                        <strong>Grupo Propriedades</strong></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table3" height="12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; " vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
                                    |&nbsp;
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <anthem:LinkButton ID="lk_concluir" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" ValidationGroup="vg_salvar">Salvar</anthem:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" >&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
                <tr>
                    <td align="left" class="titmodulo" colspan="2" style="height: 10px">
                        Propriedade Matriz</td>
                </tr>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" align="center">
						<TABLE class="texto" id="Table2" cellSpacing="0" cellPadding="0" width="98%" border="0" >
                            <tr>
                                <TD style="width: 20%; height: 6px;" align="right"></td>
                                <TD style="height: 6px" >
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 24px;" width="15%">
                                    &nbsp;<span id="Span1" class="obrigatorio">*<span style="color: #000000">Estabelecimento:</span></span></td>
                                <td style="height: 24px" >
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Font-Bold="False"
                                        Operator="NotEqual" Type="Integer" ValidationGroup="vg_adicionar_matriz" ValueToCompare="0">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <TD style="width: 20%; height: 24px;" align="right">
                                    <strong><span style="color: #ff0000">*</span>Código Produtor:</strong></td>
                                <TD style="height: 24px" >
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="88px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:RequiredFieldValidator ID="rf_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_pessoa" CssClass="texto" ErrorMessage='Preencha o campo "Código Produtor" para continuar'
                                        InitialValue="0" ValidationGroup="vg_adicionar_matriz">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 24px; width: 20%;" align="right">
                                    <strong><span style="color: #ff0000">*</span>Propriedade Matriz:</strong></td>
                                <td align="right" style="text-align: left; height: 25px; " >
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_propriedade" runat="server" AutoPostBack="false" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" AutoCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_propriedade" CssClass="texto" ErrorMessage='Preencha o campo "Propriedade Matriz" para continuar' ValidationGroup="vg_adicionar_matriz" InitialValue="0">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp; &nbsp;
                                    <anthem:Button ID="btn_adicionar_matriz" runat="server" AutoUpdateAfterCallBack="True" Text="Adicionar" ValidationGroup="vg_adicionar_matriz" />
                                    <anthem:CustomValidator ID="cv_propriedadematriz" runat="server" Font-Bold="True"
                                        ForeColor="White" ValidationGroup="vg_adicionar_matriz">[!]</anthem:CustomValidator></td>
                                
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 24px">
                                </td>
                                <td align="right" style=" height: 25px; text-align: left">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td align="left" class="titmodulo" colspan="2" style="height: 10px">
                        Propriedades Filiais</td>
                </tr>
                <tr>
                    <TD style="width: 7px">
                        &nbsp;</td>
                    <TD rowspan="" align="center" valign="top" class="texto" >
                        <TABLE class="texto" id="Table4" cellSpacing="0" cellPadding="0" width="98%" border="0" >
                            <tr>
                                <TD style="width: 20%; height: 6px;" align="right">
                                </td>
                                <TD style="height: 6px" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <TD style="width: 20%; height: 24px;" align="right">
                                    <strong><span style="color: #ff0000">*</span>Código Produtor:</strong></td>
                                <TD style="height: 24px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa_filial" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="88px" Enabled="False"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor_filial" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" Enabled="False" />
                                    <anthem:Label ID="lbl_nm_pessoa_filial" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_pessoa_filial" CssClass="texto" ErrorMessage='Preencha o campo "Código Produtor Filial" para continuar'
                                        InitialValue="0" ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr style="font-weight: bold">
                                <td style="height: 24px; width: 20%;" align="right" class="texto">
                                    <span style="color: #ff0000">*</span>Propriedade Filial:</td>
                                <td align="right" style="text-align: left; height: 25px;" colspan="2">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_propriedade_filial" runat="server" AutoPostBack="false" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" AutoCallBack="True" Enabled="False">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_propriedade_filial" ErrorMessage='Preencha o campo "Propriedade Filial" para continuar'
                                        ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator>&nbsp; &nbsp;
                                    &nbsp;&nbsp;
                                    <anthem:Button ID="btn_adicionar" runat="server" AutoUpdateAfterCallBack="True" Text="Adicionar" ValidationGroup="vg_adicionar" Enabled="False" />
                                    <anthem:CustomValidator ID="cv_propriedadefilial" runat="server" Font-Bold="True"
                                        ForeColor="White" ValidationGroup="vg_adicionar">[!]</anthem:CustomValidator></td>
                                
                            </tr>
                        </table>
                        &nbsp;
                    </td>
                    <TD >
                        &nbsp;</td>
                </tr>
				
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD rowspan="" align="center" valign="top" class="texto" >
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="80%" UpdateAfterCallBack="True" PageSize="100" DataKeyNames="id_grupo_propriedades">
                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d Produtor" />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                                <asp:BoundField DataField="ds_tipo_propriedade" HeaderText="Tipo" />
                                                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_desativar" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CommandArgument='<%# bind("id_grupo_propriedades") %>' CommandName="Delete" __designer:wfdid="w17"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="5%" horizontalalign="Center" />
                                                    <itemstyle width="5%" horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="id_propriedade_matriz" HeaderText="id_propriedade_matriz" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w192"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_relacionamento" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_st_relacionamento" runat="server" Text='<%# Bind("st_tipo_propriedade") %>' __designer:wfdid="w195"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>

					                <tr>
                    <td align="left" class="titmodulo" colspan="2" style="height: 10px">
                        Dados do Sistema</td>
                </tr>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td2" runat="server" class="texto" align="center">
						<TABLE class="texto" id="Table6" cellSpacing="0" cellPadding="0" width="98%" border="0" >
                            <tr>
                                <TD style="width: 20%; height: 6px;" align="right"></td>
                                <TD style="height: 6px" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%" width="15%">
                                    &nbsp;<span id="Span3" class="obrigatorio">*<span style="color: #000000">Situação do Grupo:</span></span></td>
                                <td style="height: 20px" colspan="3">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_situacao" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        <table id="Table11" border="0" cellpadding="0" cellspacing="0" height="23" width="100%">
                            <tr>
                                <td align="left" background="img/faixa_filro.gif" class="faixafiltro1a" style="width: 265px"
                                    valign="middle" >
                                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <anthem:LinkButton ID="lk_concluirFooter" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" ValidationGroup="vg_salvar">Salvar</anthem:LinkButton></td>
                                <td align="right" background="img/faixa_filro.gif" class="faixafiltro1a" colspan="4"
                                    valign="middle">
                                    &nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" AutoUpdateAfterCallBack="true"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_adicionar_matriz" /><anthem:ValidationSummary ID="ValidationSummary1" runat="server" AutoUpdateAfterCallBack="true"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_adicionar" />
            <asp:HiddenField ID="hf_id_pessoa" runat="server" /><asp:HiddenField ID="hf_id_pessoa_filial" runat="server" />
		</form>
	</body>
</HTML>
