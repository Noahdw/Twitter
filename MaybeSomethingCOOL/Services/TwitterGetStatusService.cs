using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MaybeSomethingCOOL.Services
   
{
    class TwitterGetStatusService : TwitterAuthGetService
    {
        public string jsonData;

        public void tryGetStatusRequest(string url, string username)
        {


            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("screen_name={0}", Uri.EscapeDataString(username));

            string postBody = sb.ToString();
            string method = "&" + postBody;
            string fullUrl = url + "?" + postBody;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);

            request.Headers.Add("Authorization", CreateAuthorizationHeaderParameter(CreateSignature(url, username, method)));
            request.Method = "GET";
            WebResponse timeLineResponse = request.GetResponse();
            var timeLineJson = string.Empty;
            //Reads the response and deserializes into a list
            try
            {
                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        jsonData = reader.ReadToEnd();
                    }
                    
                    masterList = JsonConvert.DeserializeObject<ObservableCollection<RootObject>>(jsonData);

                }
            }
            catch(Exception e)
                {
                    Console.WriteLine(e);
                }
        }
    }              
}