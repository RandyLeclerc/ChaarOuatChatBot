using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OuatApi.Models
{
    public class Temp
    {
        //public Temp(string question, string answer)
        //{
        //    this.question = question;
        //    this.answer = answer;
        //}

        //Fields
        //public string question;
        //public string answer;

        static string host = "https://qnamakerouat.azurewebsites.net/";
        static string service = "/qnamaker/v4.0";
        static string method = "/knowledgebases/";

        // NOTE: Replace this with a valid subscription key.
        static string key = "be07d471-4831-448a-9d29-5d6521a5ed5a";

        // NOTE: Replace this with a valid knowledge base ID.
        static string kb = "cd2be153-3489-4ba1-a9c3-f20ae73a60a4";

        static string new_kb = @"
{
  'add': {
    'qnaList': [
      {
        'id': 1,
        'answer': 'You can change the default message if you use the QnAMakerDialog. See this for details: https://docs.botframework.com/en-us/azure-bot-service/templates/qnamaker/#navtitle',
        'source': 'Custom Editorial',
        'questions': [
          'How can I change the default message from QnA Maker?'
        ],
        'metadata': []
      }
    ],
    'urls': [
      ''
    ]
  },
  'update' : {
    'name' : ''
  },
  'delete': {
    'ids': [
      0
    ]
  }
}
";

        public struct Response
        {
            public HttpResponseHeaders headers;
            public string response;

            public Response(HttpResponseHeaders headers, string response)
            {
                this.headers = headers;
                this.response = response;
            }
        }


        public string  Update(string Kb, string New_kb)
        {
            UpdateKB(Kb, New_kb);

            return "Done!";
        }


        async static void UpdateKB(string kb, string new_kb)
        {
            var response = await PostUpdateKB(kb, new_kb);
            var operation = response.headers.GetValues("Location").First();
            //Console.WriteLine(PrettyPrint(response.response));

            var done = false;
            while (true != done)
            {
                response = await GetStatus(operation);
                //Console.WriteLine(PrettyPrint(response.response));

                var fields = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.response);

                String state = fields["operationState"];
                if (state.CompareTo("Running") == 0 || state.CompareTo("NotStarted") == 0)
                {
                    var wait = response.headers.GetValues("Retry-After").First();
                    //Console.WriteLine("Waiting " + wait + " seconds...");
                    //Thread.Sleep(Int32.Parse(wait) * 1000);
                }
                else
                {
                    //Console.WriteLine("Press any key to continue.");
                    done = true;
                }
            }
        }

        async static Task<Response> PostUpdateKB(string kb, string new_kb)
        {
            string uri = host + service + method + kb;
            //Console.WriteLine("Calling " + uri + ".");
            return await Patch(uri, new_kb);
        }

        async static Task<Response> Patch(string uri, string body)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = new HttpMethod("PATCH");
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                return new Response(response.Headers, responseBody);
            }
        }

        static string PrettyPrint(string s)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(s), Formatting.Indented);
        }


        async static Task<Response> GetStatus(string operation)
        {
            string uri = host + service + operation;
            //Console.WriteLine("Calling " + uri + ".");
            return await Get(uri);
        }

        async static Task<Response> Get(string uri)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(uri);
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                return new Response(response.Headers, responseBody);
            }
        }

        async static void PublishKB()
        {
            var uri = host + service + method + kb;
            //Console.WriteLine("Calling " + uri + ".");
            var response = await Post(uri);
            //Console.WriteLine(PrettyPrint(response));
            //Console.WriteLine("Press any key to continue.");
        }

        async static Task<string> Post(string uri)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return "{'result' : 'Success.'}";
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }



    }
}