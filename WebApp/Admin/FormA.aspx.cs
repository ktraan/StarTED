using StarTEDSystem.Data.KTran;
using StarTEDSystem.KTran.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin
{
    public partial class FormA : System.Web.UI.Page
    {
        #region Private Properties/Fields
        const string STYLE_WARNING = "alert-warning";
        const string STYLE_INFO = "alert-info";
        const string STYLE_SUCCESS = "alert -success";
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;

            if (!IsPostBack)
            {
                try
                {
                    PopulateClubDropDown();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_WARNING);
                }
            }
        }

        #region Buttons
        protected void LookupActivity_Click(object sender, EventArgs e)
        {
            if (DisplayClubs.SelectedIndex == 0)
            {
                ShowMessage("Please select a club before pressing Activity?", STYLE_INFO);

            }
            else
            {
                try
                {
                    SearchBy.Value = ClubActivitySearch.ByClubID.ToString();
                    var controller = new ClubActivityController();
                    string searchid = DisplayClubs.SelectedValue;
                    DateTime startdate = Convert.ToDateTime(DisplayStartDate.Text.ToString());
                    List<ClubActivity> data = controller.Find_ClubActivityClubDate(searchid, startdate);
                    PopulateGridView(data);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_INFO);
                }

            }

        }

        protected void SearchResultsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var activityid = Convert.ToInt32(SearchResultsGridView.SelectedValue);
            var controller = new ClubActivityController();
            var item = controller.GetClubActivity(activityid);

            CurrentActivityID.Text = item.ActivityID.ToString();
            DisplayClubID.SelectedValue = item.ClubID;
            Name.Text = item.Name;
            Description.Text = item.Description;
            StartDate.Text = item.StartDate.ToString();
            Location.Text = item.Location;
            OffCampus.Checked = item.OffCampus;
            CampusVenueID.Text = item.CampusVenueID.ToString();

            MessageLabel.Text = $"You have chosen the activity: {item.Name}";


        }

        protected void AddActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(StartDate.Text))
                {
                    StartDate.Text = DateTime.Today.ToString();
                }

                DateTime SelectedStartDate = Convert.ToDateTime(StartDate.Text);
                DateTime today = DateTime.Today;
                int datevalue = DateTime.Compare(SelectedStartDate, today);

                if (datevalue > 0 || datevalue == 0)
                {
                    ClubActivity item = BuildClubActivityFromUserInput();
                    var controller = new ClubActivityController();
                    var newActivityID = controller.AddClubActivity(item);
                    
                    ShowMessage("The club activity has been added!", STYLE_SUCCESS);
                }
                else
                {
                    ShowMessage("Only future Club Activities can be added", STYLE_INFO);
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, STYLE_INFO);
            }



        }

        protected void UpdateActivity_Click(object sender, EventArgs e)
        {
            int activityid;
            if (int.TryParse(CurrentActivityID.Text, out activityid))
            {
                try
                {
                    ClubActivity item = BuildClubActivityFromUserInput();
                    item.ActivityID = activityid;
                    var controller = new ClubActivityController();
                    controller.UpdateClubActivity(item);

                    ShowMessage("Club Activity has been updated!", STYLE_SUCCESS);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_INFO);
                }
            }
        }

        protected void DeleteActivity_Click(object sender, EventArgs e)
        {
            int activityid;
            if (int.TryParse(CurrentActivityID.Text, out activityid))
            {
                try
                {
                    var controller = new ClubActivityController();
                    controller.DeleteClubActivity(activityid);
                    ShowMessage("Club Activity has been deleted", STYLE_SUCCESS);
                    ResetForm_Click(sender, e);
                    SearchResultsGridView.DataBind();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, STYLE_INFO);
                }
            }
        }

        protected void ResetForm_Click(object sender, EventArgs e)
        {
            DisplayClubs.SelectedIndex = 0;
            CurrentActivityID.Text = string.Empty;
            DisplayClubID.SelectedIndex = 0;
            Name.Text = string.Empty;
            Description.Text = string.Empty;
            StartDate.Text = string.Empty;
            Location.Text = string.Empty;
            OffCampus.Checked = false;
            CampusVenueID.Text = string.Empty;
        }
        #endregion

        #region Private Methods
        private void PopulateClubDropDown()
        {
            ClubController controller = new ClubController();
            DisplayClubs.DataSource = controller.Club_List();
            DisplayClubs.DataTextField = nameof(Club.ClubName);
            DisplayClubs.DataValueField = nameof(Club.ClubID);
            DisplayClubs.DataBind();
            DisplayClubs.Items.Insert(0, new ListItem("[Select a club]"));

            DisplayClubID.DataSource = controller.Club_List();
            DisplayClubID.DataTextField = nameof(Club.ClubID);
            DisplayClubID.DataValueField = nameof(Club.ClubID);
            DisplayClubID.DataBind();
            DisplayClubID.Items.Insert(0, new ListItem("[Select a ClubID]"));

        }

        private ClubActivity BuildClubActivityFromUserInput()
        {
            ClubActivity item = new ClubActivity();
            int temp;

            if (int.TryParse(DisplayClubs.SelectedValue, out temp))
                item.ActivityID = temp;

            if (!string.IsNullOrWhiteSpace(DisplayClubID.SelectedValue))
                item.ClubID = DisplayClubID.Text.Trim();

            if (!string.IsNullOrWhiteSpace(Name.Text))
                item.Name = Name.Text.Trim();

            if (!string.IsNullOrWhiteSpace(Description.Text))
                item.Description = Description.Text.Trim();

            DateTime startdate;
            if (DateTime.TryParse(StartDate.Text, out startdate))
                item.StartDate = Convert.ToDateTime(StartDate.Text);

            if (!string.IsNullOrWhiteSpace(Location.Text))
                item.Location = Location.Text.Trim();

            item.OffCampus = OffCampus.Checked;

            if (int.TryParse(CampusVenueID.Text, out temp))
                item.CampusVenueID = temp;

            return item;
        }
        private void ShowMessage(string message, string style)
        {
            MessageLabel.Text = message;
            MessagePanel.CssClass = $"alert {style} alert-dismissible";
            MessagePanel.Visible = true;
        }

        private void PopulateGridView(List<ClubActivity> data)
        {
            SearchResultsGridView.DataSource = data;
            SearchResultsGridView.DataBind();
        }
        #endregion

        private enum ClubActivitySearch { ByClubID, ByStartDate }


        protected void SearchResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClubActivitySearch search;
            if (Enum.TryParse(SearchBy.Value, out search))
            {
                SearchResultsGridView.PageIndex = e.NewPageIndex;
                switch (search)
                {
                    case ClubActivitySearch.ByClubID:
                        LookupActivity_Click(sender, e);
                        break;
                    case ClubActivitySearch.ByStartDate:
                        LookupActivity_Click(sender, e);
                        break;
                }
            }

        }


    }
}