using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Json;
using FundaWeb.Models;
namespace FundaWeb.Services
{
    public class FundaService: IFundaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "76666a29898f491480386d966b75f949";
        private readonly int pageNumber = 25;
        public FundaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MakelaarCountModel>> GetTop10(string search)
        { 
            // todo: implement error handling for api calls
            var counts = new Dictionary<int, MakelaarCountModel>();

            for (int page = 1; page <= pageNumber; page++)
            {
                var url = $"http://partnerapi.funda.nl/feeds/Aanbod.svc/json/{_apiKey}/?type=koop&zo={search}&page={page}&pagesize=25";
                var response = await _httpClient.GetFromJsonAsync<FundaResponseModel>(url);
          
                if (response == null || response.Objects == null)
                {
                    break;
                }

                foreach (var item in response.Objects)
                {
                    var id = item.MakelaarID;
                    var name = item.MakelaarNaam;

                    if (counts.ContainsKey(id))
                    {
                        counts[id].Count++;
                    }
                    else
                    {
                        counts[id] = new MakelaarCountModel
                        {
                            Makelaar = name,
                            Count = 1
                        };
                    }
                }
                page++;
            }
            // x.Key is the MakelaarId
            // x.Value is the MakelaarInfo object
            var result = counts
                .OrderByDescending(x => x.Value.Count)
                .Take(10)
                .Select(x => new MakelaarCountModel
                {
                    Makelaar = x.Value.Makelaar,
                    Count = x.Value.Count
                })
                .ToList();

            return result;
        }
        public async Task<List<MakelaarCountModel>> GetTopMakelaars()
        {
            var search = "/amsterdam/";
            return await GetTop10(search);
        }

        public async Task<List<MakelaarCountModel>> GetTopMakelaarsWithTuin()
        { 
            var search = "/amsterdam/tuin/";
            return await GetTop10(search);
        }
    }
}