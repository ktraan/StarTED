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
    public partial class FormB : System.Web.UI.Page
    {
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
                    ShowFullExceptionMessage(ex);
                }
            }
        }



        #region Private Methods

        private void PopulateClubDropDown()
        {
            ClubController controller = new ClubController();
            DisplayClubs.DataSource = controller.Club_List();
            DisplayClubs.DataTextField = nameof(Club.ClubID);
            DisplayClubs.DataValueField = nameof(Club.ClubID);
            DisplayClubs.DataBind();
            DisplayClubs.Items.Insert(0, new ListItem("[Select a club]"));
        }

        public enum AlertStyle { success, info, warning, danger }


        private void ShowMessage(string message, AlertStyle alertStyle)
        {
            MessageLabel.Text = message;
            MessagePanel.CssClass = $"alert alert-{alertStyle} alert-dismissible";
            MessagePanel.Visible = true;
        }

        private void ShowFullExceptionMessage(Exception ex)
        {
            string message = $"ERROR: {ex.Message}";
            // get the inner exception....
            Exception inner = ex;
            // this next statement drills down on the details of the exception
            while (inner.InnerException != null)
                inner = inner.InnerException;
            if (inner != ex)
                message += $"<blockquote>{inner.Message}</blockquote>";
            ShowMessage(message, AlertStyle.danger);
        }
        #endregion


    }
}