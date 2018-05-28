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
    <div class="divcategoria">
        <asp:Button runat="server" ID="btnIncluir" Text="Incluir" OnClick="btnIncluir_Click" CssClass="btnIncluir" />
        <button type="button" onclick="ShowDivPesquisa()" class="btnShowDiv">Filtro</button>
        <div class="PanelPesquisa" id="DivPanelPesquisa">
            <table>
                <tr>
                    <td class="tdText">
                        <asp:Label runat="server">Nome:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdText">
                        <asp:Label runat="server" >Descrição:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="tdText">
                        <asp:Label runat="server" >Armazena Imagens:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlArmazenaImagens" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button runat="server" ID="BtnPesquisar" CssClass="BtnPesquisar" Text="Pesquisar" OnClick="BtnPesquisar_Click" />
                    </td>
                </tr>

            </table>
        </div>



        <asp:GridView ID="GridCategorias" runat="server" CssClass="GridCadastro" AllowPaging="True" OnPageIndexChanging="GridCategorias_PageIndexChanging"
            AutoGenerateColumns="false">

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
                <asp:TemplateField HeaderText="Nome" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Nome" runat="server"
                            Text='<%# Bind("Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descricao" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Descricao" runat="server"
                            Text='<%# Bind("Descricao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Armazena Imagens" SortExpression="FirstName">
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
                        <asp:ImageButton runat="server" ToolTip="Editar" ImageUrl="~/Imagens/icons8-no-edit-40.png" ID="BtnEdit" OnClick="BtnEdit_Click" CommandArgument='<%# Bind("id_Oper")  %>' />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>





</asp:Content>


