<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_batch_declaration_excel.aspx.vb" Inherits="frm_batch_declaration_excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
                                        <asp:GridView ID="gridResults" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_exportacao_batch_itens">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                                                                        <Columns>
                                                <asp:BoundField DataField="id_exportacao_batch_execucao" HeaderText="Exec." SortExpression="id_exportacao_batch_execucao" />
                                                <asp:BoundField DataField="dt_ini_execucao_itens" HeaderText="Processamento" SortExpression="dt_ini_execucao_itens"  >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada" />
                                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="Descarga" SortExpression="dt_ini_descarga" />
                                                <asp:BoundField DataField="nr_peso_balanca" HeaderText="Peso Liq" />
                                                <asp:BoundField DataField="nr_volume_estoque" HeaderText="Litros Reais" />
                                                <asp:BoundField DataField="ds_destino_leite_rejeitado" HeaderText="Ocor." />
                                                <asp:BoundField DataField="nr_po" HeaderText="Nr PO" SortExpression="nr_po" />
                                                <asp:BoundField DataField="cd_estabelecimento_sap" HeaderText="Estabel.SAP" />
                                                <asp:BoundField DataField="cd_item_sap" HeaderText="Item SAP" />
                                                <asp:BoundField DataField="cd_transportador_sap" HeaderText="Transp.SAP" />
                                                <asp:BoundField DataField="ds_tipo_fornecedor" HeaderText="Tipo" />
                                                <asp:BoundField DataField="nm_arquivo" HeaderText="Arquivo" />
                                               
                                                <asp:BoundField DataField="st_exportacao_batch_itens" HeaderText="Situa&#231;&#227;o" />
                                            </Columns>
                                        </asp:GridView>
                                        
                                            
                                         <asp:GridView ID="gridRomaneios" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_romaneio" Visible="False">
                                           
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                               
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" />
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso L&#237;q." />
                                                <asp:BoundField HeaderText="Dens." />
                                                <asp:BoundField HeaderText="Litros Reais" />
                                                <asp:BoundField DataField="nr_peso_liquido_caderneta_nota" HeaderText="Litros Cadern/NF" />
                                                <asp:BoundField HeaderText="Varia&#231;&#227;o" />
                                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="Descarga" />
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Sit. Romaneio" >
                                                    <headerstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_registro_exportacao_batch" HeaderText="Registro Exporta&#231;&#227;o " />
                                                <asp:BoundField DataField="dt_registro_exportacao_batch" HeaderText="Dt Registro" />
                                                <asp:BoundField DataField="ds_login_registro" HeaderText="Usu&#225;rio Registro" />
                                                <asp:BoundField DataField="st_exportacao_batch" HeaderText="Exportado" />
                                                <asp:BoundField DataField="dt_exportacao_batch" HeaderText="Dt Exporta&#231;&#227;o" />
                                                <asp:BoundField DataField="ds_login_exportacao" HeaderText="Usu&#225;rio Exporta&#231;&#227;o" />
                                                
                                            </Columns>
                                        </asp:GridView>
                                        
    </div>
    </form>
</body>
</html>
