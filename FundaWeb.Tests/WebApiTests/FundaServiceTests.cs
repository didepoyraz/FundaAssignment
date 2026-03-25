using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaWeb.Services;
using Xunit;

namespace FundaWeb.Tests.WebApiTests
{
    public class FundaServiceTests
    {
        [Fact]
        public async Task FundaService_GetTopMakelaars_ReturnsList()
        {
            var service = new FundaService(new HttpClient());

            var result = await service.GetTopMakelaars();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count <= 10);
        }

        [Fact]
        public async Task FundaService_GetTopMakelaarsWithTuin_ReturnsList()
        {
            var service = new FundaService(new HttpClient());

            var result = await service.GetTopMakelaarsWithTuin();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count <= 10);
        }
    }



}