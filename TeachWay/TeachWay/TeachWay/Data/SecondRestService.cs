using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeachWay.Models;
using TeachWay.ViewModels;
using TeachWay.Views;

namespace TeachWay.Data

{
    public class SecondRestService : SecondIRestService
    {
        HttpClient client;

        public List<SecondGetRequirements> Items { get; private set; }

        public SecondRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<List<SecondGetRequirements>> RefreshDataAsync()
        {
            Items = new List<SecondGetRequirements>();


            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var url = uri.ToString();
            try
            {

                var u = new User();
                u.ISGRAD = 0;   //Undergraduate list is 0 and Graduate list is 1
                var j = JsonConvert.SerializeObject(u);

                var response = await client.PostAsync(url, new StringContent(j));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<SecondGetRequirements>>(content);
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
