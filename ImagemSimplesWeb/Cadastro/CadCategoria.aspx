<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CadCategoria.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.CadCategoria" %>

<asp:Content ContentPlaceHolderID="CadCategoria" runat="server">

    <div class="divcadcategoria">
        <div>
            <table>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Id: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblidCategoria"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Dependencia: "></asp:Label>
                    </td>
                    <td>

                        <asp:DropDownList runat="server" ID="ddlMenus"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Nome: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtNome"
                            ErrorMessage="*Campo Obrigatorio"
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Descrição: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtDescricao"
                            ErrorMessage="*Campo Obrigatorio"
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Nível: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNivel"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtNivel"
                            ErrorMessage="*Campo Obrigatorio"
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Existe MDB: "></asp:Label>

                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkExisteMDB" />
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Caminho Imagens: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPathImagens"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView runat="server" ID="gridAtributos" AutoGenerateColumns="false" CssClass="GridCadastro">
                <Columns>
                    <asp:TemplateField HeaderText="id" SortExpression="FirstName" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Id" runat="server"
                                Text='<%# Bind("id_cat_atrib") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idoper" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:Label ID="Id_Oper" runat="server"
                                Text='<%# Bind("id_oper") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Atributo" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:Label ID="NomeAtributo" runat="server"
                                Text='<%# Bind("NomeAtributo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Titulo" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:Label ID="TituloAtributo" runat="server"
                                Text='<%# Bind("TituloAtributo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Excluir" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ToolTip="Excluir" ImageUrl="~/Imagens/icons8-cancel-16.png" ID="btnExcluirAtrib" OnClick="Unnamed_Click" CommandArgument='<%# Bind("NomeAtributo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeAtrib"></asp:TextBox></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTituloAtrib"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" CssClass="BtnPesquisar" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" CssClass="BtnPesquisar" /></td>
                    <td>
                        <asp:Button runat="server" ID="btnLimpar" Text="Limpar" CssClass="BtnPesquisar" /></td>
                    <td>
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="BtnPesquisar" OnClick="btnCancelar_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

