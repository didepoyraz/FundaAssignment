using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FundaWeb.Models;
using System.Collections.Specialized;

namespace FundaWeb.Services
{
    public class FundaService: IFundaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "76666a29898f491480386d966b75f949";
        // var search = withGarden ? "/amsterdam/tuin/" : "/amsterdam/";
        public FundaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FundaPropertyModel>> GetTopMakelaars()
 { 
            var page = 1;
            var search = "/amsterdam/";

            // todo: go through all pages of the listings implement error handling for api calls
            // todo: extract the top 10 makelaars with most listings from the counts dict
            // todo: implement null check

            var url = $"http://partnerapi.funda.nl/feeds/Aanbod.svc/json/{_apiKey}/?type=koop&zo={search}&page={page}&pagesize=25";
            var response = await _httpClient.GetFromJsonAsync<FundaResponseModel>(url);
          
            var counts = new Dictionary<string, int>();
            foreach (var item in response.Objects)
            {
                var makelaar = item.MakelaarNaam;
                if (counts.ContainsKey(makelaar))
                {
                    counts[makelaar] = counts[makelaar] + 1;
                }
                else
                {
                    counts[makelaar] = 1;
                }
            }
            foreach (var pair in counts)
            {
                Console.WriteLine($"Makelaar: {pair.Key}, Count: {pair.Value}");
            }

            return response.Objects;
        }

        public async Task<List<FundaPropertyModel>> GetTopMakelaarsWithTuin()
        { 
            // temporary page holder
            var page = 1;
            var search = "/amsterdam/";
            
            var url = $"http://partnerapi.funda.nl/feeds/Aanbod.svc/json/{_apiKey}/?type=koop&zo={search}&page={page}&pagesize=25";
            var response = await _httpClient.GetFromJsonAsync<FundaResponseModel>(url);
            var counts = new Dictionary<string, int>();
            foreach (var item in response.Objects)
            {
                var makelaar = item.MakelaarNaam;
                if (counts.ContainsKey(makelaar))
                {
                    counts[makelaar] = counts[makelaar] + 1;
                }
                else
                {
                    counts[makelaar] = 1;
                }
            }

            return response.Objects;
        }
    }
}