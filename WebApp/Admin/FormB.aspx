<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormB.aspx.cs" Inherits="WebApp.Admin.FormB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Form B GridView Lookup</h1>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:HiddenField ID="SearchBy" runat="server" />
            <asp:Label ID="Label1" runat="server" AssociatedControlID="DisplayClubs">Clubs</asp:Label>
            <asp:DropDownList ID="DisplayClubs" runat="server" AutoPostBack="true" ></asp:DropDownList>
            <br />
        </div>
        <div class="col-md-6">
            <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <asp:Label ID="MessageLabel" runat="server" />
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="SearchResultsGridView" runat="server" DataSourceID="ClubActivityDataSource" ItemType="StarTEDSystem.Data.KTran.ClubActivity" AllowPaging="True" PageSize="20" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ActivityID" HeaderText="ActivityID" SortExpression="ActivityID">
                        <HeaderStyle HorizontalAlign="Center" Width="75px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="ClubID" SortExpression="ClubID">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" Text='<%# Item.ClubID %>' Enabled="true" DataSourceID="ClubActivityDataSource" DataTextField="ClubID" DataValueField="ClubID"></asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location">
                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="OffCampus" HeaderText="OffCampus" SortExpression="OffCampus">
                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="CampusVenueID" SortExpression="CampusVenueID">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <asp:DropDownList runat="server" Text='<%# Item.CampusVenueID %>' DataSourceID="ClubActivityDataSource" DataTextField="CampusVenueID" DataValueField="CampusVenueID"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource runat="server" ID="ClubActivityDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="Find_ClubActivityClub" TypeName="StarTEDSystem.KTran.BLL.ClubActivityController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DisplayClubs" PropertyName="SelectedValue" Name="clubid" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
