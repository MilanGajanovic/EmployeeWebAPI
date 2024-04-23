using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient = new HttpClient();

            // Set base address
            WebApiClient.BaseAddress = new Uri("https://localhost:44831/api");

            // Clear default request headers
            WebApiClient.DefaultRequestHeaders.Clear();

            // Add accept header for JSON
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
        }


    }
}