using System.Collections.Generic;
using System.Threading.Tasks;
using TeachWay.Models;

namespace TeachWay.Data
{
    public interface IRestService
    {
        Task<List<GetRequirements>> RefreshDataAsync();
    }
}
