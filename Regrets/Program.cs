using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Diagnostics;


namespace Regrets
{
    public class Class1
    {
        public static ArrayList ListUsers(HttpClient client, string url)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string[] split = Convert.ToString(timeTaken.TotalSeconds).Split(".");
            int sec = Convert.ToInt32(split[0]);
            JToken jArr = JsonConvert.DeserializeObject<JToken>(response);
            ArrayList result = new ArrayList
            {
                jArr["page"],
                jArr["per_page"],
                jArr["total"],
                jArr["total_pages"],
                jArr["data"][4]["first_name"],
                sec
            };
            Console.WriteLine(sec);
            return result;
        }

        public static dynamic GetUser(HttpClient client, string url)
        {
            var response = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            JToken jArr = JsonConvert.DeserializeObject<JToken>(response);
            if (Convert.ToString(client.GetAsync(url).Result.StatusCode) == "OK")
            {
                var person = Tuple.Create(jArr["data"]["id"],
                jArr["data"]["email"],
                jArr["data"]["first_name"],
                jArr["data"]["last_name"],
                jArr["data"]["avatar"]
            );
            return person; }
            else { return "404"; }
            
        }

        
    }
}
