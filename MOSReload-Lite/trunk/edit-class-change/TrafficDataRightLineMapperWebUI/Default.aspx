<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrafficDataRightLineMapperWebUI._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>TrafficData Data Mapper for Rights Line</h2>
            </hgroup>
            <p>
                Use this application for CRUD operations on the MasterLookup / MasterlookUpValues tables
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>&nbsp;</h3>
    <table width="100%" style="border: none">
        <tr>
            <td style="vertical-align: top;">
                <table border="1" style="border: none">
                    <tr>
                        <td style="text-align: center">
                            <b>MasterLookUp</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView DataKeyNames="id" ID="gdMasterLookup" runat="server" SelectedRowStyle-Font-Bold="true"
                                    OnSelectedIndexChanged="gdMasterLookup_SelectedIndexChanged" OnRowUpdating="gdMasterLookup_RowUpdating" OnRowEditing="gdMasterLookup_RowEditing" OnRowCancelingEdit="gdMasterLookup_RowCancelingEdit" OnRowDataBound="gdMasterLookup_RowDataBound" OnRowCommand="gdMasterLookup_RowCommand" OnRowDeleting="gdMasterLookup_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
                                    ShowFooter="false">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" >
                                            <HeaderTemplate>
                                                Description
                                                <br />
                                                <asp:TextBox ID="tbValue" runat="server" Text=''></asp:TextBox>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbValue" runat="server" Text='<%# Bind("value") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbValue" runat="server" Text='<%# Bind("value") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" >
                                            <HeaderTemplate>
                                                RightsLine Template
                                                <br />
                                                <asp:TextBox ID="tbTemplate" runat="server" Text=''></asp:TextBox>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbTemplate" runat="server" Text='<%# Bind("Template") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbValue" runat="server" Text='<%# Bind("Template") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:TemplateField ShowHeader="True">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbInsertLookupValue" runat="server" ForeColor="Red" OnClick="lbInsertLookupValue_Click">insert</asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

                                    <SelectedRowStyle Font-Bold="True" BackColor="#E2DED6" ForeColor="#333333"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <table border="1">
                    <tr>
                        <td style="text-align: center">
                            <b>MasterLookUpValues</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView   DataKeyNames="id" 
                                                ShowHeaderWhenEmpty="True" 
                                                ID="gdMasterLookUpValues" 
                                                runat="server" 
                                                AutoGenerateColumns="False" 
                                                ShowFooter="false" OnSelectedIndexChanged="gdMasterLookUpValues_SelectedIndexChanged" OnRowUpdating="gdMasterLookUpValues_RowUpdating" OnRowEditing="gdMasterLookUpValues_RowEditing" OnRowCancelingEdit="gdMasterLookUpValues_RowCancelingEdit" OnRowDataBound="gdMasterLookUpValues_RowDataBound" OnRowCommand="gdMasterLookUpValues_RowCommand" OnRowDeleting="gdMasterLookUpValues_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ML_ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbML_ID" runat="server" Text='<%# Bind("ML_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Field">
                                            <HeaderTemplate>
                                                Field
                                                <br />
                                                <asp:TextBox ID="tbField" runat="server" Text=''></asp:TextBox>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbField" runat="server" Text='<%# Bind("field") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbField" runat="server" Text='<%# Bind("field") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value">
                                            <HeaderTemplate>
                                                BroadView Value
                                                <br />
                                                <asp:TextBox ID="tbDBValue" runat="server" Text=''></asp:TextBox>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbDBValue" runat="server" Text='<%# Bind("bv_value") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbDBValue" runat="server" Text='<%# Bind("bv_value") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value">
                                            <HeaderTemplate>
                                                RightsLine Value
                                                <br />
                                                <asp:TextBox ID="tbDerivedValue" runat="server" Text=''></asp:TextBox>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbDerivedValue" runat="server" Text='<%# Bind("rl_value") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbDerivedValue" runat="server" Text='<%# Bind("rl_value") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:TemplateField ShowHeader="False">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lbInsertLookupMasterValues" runat="server" ForeColor="Red" OnClick="lbInsertLookupMasterValues_Click">insert</asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
