using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MamagermentToolApi.Utils
{
    /// <summary>
    /// Using to return document HTML of a Web when have a request
    /// </summary>
    public class Crawler
    {

        /// <summary>
        /// Get response with request method Get
        /// </summary>
        /// <param name="url">Request Url</param>
        /// <returns>Document HTML</returns>
        public static string getResponse(String url)
        {
            string result;
            //Initialize a request with web url
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url);
            result = response.Result.Content.ReadAsStringAsync().Result;
            return result;
        }


    }

}
