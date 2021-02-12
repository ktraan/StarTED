<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <br />
              <h3>Known Bugs:</h3>
            <ul>
                <li>There is a missing element with the two stored procedures provided.</li>
                <li><code>ClubActivities_FindByClubAndDate</code></li>
                <li><code>ClubActivities_FindByClub</code></li>
                <li>They are both missing an attribute CampusVenueID</li>
            </ul>

            <h3><b>Form A - ClubActivities - Single Item Create/Read/Update/Delete</b></h3>
            <p>This form is to Create/Read/Update/Delete a club activity.</p>
            <ul>
                <li>The user is to enter the starting date of the activity search and select a club from the dropdown list and selecting the 'Activities?' button.</li>
                <li>Once the button is pressed, a list of activities will show up according to the start date.</li>
            </ul>
            <br />
            <h4><b>Some unique constraints and characteristics are: </b></h4>
            <ul>
                <li>Only future ClubActivities can be Created, Updated, or Deleted.</li>
                <li>The <code>StartDate</code> will default to <b>Today</b> if no start date is given when the activity is created</li>
                <li>ClubActivities will have a CampusVenue assigned unless it is off campus. A CampusVenues <code>Description</code> list can be obtained from the database.</li>
                <li>Off campus activities must be flagged and have a location.</li>
                <li><b>Search Filter: </b> <br />
                    Use Club and StartDate filter for main Club Activities lookup (find all activies for the club since the start date)
                </li>
            </ul>
            <br />
            <h3><b>Form B - ClubActivies by Club - GridView Lookup with Code-Behind</b></h3>
            <p>This form is to use GridView to lookup the ClubActivies by club with using code-behind.</p>
            <ul>
                <li>Not to use ObjectDataSource controls.</li>
                <li>The data binding should happen in the code behind of the form.</li>
            </ul>
            <br />
            <h3><b>Form C - ClubActivies by Club - GridViewLookup with ObjectDataSource controls</b></h3>
            <p>This form will be similar to Form B, but with ObjectDataSource</p>
            <ul>
                <li>Avoid the use of code-behind wherever possible.</li>
            </ul>
            <br />

            <h3><b>Club Activities ERD</b></h3>
            <img src="ERD A-14.png" />


            <h3><b>Stored Procedures</b></h3>
            <ul>
                <li><code>ClubActivities_FindByClubAndDate</code> - Returns zero or more ClubActivities records matching the club id and is on/after the supplied date</li>
                <li><code>ClubActivities_FindByClub</code> - Returns zero or more ClubActivities records matching the club id</li>
            </ul>




        </div>
    </div>
<script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>
