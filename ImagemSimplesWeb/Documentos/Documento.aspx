<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.Documento" EnableEventValidation="false" %>


<asp:Content ContentPlaceHolderID="CPH2" runat="server">
    <div class="content">
        <script>
            function ShowDivPesquisa() {
                var x = document.getElementById("DivPanelPesquisa");
                if (x.style.display === "block") {
                    x.style.display = "none";
                } else {
                    x.style.display = "block";
                    //}
                }
            }

            function ShowDivPreview() {
                var x = document.getElementById("DivPanelPreview");
                if (x.style.display === "block") {
                    x.style.display = "none";
                } else {
                    x.style.display = "block";
                    //}
                }
            }

            function PesquisarDocs(parent, getChildrensChildren) {
                var txt = "";
                var link;
                var numeral = "";
                var text;
                var element = document.getElementById("DivPanelPesquisa");
                var c = getCount(element, true);
                for (var i = 1; i <= (c - 5) / 5; i++) {
                    console.log(i);
                    txt = document.getElementById("txt" + i);
                    numeral = i + "=" + txt.value;
                    console.log(numeral);
                    link = link + numeral + "&";
                }
                link = link.replace("undefined", "");
                link = link.substring(0, link.length - 1)
                console.log(document.URL + "&" + link);
                txt = document.URL.split("&")[0];
                window.location.href = txt + "&" + link;
            }

            function getCount(parent, getChildrensChildren) {
                var relevantChildren = 0;
                var children = parent.childNodes.length;
                for (var i = 0; i < children; i++) {
                    if (parent.childNodes[i].nodeType != 3) {
                        if (getChildrensChildren)
                            relevantChildren += getCount(parent.childNodes[i], true);
                        relevantChildren++;
                    }
                }
                return relevantChildren;
            }

            function openFile(row) {
                var cell = row.cells[0];
                console.log(row.cells[0]);
                var pdfname = cell.textContent;
                $.ajax({
                    type: "POST",
                    url: 'Documento.aspx/getPath',
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    success: function (data) {
                        //window.open(data.d + '\\' + pdfname, '_blank');
                        var pdf = document.getElementById('pdfFrame');
                        pdf.src = data.d + '\\' + pdfname;
                        console.log(data.d + '\\' + pdfname)
                    }
                });
            }

            function openPdfNewTab(row) {
                var cell = row.cells[0];
                var pdfname = cell.textContent;
                $.ajax({
                    type: "POST",
                    url: 'Documento.aspx/getPath',
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    success: function (data) {
                        window.open(data.d + '\\' + pdfname, '_blank');
                        //var pdf = document.getElementById('pdfFrame');
                        //pdf.src = data.d + '\\' + pdfname;
                    }
                });
            }

        </script>

        <aside>
            <div id="criamenu">
                <nav>
                    <ol class="tree">
                        <%foreach (var item in CriaMenu())
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

                                <% foreach (var subitem in item.submenu)
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
                                        <% foreach (var cat in subitem.submenu)
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
                        OnSelectedIndexChanged="OnSelectedIndexChanged" AllowPaging="True"
                        AutoGenerateColumns="false" OnPageIndexChanging="griddocumentos_PageIndexChanging">
                    </asp:GridView>
                </div>


                <asp:Label runat="server" ID="txtMsgAcessoProibido" Text="" CssClass="MsgErro"></asp:Label>
            </div>
        </main>
    </div>
</asp:Content>

