using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace front_end_mvc_dot_net_framework
{

    //Web api connection
    public static class ApiConnection
    {
        public static HttpClient webApiClient = new HttpClient();
        
        //Consuming api services
        //Constructor
        static ApiConnection()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44351/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}