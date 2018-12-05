using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeachWay.Models;

namespace TeachWay.Data

{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<GetRequirements> Items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<List<GetRequirements>> RefreshDataAsync()
        {
            Items = new List<GetRequirements>();

            
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var url = uri.ToString();
            try
            {

                var u = new User();
                u.ACCOUNT = 2;
                var j = JsonConvert.SerializeObject(u);

                var response = await client.PostAsync(url, new StringContent(j));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<GetRequirements>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
