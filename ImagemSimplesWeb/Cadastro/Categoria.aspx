<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Categoria.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.Categoria" %>

<asp:Content ContentPlaceHolderID="Categoria" runat="server">


    <div class="divcategoria">
        <asp:GridView ID="GridCategorias" runat="server" AllowPaging="True"
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
                <asp:TemplateField HeaderText="ID_TESTE" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="id" runat="server"
                            Text='<%# Bind("id_oper") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="cli_codigo" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="clie_codigo" runat="server"
                            Text='<%# Bind("Dependencia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="serv_codigo" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="serv_codigo" runat="server"
                            Text='<%# Bind("Descricao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Imagem" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="imagem" runat="server"
                            Text='<%# Bind("Codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. de Paginas" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="pagina" runat="server"
                            Text='<%# Bind("Cod_ext") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. do Processo" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="nrprocesso" runat="server"
                            Text='<%# Bind("DataInclusao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. do Projeto" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="nrprojeto" runat="server"
                            Text='<%# Bind("OperIncluiu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. da Lei" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="NRLEI" runat="server"
                            Text='<%# Bind("ExisteMDB") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="path_original" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="path_original" runat="server"
                            Text='<%# Bind("PATHIMAGENS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="40">
                    <ItemTemplate>
                       <asp:ImageButton runat="server" id="BtnEdit" OnClick="BtnEdit_Click" CommandArgument='<%# Bind("id_Oper") %>' />

                    </ItemTemplate>
                </asp:TemplateField>
             

            </Columns>
        </asp:GridView>
    </div>





</asp:Content>


