using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Util.Store;
using System.Web.Configuration;

namespace ProjLife_Zain_Test.Add_Code
{
    //This file is pretty much a cleaner version of:
    //https://code.google.com/p/google-api-dotnet-client/source/browse/Src/GoogleApis.DotNet4/Apis/Util/Store/FileDataStore.cs
    public class DataBaseDataStore : IDataStore
    {
        FileDataStore dataStore;

        public DataBaseDataStore()
        {
            dataStore = new FileDataStore(HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Data Storage"].ToString()));
        }

        public System.Threading.Tasks.Task ClearAsync()
        {
            var result = dataStore.ClearAsync();
            return result;
        }

        public System.Threading.Tasks.Task DeleteAsync<T>(string key)
        {
            var result = dataStore.DeleteAsync<T>(key);
            return result;
        }

        public System.Threading.Tasks.Task<T> GetAsync<T>(string key)
        {
            var result = dataStore.GetAsync<T>(key);
            return result;
        }

        public System.Threading.Tasks.Task StoreAsync<T>(string key, T value)
        {
            var result = dataStore.StoreAsync<T>(key, value);
            return result;
        }
    }
}