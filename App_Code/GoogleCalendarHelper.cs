using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Calendar.v3;
using System.Web.Configuration;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using Google.Apis.Services;

namespace ProjLife_Zain_Test.App_Code
{
    public class GoogleCalendarHelper
    {
        //Just setting the appropiate credentials needed to access the google apis
        protected static string
            CLIENT_ID = WebConfigurationManager.AppSettings["Client Id"].ToString(),
            CLIENT_SECRET = WebConfigurationManager.AppSettings["Client Secret"].ToString(),
            API_KEY = WebConfigurationManager.AppSettings["API Key"].ToString(),
            APPLICATION_NAME = WebConfigurationManager.AppSettings["Application Name"].ToString(),
            GAPICAL_STORAGE = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Data Storage"].ToString());


        //this is a variation of the sameple given by google to access their apis but modified to access google calendar
        protected static GoogleAuthorizationCodeFlow
            CodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = CLIENT_ID,
                    ClientSecret = CLIENT_SECRET
                },
                Scopes = new[] { CalendarService.Scope.Calendar },
                DataStore = new DataBaseDataStore()
            });

        public CalendarService CalendarService;


        //authorize the oauth 2.0 request and get the token
        public object Authorize(HttpRequest Request, string accountName)
        {
            try
            {
                var uri = Request.Url.ToString();
                var code = Request["code"];
                var error = Request["error"];

                CalendarService = null;

                if (code != null)
                {
                    var token = CodeFlow.ExchangeCodeForTokenAsync(accountName, code, uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;
                    var oauthState = AuthWebUtility.ExtracRedirectFromState(CodeFlow.DataStore, accountName, Request["state"]).Result;
                    return oauthState;
                }
                else
                {
                    var result = new AuthorizationCodeWebApp(CodeFlow, uri, uri).AuthorizeAsync(accountName, CancellationToken.None).Result;
                    if (result.RedirectUri != null)
                    {
                        return result.RedirectUri;
                    }
                    else
                    {
                        CalendarService = new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = result.Credential,
                            ApplicationName = APPLICATION_NAME
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return ex;
            }

            return null;
        }

        public object GetCalendarList()
        {
                CalendarListResource.ListRequest req = CalendarService.CalendarList.List();
                return req.Execute();
        }
    }
}