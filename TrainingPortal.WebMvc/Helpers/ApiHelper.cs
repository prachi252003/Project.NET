using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web;

 
namespace TrainingPortal.WebMvc.Helpers
{
    public static class ApiHelper
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress =
            new Uri("https://localhost:44357/");

            return client;
        }
    }
}