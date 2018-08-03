<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CadUsuario.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.CadUsuario" %>

<asp:Content ContentPlaceHolderID="CadUsuario" runat="server">
    <div class="MsgErro">
        <asp:Label runat="server" ID="lblMsgErro" Visible="false" />
    </div>
    <div class="formUsuario">
        <div class="TableUsuarios">
            <table id="tbUser">
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Id: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblidUsuario"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Codigo: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtCodigo"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Senha: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtSenha"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server"
                            ID="RegexSenha" ErrorMessage="Apenas letras e números e ao minimo 4 caracteres."
                            ValidationExpression="^(?!.* ).{4,15}[a-zA-Z0-9]+$"
                            ControlToValidate="txtSenha"
                            ForeColor="Red">

                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtSenha"
                            ErrorMessage="*Campo Obrigatório."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Nome: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server"
                            ID="RegexNome" ErrorMessage="Apenas letras e números e ao minimo 4 caracteres."
                            ValidationExpression="^(?!.* ).{4,15}[a-zA-Z0-9]+$"
                            ControlToValidate="txtNome"
                            ForeColor="Red">

                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtNome"
                            ErrorMessage="*Campo Obrigatório."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Departamento: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtDepartamento"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Cadastro: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtCadastro"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="DataInicio: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDtInicio"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Telefone: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtTelefone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Residencial: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtTelRes"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Celular: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtTelCel"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Email: "></asp:Label>
                    </td>
                    <td>

                        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="*Campo Obrigatório."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="cadCategoriaLabel">
                        <asp:Label runat="server" Text="Ativo: "></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkAtivo" />
                    </td>
                </tr>
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
        <div class="Modulos">
            <h5>Módulos</h5>
            <ol>
                <li>
                    <asp:CheckBox runat="server" ID="chkCategorias" Text="Categorias" /></li>
                <li>
                    <asp:CheckBox runat="server" ID="chkUsuarios" Text="Usuarios" /></li>
                <li>
                    <asp:CheckBox runat="server" ID="chkIndexar" Text="Indexar" /></li>
            </ol>

            <div>
                <asp:GridView ID="GridAcessos" runat="server" AllowPaging="False"
                    AutoGenerateColumns="false" CssClass="GridCadastro">

                    <Columns>
                        <asp:TemplateField HeaderText="ID" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="Id_Oper" runat="server"
                                    Text='<%# Bind("Id_Oper") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descricao" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="Descricao" runat="server"
                                    Text='<%# Bind("Descricao") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nivel" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="Nivel" runat="server"
                                    Text='<%# Bind("Nivel") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--                <asp:TemplateField HeaderText="Acesso" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:CheckBox ID="Acesso" runat="server"
                            Text='<%# Bind("Acesso") %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/Imagens/icons8-cancel-16.png" ID="BtnExcluir" OnClick="BtnExcluir_Click" CommandArgument='<%# Bind("id_oper") %>' placeholder="Retirar da Lista" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:DropDownList runat="server" ID="ddlMenus"></asp:DropDownList>
                <asp:Button ID="BtnAdd" runat="server" Text="Adicionar" OnClick="BtnAdd_Click" CssClass="BtnPesquisar" />
            </div>
        </div>

    </div>

</asp:Content>
