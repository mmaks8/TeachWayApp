using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachWay.Models;

namespace TeachWay.Data
{
    public class GetRequirementsManager
    {
        IRestService restService;

        public GetRequirementsManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<GetRequirements>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

    }
}
