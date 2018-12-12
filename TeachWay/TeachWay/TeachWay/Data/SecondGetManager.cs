using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachWay.Models;

namespace TeachWay.Data
{
    public class SecondGetManager
    {
        SecondIRestService restService;

        public SecondGetManager(SecondIRestService service)
        {
            restService = service;
        }

        public Task<List<SecondGetRequirements>> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
