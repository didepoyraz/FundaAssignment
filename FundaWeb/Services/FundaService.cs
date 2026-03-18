using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FundaWeb.Services
{
    public class FundaService: IFundaService
    {
        private readonly HttpClient _httpClient;

        public FundaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MakelaarCount>> GetTopMakelaars()
        {
            var response = await _httpClient.GetFromJsonAsync<FundaResponse>("funda-url");

            // todo: implement processing listings and counting makelaars

            return result;
        }

        public async Task<List<MakelaarCount>> GetTopMakelaarsWithTuin()
        { 
            var response = await _httpClient.GetFromJsonAsync<FundaResponse>("funda-url-with-tuin");

            // todo: implement processing of makelaars with tuin

            return result;
        }
    }
}