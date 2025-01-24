<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuVertical.aspx.vb" Inherits="MenuVertical" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
    <link href="css/estilo.css" type="text/css" rel="stylesheet"/>
</head>
<body bottomMargin="0" bgColor="#efefef" leftMargin="0" topMargin="0" rightMargin="0">
    <form runat="server" name="Form1" method="post" action="MenuVertical.aspx?id_modulo=4" id="Form2">
        <table id="tableCentral" height="100%" cellSpacing="0" cellPadding="0" width="181,81%" border="1">
    		<tr>
		    	<td id="tdTreeView" valign="top">
				    <table id="ItnMenu" style="DISPLAY: block" cellspacing="0" cellpadding="0" width="100%"	border="1">
				        <tr>
							<td valign="bottom" align="right" bgcolor="#e1e1e1" style="HEIGHT: 24px">
							    <img id="img_fechar" onclick="javascript:openClose();" src="img/ico_fechar.gif" alt="" border="0" style="CURSOR:hand" />&nbsp;&nbsp;
							</td>
					    </tr>
						<tr>
						    <td class="texto" align="left" bgcolor="#efefef">
                                &nbsp;<asp:TreeView ID="TreeMenu" runat="server"  style="background-color:#EFEFEF;width:181.81%;">
                                    <Nodes>
		                                <asp:TreeNode Expanded="False" SelectAction="None" Text="Cadastros" Value="Cadastros"  >
                                            <asp:TreeNode Text="Estabelecimento" Value="Estabelecimento" NavigateUrl="~/lst_estabelecimento.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Silo" Value="Silo" NavigateUrl="~/lst_silo.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="T&#233;cnico" Value="T&#233;cnico" NavigateUrl="~/lst_tecnico.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Fornecedor" Value="Fornecedor" NavigateUrl="~/lst_pessoa.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Propriedade" Value="Propriedade" NavigateUrl="~/lst_propriedade.aspx" Target="mainFrame">
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Treinamento" Value="Treinamento" NavigateUrl="~/lst_treinamento.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Rota" Value="Rota" NavigateUrl="~/lst_linha.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Ve&#237;culo" Value="Ve&#237;culo" NavigateUrl="~/lst_veiculo.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Compartimento" Value="Compartimento" NavigateUrl="~/lst_compartimento.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_natureza_operacao.aspx" Target="mainFrame" Text="Natureza de Opera&#231;&#227;o"
                                                Value="Natureza de Opera&#231;&#227;o"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_motorista.aspx" Target="mainFrame" Text="Motorista"
                                                Value="Motorista"></asp:TreeNode>
                                            <asp:TreeNode Text="Tipos de An&#225;lise" Value="Tipos de An&#225;lise" NavigateUrl="~/lst_analise.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_comodato.aspx" Target="mainFrame" Text="Equipamento"
                                                Value="Equipamento"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_notificacao.aspx" Target="mainFrame" Text="Notifica&#231;&#245;es"
                                                Value="Notifica&#231;&#245;es"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="Coletor" Value="Coletor">
                                            <asp:TreeNode NavigateUrl="~/lst_coletor_contingencia.aspx" Target="mainFrame" Text="Criar Cadernetas"
                                                Value="Criar Cadernetas"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_caderneta.aspx" Target="mainFrame" Text="Visualizar Cadernetas"
                                                Value="Visualizar Cadernetas"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Romaneio" Value="Romaneio" Expanded="False" SelectAction="Expand">
                                            <asp:TreeNode Text="Abrir" Value="Abrir" NavigateUrl="~/lst_romaneio_caderneta.aspx" Target="mainFrame" ToolTip="Abrir Romaneio para Produtores"></asp:TreeNode>
                                            <asp:TreeNode Target="mainFrame" Text="Abrir Cooperativa" ToolTip="Abrir Romaneio para Cooperativa"
                                                Value="Abrir Cooperativa" NavigateUrl="~/frm_romaneio_cooperativa_abertura.aspx"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_romaneio_preromaneio_caderneta.aspx" Target="mainFrame"
                                                    Text="Abrir Pr&#233;-Romaneio" ToolTip="Abrir Pr&#233;-Romaneio para Transbordo"
                                                    Value="Abrir Pr&#233;-Romaneio"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/frm_romaneio_transbordo_abertura.aspx" Target="mainFrame"
                                                    Text="Abrir Transbordo" ToolTip="Abrir Romaneio para Transbordo" Value="Abrir Transbordo">
                                                </asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_romaneio_complementar_dados.aspx" Target="mainFrame"
                                                Text="Complementar Dados" Value="Complementar Dados" ToolTip="Complementar Dados para Romaneio"></asp:TreeNode>
                                            <asp:TreeNode Text="Registrar An&#225;lises" Value="Registrar An&#225;lises" NavigateUrl="~/lst_romaneios_analise_selecao.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_romaneio_reajuste_valor.aspx" Target="mainFrame"
                                                Text="Ajuste de Volume" Value="Reajuste de Valores"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_romaneio_pesagem_final.aspx" Target="mainFrame"
                                                Text="Pesagem Final" Value="Pesagem Final"></asp:TreeNode>
                                            <asp:TreeNode Text="Fechar Romaneio" Value="Fechar Romaneio" NavigateUrl="~/lst_romaneio_fechar.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_nota_fiscal.aspx" Target="mainFrame" Text="Nota Fiscal Entrada"
                                                Value="Nota Fiscal"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_romaneio_consulta.aspx" Target="mainFrame" Text="Consultar Romaneio"
                                                Value="Consultar Romaneio"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="An&#225;lises ESALQ" Value="An&#225;lises ESALQ">
                                            <asp:TreeNode Text="Importar" Value="Importar" NavigateUrl="~/lst_analise_esalq_importar.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Dados An&#225;lise" Value="Dados An&#225;lise" NavigateUrl="~/lst_analise_esalq.aspx" Target="mainFrame"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="C&#225;lculo" Value="C&#225;lculo">
                                            <asp:TreeNode Expanded="True" SelectAction="Expand" Text="Cadastro" Value="Cadastro">
                                                <asp:TreeNode NavigateUrl="~/lst_conta.aspx" Target="mainFrame" Text="Conta" Value="Conta">
                                                </asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_grupo_faixa.aspx" Target="mainFrame" Text="Faixas Adicional Volume"
                                                    Value="Faixas Adicional Volume"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_faixa_incentivo_fiscal.aspx" Target="mainFrame"
                                                    Text="Incentivo Fiscal" Value="Incentivo Fiscal"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_lancamento.aspx" Target="mainFrame" Text="Lan&#231;amentos"
                                                    Value="Lan&#231;amentos"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/frm_parametro.aspx" Target="mainFrame" Text="Par&#226;metros"
                                                    Value="Par&#226;metros"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_conta_parcelada.aspx" Target="mainFrame" Text="Parcelamentos"
                                                    Value="Parcelamentos"></asp:TreeNode>
                                                <asp:TreeNode Text="Pre&#231;o Objetivo" Value="Pre&#231;o Objetivo" NavigateUrl="~/lst_preco_objetivo.aspx" Target="mainFrame"></asp:TreeNode>
                                                <asp:TreeNode Text="Pre&#231;o Negociado" Value="Pre&#231;o Negociado" NavigateUrl="~/lst_preco_negociado.aspx" Target="mainFrame"></asp:TreeNode>
                                                <asp:TreeNode NavigateUrl="~/lst_preco_negociado_cooperativa.aspx" Text="Pre&#231;o Cooperativas"
                                                    Value="Pre&#231;o Cooperativas" Target="mainFrame"></asp:TreeNode>
                                                <asp:TreeNode Text="Tabelas Qualidade" Value="Tabelas Qualidade" NavigateUrl="~/lst_faixa_qualidade.aspx" Target="mainFrame"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_preco_negociado_aprovar_1N.aspx" Target="mainFrame"
                                                Text="Aprovar Pre&#231;o Neg. 1Niv." Value="Aprovar Pre&#231;o Neg. 1N&#237;v.">
                                            </asp:TreeNode>
                                            <asp:TreeNode Text="Aprovar Pre&#231;o Neg. 2Niv." Value="Aprovar Pre&#231;o  Neg. 2Niv." NavigateUrl="~/lst_preco_negociado_aprovar_2N.aspx" Target="mainFrame">
                                            </asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_adiantamento_solicitar.aspx" Target="mainFrame"
                                                Text="Solicitar Adiantamento" Value="Solicitar Adiantamento"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_adiantamento_aprovar_1N.aspx" Target="mainFrame" Text="Aprovar Adto 1N&#237;vel"
                                                Value="Aprovar Adiantamento"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_adiantamento_aprovar_2N.aspx" Target="mainFrame"
                                                Text="Aprovar Adto 2Nivel" Value="Aprovar Adto 2N&#237;vel"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_calculo_adiantamento.aspx" Target="mainFrame" Text="Calcular Adiantamento"
                                                Value="Calcular Adiantamento"></asp:TreeNode>
                                            <asp:TreeNode Text="Calcular" Value="Calcular" NavigateUrl="~/lst_calculo_produtor.aspx" Target="mainFrame"></asp:TreeNode>
                                            <asp:TreeNode Text="Hist&#243;rico de Pagamentos" Value="Hist&#243;rico de Pagamentos" NavigateUrl="~/lst_calculo_historico.aspx" Target="mainFrame">
                                            </asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Relat&#243;rios" Value="Relat&#243;rios" Expanded="False" SelectAction="Expand">
                                            <asp:TreeNode NavigateUrl="~/lst_relatorio_fisicoquimica.aspx" Target="mainFrame"
                                                Text="An&#225;lise F&#237;sico-Quimica" Value="An&#225;lise F&#237;sico-Quimica">
                                            </asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_relatorio_controleleite.aspx" Target="mainFrame"
                                                Text="Controle de Leite" Value="Controle de Leite"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_relatorio_motorista.aspx" Target="mainFrame" Text="Motorista/Placa/Rota"
                                                Value="Motorista/Placa/Rota"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_relatorio_resumo_calculo.aspx" Target="mainFrame"
                                                Text="Resumo C&#225;lculo" Value="Resumo C&#225;lculo"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Integra&#231;&#245;es" Value="Integra&#231;&#245;es" Expanded="False">
                                            <asp:TreeNode NavigateUrl="~/lst_exportar_adto.aspx" Target="mainFrame" Text="Exportar Adiantamento"
                                                Value="Exportar Adiantamento"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_exportar_estoque.aspx" Target="mainFrame" Text="Exportar Estoque"
                                                Value="Exportar Estoque"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_exportar_estoque_mensal.aspx" Target="mainFrame"
                                                Text="Exportar Estoque Mensal" Value="Exportar Estoque Mensal"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_exportar_mapaleite.aspx" Target="mainFrame" Text="Exportar Mapa Leite"
                                                Value="Exportar Mapa Leite"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_exportar_nota_fiscal.aspx" Target="mainFrame" Text="Exportar Nota Fiscal "
                                                Value="Exportar Nota Fiscal "></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_linha_exportar.aspx" Target="mainFrame" Text="Exportar Rotas"
                                                Value="Exportar Rotas"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_coopera_importar.aspx" Target="mainFrame" Text="Importar dados Coopera"
                                                Value="Importar dados Coopera"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_ems_importar.aspx" Target="mainFrame" Text="Importar dados EMS"
                                                Value="Importar dados EMS"></asp:TreeNode>
                                            <asp:TreeNode NavigateUrl="~/lst_linha_importar.aspx" Target="mainFrame" Text="Importar Rotas"
                                                Value="Importar Rotas"></asp:TreeNode>
                                        </asp:TreeNode>
                                    </Nodes>
                                </asp:TreeView>
                            </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </form>
	</body>
</html>
