<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_propriedade_tanque.aspx.vb" Inherits="lst_propriedade_tanque" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_treinamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	<script type="text/javascript" > 

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
           	     
        szUrl = 'lupa_propriedade.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:580px;edge:raised;dialogHeight:420px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
    </script>
		<form id="Form1" method="post" runat="server">
            &nbsp;<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)">
                        <strong>Compartilhar Tanque</strong></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
								<TD width="20%" style="height: 20px" align="right">Propriedade:</TD>
								<TD style="height: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True" ValidationGroup="vg_pesquisar"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:CustomValidator ID="cmv_propriedade" runat="server" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>&nbsp;&nbsp;
                                </TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField SortExpression="id_propriedade" HeaderText="Propriedade">
                                                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w43"></asp:TextBox> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_prop" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w38"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_propriedade" HeaderText="Propriedade" Visible="False" />
                                                <asp:TemplateField HeaderText="UP">
                                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("nr_unid_producao") %>' __designer:wfdid="w41"></asp:TextBox> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_up" runat="server" CssClass="texto" Text='<%# Bind("nr_unid_producao") %>' __designer:wfdid="w83"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Produtor" DataField="cd_pessoa" />
                                                <asp:BoundField HeaderText="Nome" DataField="nm_pessoa" />
                                                <asp:BoundField HeaderText="Prop. Parc." DataField="id_propriedade_parceira" />
                                                <asp:BoundField HeaderText="UP" DataField="nr_unid_prod_parc" />
                                                <asp:BoundField HeaderText="Produtor" DataField="cd_prod_parc" />
                                                <asp:BoundField HeaderText="Nome" DataField="nm_prod_parc" />
                                                <asp:BoundField HeaderText="Situa&#231;&#227;o" DataField="nm_situacao" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<asp:ImageButton id="btneditar" runat="server" CssClass="texto" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w84" CommandName="Edit"></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id_propriedade_tanque" Visible="False" >
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
            <asp:HiddenField ID="hf_id_propriedade" runat="server" />
		</form>
	</body>
</HTML>
