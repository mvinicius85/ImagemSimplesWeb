<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.Documento" EnableEventValidation="false" %>


<asp:Content ContentPlaceHolderID="CPH2" runat="server">
    <div class="content">
        <script src="../javascript/documentos.js"></script>

        <aside>
            <div id="criamenu">
                <nav>
                    <ol class="tree">
                        <%foreach (var item in CriaMenu().Where(x => x.ind_ativo).ToList())
                            { %>
                        <li>
                            <% if (item.ExisteMDB.Trim().ToUpper() == "SIM")
                                { %>
                            <a href="<%=item.link%>">
                                <label class="file">
                                    <%=item.Nome %>
                                </label>
                            </a>

                            <% }
                                else
                                { %>
                            <label for="folder<%= item.id_Oper%>"><%= item.Nome %></label>
                            <input type="checkbox" id="folder<%= item.id_Oper%>" />
                            <% }%>
                            <%if (item.submenu.Count > 0)
                                {%>
                            <ol>

                                <% foreach (var subitem in item.submenu.Where(y => y.ind_ativo).ToList())
                                    {%>

                                <li>

                                    <% if (subitem.ExisteMDB.Trim().ToUpper() == "SIM")
                                        { %>
                                    <a href="<%=subitem.link%>">
                                        <label class="file">
                                            <%=subitem.Nome %>
                                        </label>
                                    </a>

                                    <% }
                                        else
                                        { %>
                                    <label for="subfolder<%= subitem.id_Oper%>"><%= subitem.Nome %></label>
                                    <input type="checkbox" id="subfolder<%= subitem.id_Oper%>" />
                                    <% }%>


                                    <%if (subitem.submenu.Count > 0)
                                        {%>
                                    <ol>
                                        <% foreach (var cat in subitem.submenu.Where(z => z.ind_ativo).ToList())
                                            {%>

                                        <li>
                                            <a href="<%=cat.link%>">
                                                <label class="file">
                                                    <%=cat.Nome %>
                                                </label>
                                            </a>

                                        </li>

                                        <%}%>
                                    </ol>
                                    <% } %>
                        
                                </li>

                                <%}%>
                            </ol>
                            <%} %>
                        </li>
                        <%} %>
                    </ol>
                </nav>

            </div>
        </aside>

        <main>
            <div class="mainclass">
                <button type="button" onclick="ShowDivPesquisa()" class="btnShowDiv">Filtros</button>
                <button type="button" onclick="ShowDivPreview()" class="btnShowDiv">Pre-Visualizar</button>

                <div class="PanelPesquisa" id="DivPanelPesquisa">
                    <table>
                        <asp:Literal runat="server" ID="TableSearch">
       
                        </asp:Literal>
                        <tr>
                            <td>
                                <button type="button" id="btnPesquisa" class="BtnPesquisar" onclick="PesquisarDocs()">Pesquisar</button>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="PanelPdf" id="DivPanelPreview">
                    <iframe id="pdfFrame" src=""></iframe>
                </div>
                <div class="divDocumentos">
                    <asp:GridView runat="server" ID="griddocumentos" OnRowCreated="griddocumento_RowCreated"
                        OnSelectedIndexChanged="OnSelectedIndexChanged" AllowPaging="True" CssClass="GridDocumentos"
                        AutoGenerateColumns="false" OnPageIndexChanging="griddocumentos_PageIndexChanging">
                    </asp:GridView>
                </div>


                <asp:Label runat="server" ID="txtMsgAcessoProibido" Text="" CssClass="MsgErro"></asp:Label>
            </div>
        </main>
    </div>
</asp:Content>

