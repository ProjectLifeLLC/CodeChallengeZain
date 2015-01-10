using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Oauth 2.0 Classes
using Microsoft.Owin;

//Google APIs v3
using Google;
using Google.Apis.Calendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

//my helper functions
using ProjLife_Zain_Test.App_Code;


namespace ProjLife_Zain_Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static CalendarService service;
        static string accountName;

        protected void Page_Init(object s, EventArgs e)
        {
            var clear = Request["clear"];
            if (clear != null)
            {
                //store session variable for future authorization requests
                Session["txtUsername"] = null;
                //store the service that is saved in the GoogleCalendarHelper object
                Session["CalendarHelper"] = null;
                Response.Redirect(Request.Url.LocalPath, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             accountName = (string)Session["txtUsername"];

             if (!string.IsNullOrEmpty(accountName))
             {
                 GoogleCalendarHelper calhelp = new GoogleCalendarHelper();
                 var result = calhelp.Authorize(Request, accountName);

                 if (result == null)
                 {
                     Session["CalendarHelper"] = calhelp;
                     Response.Redirect("CalendarChooser.aspx");
                 }
                 else if (result is string)
                 {
                     //this redirects it first to the authorization server to receive the token then back to 
                     //the website and with the new token it is now able to allow access to the calendars
                     Response.Redirect((string)result);
                 }
             }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["txtUsername"] = txtUsername.Text;
            Page_Load(sender, e);
            
        }    

    }
}