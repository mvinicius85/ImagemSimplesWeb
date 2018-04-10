<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.Documento" EnableEventValidation="false"%>


<asp:Content ContentPlaceHolderID="CPH2" runat="server">



    <div id="divmenu">

        <asp:Menu ID="menu" runat="server" OnMenuItemClick="Menu_MenuItemClick">
        </asp:Menu>
    </div>

    <div>
        <asp:GridView runat="server" ID="griddocumentos" OnRowCreated="griddocumento_RowCreated"
            OnSelectedIndexChanged="OnSelectedIndexChanged" AllowPaging="True"
            AutoGenerateColumns="false" OnPageIndexChanging="griddocumentos_PageIndexChanging">

            <Columns>
                <asp:TemplateField HeaderText="ID_TESTE" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="id" runat="server"
                            Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="cli_codigo" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="clie_codigo" runat="server"
                            Text='<%# Bind("clie_codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="serv_codigo" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="serv_codigo" runat="server"
                            Text='<%# Bind("serv_codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="lote_codigo" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lote_codigo" runat="server"
                            Text='<%# Bind("lote_codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Imagem" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="imagem" runat="server"
                            Text='<%# Bind("Imagem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. de Paginas" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="pagina" runat="server"
                            Text='<%# Bind("pagina") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. do Processo" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="nrprocesso" runat="server"
                            Text='<%# Bind("nrprocesso") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. do Projeto" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="nrprojeto" runat="server"
                            Text='<%# Bind("nrprojeto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nr. da Lei" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="NRLEI" runat="server"
                            Text='<%# Bind("NRLEI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Interessado" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="interessado" runat="server"
                            Text='<%# Bind("interessado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assunto" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="assunto" runat="server"
                            Text='<%# Bind("assunto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="path_original" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="path_original" runat="server"
                            Text='<%# Bind("path_original") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="path_imagem" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="path_imagem" runat="server"
                            Text='<%# Bind("path_imagem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="status" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="status" runat="server"
                            Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

