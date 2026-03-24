using FundaWeb.Models;

namespace FundaWeb.Services
{
    public interface IFundaService
    {
        Task<List<MakelaarCountModel>> GetTopMakelaars();
        Task<List<MakelaarCountModel>> GetTopMakelaarsWithTuin();
    }
}