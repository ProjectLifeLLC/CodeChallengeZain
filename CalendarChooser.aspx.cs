using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

//Google Apis
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System.Web.UI.HtmlControls;

//My Helper
using ProjLife_Zain_Test.Add_Code;

namespace ProjLife_Zain_Test
{
    public partial class CalendarChooser : System.Web.UI.Page
    {
        static string AccountName;
        GoogleCalendarHelper calhelp;

        protected void Page_Load(object sender, EventArgs e)
        {
            AccountName = (string)Session["txtUsername"];
            calhelp = (GoogleCalendarHelper)Session["CalendarHelper"];
            lblInstruct.Text = AccountName + " please choose a calendar:";

            if (calhelp == null || string.IsNullOrEmpty(AccountName))
            {
                Response.Redirect("Default.aspx", true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            DataBind();
        }

        protected void ddCalendarsList_OnDataBound(object sender, EventArgs events)
        {
            var result = calhelp.GetCalendarList();

                ddCalendarsList.Items.Clear();

                ddCalendarsList.Items.Add(new ListItem("Calendar List"));

                var calList = result as CalendarList;

                calList.Items.ToList().ForEach(cal =>
                {
                    ddCalendarsList.Items.Add(new ListItem(cal.Summary, cal.Id));
                });

           }

        protected void ddCalendarsList_OnSelectedIndexChanged(object sender, EventArgs events)
        {
            var calList = calhelp.CalendarService.Events.List(ddCalendarsList.SelectedValue);
            rptCalendarView.DataSource = calList.Execute().Items;
            rptCalendarView.DataBind();
            rptCalendarView.Visible = true;
        }

        protected void rptCalendarView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
                Label Name = (Label)e.Item.FindControl("lblName");
                Label StartTime = (Label)e.Item.FindControl("lblStartTime");
                Label EndTime = (Label)e.Item.FindControl("lblEndTime");
                Event CurrentEvent = (Event)e.Item.DataItem;
                if (e.Item.ItemIndex > -1)
                {
                Name.Text = CurrentEvent.Summary.ToString();
                StartTime.Text = ((EventDateTime)CurrentEvent.Start).DateTime.ToString();
                EndTime.Text = ((EventDateTime)CurrentEvent.End).DateTime.ToString();
            }
        }
    }
}