<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Categoria.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.Categoria" %>

<asp:Content ContentPlaceHolderID="Categoria" runat="server">
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
    </script>
    <button type="button" onclick="ShowDivPesquisa()" class="btnShowDiv">Click Me</button>
    <div class="PanelPesquisa" id="DivPanelPesquisa">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server">Descrição</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="BtnPesquisar" Text="Pesquisar" OnClick="BtnPesquisar_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div class="divcategoria">
        <asp:Button runat="server" ID="btnIncluir" Text="Incluir" OnClick="btnIncluir_Click" />
        <asp:GridView ID="GridCategorias" runat="server" AllowPaging="True" OnPageIndexChanging="GridCategorias_PageIndexChanging"
            AllowSorting="True" AutoGenerateColumns="false">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
            <Columns>
                <asp:TemplateField HeaderText="id_oper" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="id_oper" runat="server"
                            Text='<%# Bind("id_oper") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nivel" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Nivel" runat="server"
                            Text='<%# Bind("Nivel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descricao" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="serv_codigo" runat="server"
                            Text='<%# Bind("Descricao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Existe MDB" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="ExisteMDB" runat="server"
                            Text='<%# Bind("ExisteMDB") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Caminho Imagens" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="PATHIMAGENS" runat="server"
                            Text='<%# Bind("PATHIMAGENS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="40">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="BtnEdit" OnClick="BtnEdit_Click" CommandArgument='<%# Bind("id_Oper") %>' />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>





</asp:Content>


