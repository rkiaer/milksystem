<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_fisicoquimica.aspx.vb" Inherits="frm_relatorio_fisicoquimica" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Análises Físico-Químicas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
<body >
		<form id="Form1"  runat="server">
		<div id="rel_fisico_quimico" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; vertical-align: middle; ">
            <table class="texto" width="280mm">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="textosmallbold" colspan="2" >
                        ANÁLISES FÍSICO-QUÍMICAS DO LEITE 'in natura'</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2" style="height: 14px;"><asp:Label ID="lbl_estabelecimento" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td align="center" class="textosmall" colspan="2" style="height: 14px;">
                       Data:
                        <asp:Label ID="lbl_data_ini" runat="server" CssClass="textosmall" Font-Italic="True"  ></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4"  ForeColor="Black" UpdateAfterCallBack="True"  Width="280mm" BackColor="White"  DataKeyNames="id_romaneio_compartimento,id_romaneio_placa" PageSize="3" CssClass="textosupermenor">
                                                    <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="nm_analista" HeaderText="Analista" >
                                                            <headerstyle width="20mm" />
                                                            <itemstyle cssclass="textosupermenor" width="20mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                                            <headerstyle width="10mm" />
                                                            <itemstyle cssclass="textosupermenor" width="10mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nm_linha_cooperativa" HeaderText="Rota/Coop.">
                                                            <headerstyle width="29mm" />
                                                            <itemstyle cssclass="textosupermenor" horizontalalign="Left" width="29mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="id_romaneio" HeaderText="Rom." >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" horizontalalign="Left" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nr_compartimento" HeaderText="Cp." >
                                                            <headerstyle width="5mm" />
                                                            <itemstyle cssclass="textosupermenor" width="5mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ds_dt_hora_entrada" HeaderText="Cheg." >
                                                            <headerstyle width="19mm" />
                                                            <itemstyle cssclass="textosupermenor" width="19mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="LIT" >
                                                            <headerstyle width="8mm" />
                                                            <itemstyle cssclass="textosupermenor" width="8mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="LIB" >
                                                            <headerstyle width="8mm" />
                                                            <itemstyle cssclass="textosupermenor" width="8mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="LIM" >
                                                            <headerstyle width="8mm" />
                                                            <itemstyle cssclass="textosupermenor" width="8mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CEA" >
                                                            <headerstyle width="8mm" />
                                                            <itemstyle cssclass="textosupermenor" width="8mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dt_inicio_analise" HeaderText="An&#225;lise" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Dens(g/l)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="MG(%)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="PROT(%)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="EST(%)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="ESD(%)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="A.L." >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="N.A." >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Temp(oC)" >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Aliz78" >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Criosc." >
                                                            <headerstyle width="9mm" />
                                                            <itemstyle cssclass="textosupermenor" width="9mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Snap" >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Charm" >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Redut &gt;=90mi">
                                                            <headerstyle width="9mm" />
                                                            <itemstyle width="9mm" cssclass="textosupermenor" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Perox." >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Fosfat." >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Cloreto" >
                                                            <headerstyle width="7mm" />
                                                            <itemstyle cssclass="textosupermenor" width="7mm" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle BackColor="White" />
                                                </anthem:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;<anthem:GridView ID="gridComentarios" runat="server" AutoGenerateColumns="False"  CellPadding="4"  ForeColor="Black" UpdateAfterCallBack="True"  Width="100%" BackColor="White" PageSize="3">
                            <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                            <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                    <itemstyle width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_compartimento" HeaderText="Cp." >
                                    <itemstyle width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla">
                                    <itemstyle width="15px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Coment&#225;rio" DataField="ds_comentario" />
                            </Columns>
                            <RowStyle BackColor="White" />
                        </anthem:GridView>
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;
</div>            
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages>
     </form>
	</body>
</HTML>