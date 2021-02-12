<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="WebApp.Admin.FormA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1 class="page-header">Form A - Club Activites</h1>
    </div>

    <div class="row">
        <asp:HiddenField ID="SearchBy" runat="server" />
        <div class="col-md-6">

            <asp:Label ID="Label1" runat="server" AssociatedControlID="DisplayClubs">Clubs</asp:Label>
            <asp:DropDownList ID="DisplayClubs" runat="server" AutoPostBack="true"></asp:DropDownList>
            <asp:LinkButton ID="LookupActivity" runat="server" CssClass="btn btn-default" OnClick="LookupActivity_Click">Activity?</asp:LinkButton>
            <br />
            <asp:Label ID="Label2" runat="server" AssociatedControlID="DisplayStartDate">Start Date</asp:Label>
            <asp:TextBox ID="DisplayStartDate" runat="server" TextMode="Date" />

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
            <asp:GridView ID="SearchResultsGridView" runat="server" ItemType="StarTEDSystem.Data.KTran.ClubActivity" AutoGenerateSelectButton="true" DataKeyNames="ActivityID"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="20" OnPageIndexChanging="SearchResultsGridView_PageIndexChanging"
                SelectedIndex="1" OnSelectedIndexChanged="SearchResultsGridView_SelectedIndexChanged"
                CssClass="table table-hover table-condensed">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Activity Name" />
                    <asp:BoundField DataField="StartDate" HeaderText="Date" />
                </Columns>
                <EmptyDataTemplate>No Club activities for the selected search</EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" Position="Bottom" PageButtonCount="10" />
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <fieldset>
                <legend>Club Activity Details</legend>


                <asp:Label ID="Label3" runat="server" AssociatedControlID="CurrentActivityID" Text="ActivityID" />
                <asp:TextBox ID="CurrentActivityID" runat="server" Enabled="false" />

                <asp:Label ID="Label4" runat="server" AssociatedControlID="DisplayClubID" Text="Club ID" />
                <asp:DropDownList ID="DisplayClubID" runat="server" />

                <asp:Label ID="Label5" runat="server" AssociatedControlID="Name" Text="Name" />
                <asp:TextBox ID="Name" runat="server" />

                <asp:Label ID="Label6" runat="server" AssociatedControlID="Description" Text="Description" />
                <asp:TextBox ID="Description" runat="server" />

                <asp:Label ID="Label7" runat="server" AssociatedControlID="StartDate" Text="Start Date" />
                <asp:TextBox ID="StartDate" runat="server" TextMode="DateTime" />

                <asp:Label ID="Label8" runat="server" AssociatedControlID="Location" Text="Location" />
                <asp:TextBox ID="Location" runat="server" />

                <asp:Label ID="Label9" runat="server" AssociatedControlID="OffCampus" Text="Off Campus" />
                <asp:CheckBox ID="OffCampus" runat="server" />
                <br />

                <asp:Label ID="Label10" runat="server" AssociatedControlID="CampusVenueID" Text="Campus Venue ID" />
                <asp:TextBox ID="CampusVenueID" runat="server" />

                <asp:LinkButton ID="AddActivity" runat="server" OnClick="AddActivity_Click" CssClass="btn btn-default" CausesValidation="false">Add Activity</asp:LinkButton>
                <asp:LinkButton ID="UpdateActivity" runat="server" OnClick="UpdateActivity_Click" CssClass="btn btn-default" CausesValidation="false">Update Activity</asp:LinkButton>
                <asp:LinkButton ID="DeleteActivity" runat="server" OnClick="DeleteActivity_Click" CssClass="btn btn-default"
                    OnClientClick="return confirm('Are you sure you want to delete this activity?')" CausesValidation="false">Delete Activity</asp:LinkButton>
                <asp:LinkButton ID="ResetForm" runat="server" OnClick="ResetForm_Click" CssClass="btn btn-default" CausesValidation="false">Reset Form</asp:LinkButton>

            </fieldset>
        </div>
        <div class="col-md-12">
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
