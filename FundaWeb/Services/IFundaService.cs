using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaWeb.Services
{
    public class IFundaService
    {
        Task<List<MakelaarCount>> GetTopMakelaars();
        Task<List<MakelaarCount>> GetTopMakelaarsWithTuin();
    }
}