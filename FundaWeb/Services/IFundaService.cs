using FundaWeb.Models;

namespace FundaWeb.Services
{
    public interface IFundaService
    {
        Task<List<FundaPropertyModel>> GetTopMakelaars();
        Task<List<FundaPropertyModel>> GetTopMakelaarsWithTuin();
    }
}