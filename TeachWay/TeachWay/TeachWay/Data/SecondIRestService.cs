using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachWay.Models;

namespace TeachWay.Data
{
    public interface SecondIRestService
    {
        Task<List<SecondGetRequirements>> RefreshDataAsync();
    }
}
