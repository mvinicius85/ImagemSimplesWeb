<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Usuarios.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.Usuarios" %>

<asp:Content ContentPlaceHolderID="Usuarios" runat="server">

    <div>
    </div>


    <div class="divcategoria">
                <asp:Button runat="server" ID="btnIncluir" Text="Incluir" OnClick="btnIncluir_Click" />
        <asp:GridView ID="GridUsuarios" runat="server" AllowPaging="True"
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
                <asp:TemplateField HeaderText="ID" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:Label ID="id_user" runat="server"
                            Text='<%# Bind("id_user") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Codigo" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:Label ID="clie_codigo" runat="server"
                            Text='<%# Bind("codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:Label ID="Nome" runat="server"
                            Text='<%# Bind("Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Depto" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:Label ID="Depto" runat="server"
                            Text='<%# Bind("Depto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Data" runat="server"
                            Text='<%# Bind("Data") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data Inicio" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="DataInicio" runat="server"
                            Text='<%# Bind("DataInicio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tel. 1" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:Label ID="Tel1" runat="server"
                            Text='<%# Bind("Tel1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tel. 2" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Tel2" runat="server"
                            Text='<%# Bind("Tel2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tel. 3" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Tel3" runat="server"
                            Text='<%# Bind("Tel3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Email" runat="server"
                            Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ativo" SortExpression="FirstName" >
                    <ItemTemplate>
                        <asp:CheckBox ID="ativo" runat="server" Enabled="false"
                             Checked='<%# Bind("ativo") %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="40">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="BtnEdit" OnClick="BtnEdit_Click" CommandArgument='<%# Bind("id_User") %>' />

                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
