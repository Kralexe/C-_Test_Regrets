using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Regrets;
using System.Collections;
using NUnit.Framework;

namespace Regrets.Tests
{
    class Program
    {
        [TestFixture]
        public class RegretsTests
        {
            
            [TestCase]
            public void When_ListUsers_Expects_IsAllFields_Present()
            {
                var handler = new HttpClientHandler();
                var client = new HttpClient(handler);
                ArrayList vector = Class1.ListUsers(client, "https://reqres.in/api/users?page=2");
                
                Assert.That(Convert.ToInt32(vector[0]) == 2 && Convert.ToInt32(vector[1]) == 6 && Convert.ToInt32(vector[2]) == 12 && Convert.ToInt32(vector[3]) == 2 && Convert.ToString(vector[4])=="George");
            }

            [TestCase]
            public void When_GetUser_Expects_IsAllFields_Present()
            {
                var handler = new HttpClientHandler();
                var client = new HttpClient(handler);
                var vector = Class1.GetUser(client, "https://reqres.in/api/users/2");

                Assert.That(Convert.ToInt32(vector.Item1) == 2 && Convert.ToString(vector.Item2) == "janet.weaver@reqres.in" && Convert.ToString(vector.Item3) == "Janet" && Convert.ToString(vector.Item4) == "Weaver" && Convert.ToString(vector.Item5) == "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg");
            }

            [TestCase]
            public void When_GetUser_Expects_Is404()
            {
                var handler = new HttpClientHandler();
                var client = new HttpClient(handler);
                var vector = Class1.GetUser(client, "https://reqres.in/api/users/23");

                Assert.That(Convert.ToString(vector)=="404");
            }
            [TestCase]
            public void When_GetUser_Expects_DelayIs3Sec()
            {
                var handler = new HttpClientHandler();
                var client = new HttpClient(handler);
                var vector = Class1.ListUsers(client, "https://reqres.in/api/users?delay=3");

                Assert.That(Convert.ToInt32(vector[5])>2);
            }
        }

        static void Main()
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            var vector = Class1.GetUser(client, "https://reqres.in/api/users/2");
            Console.WriteLine(vector);
            

            



        }
    }
}
